// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportCompiler.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.ReportScript
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;

    using CDP4Reporting.DataCollection;
    using CDP4Reporting.Parameters;
    using CDP4Reporting.Utilities;

    /// <summary>
    /// A class that takes care of report compilation and retrieval of objects from the compiled <see cref="Assembly"/>
    /// to be used in Reporting
    /// </summary>
    public class ReportScriptHandler<TReport, TParameter> where TReport : class where TParameter : class
    {
        /// <summary>
        /// An <see cref="Action{T}"/> of type <see cref="string"/> that is invoked when an error is thrown during compilation or data retrieval
        /// </summary>
        private readonly Action<string> onError;

        /// <summary>
        /// An <see cref="Action{T}"/> of type <see cref="string"/> that is invoked when user output is needed during compilation or data retrieval
        /// </summary>
        private readonly Action<string> onOutput;

        /// <summary>
        /// The code compiler that handles the code compilation
        /// </summary>
        private readonly ICodeCompiler codeCompiler;

        /// <summary>
        /// The code compiler that handles the code compilation
        /// </summary>
        private readonly IXtraReportHandler<TReport, TParameter> xtraReportHandler;

        /// <summary>
        /// Retrieves the currently used for <see cref="IDataCollector"/>
        /// </summary>
        public IDataCollector CurrentDataCollector { get; set; }

        /// <summary>
        /// Gets or sets build output result
        /// </summary>
        public CompilerResults CompileResults { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="ReportScriptHandler{TReport, TParameter}"/> class
        /// </summary>
        /// <param name="xtraReportHandler">The <see cref="IXtraReportHandler{TReport, TParameter}"/></param>
        /// <param name="codeCompiler">The <see cref="ICodeCompiler"/></param>
        /// <param name="onError">An <see cref="Action{T}"/> of type <see cref="string"/> that is invoked when an error is thrown during compilation or data retrieval</param>
        /// <param name="onOutput">An <see cref="Action{T}"/> of type <see cref="string"/> that is invoked when user output is needed during compilation or data retrieval</param>
        public ReportScriptHandler(IXtraReportHandler<TReport, TParameter> xtraReportHandler, ICodeCompiler codeCompiler, Action<string> onError, Action<string> onOutput)
        {
            this.xtraReportHandler = xtraReportHandler;
            this.onError = onError;
            this.onOutput = onOutput;
            this.codeCompiler = codeCompiler;
        }

        /// <summary>
        /// Execute compilation of the code in the Code Editor
        /// </summary>
        public void CompileAssembly(string source)
        {
            try
            {
                this.onError?.Invoke(string.Empty);

                if (string.IsNullOrEmpty(source))
                {
                    this.onOutput?.Invoke("Nothing to compile.");
                    return;
                }

                var currentAssemblies =
                    AppDomain.CurrentDomain.GetAssemblies()
                        .Where(x => !x.IsDynamic)
                        .Select(x => x.Location)
                        .ToArray();

                this.CompileResults = this.codeCompiler.Compile(source, currentAssemblies);

                if (this.CompileResults == null || this.CompileResults.Errors.Count == 0)
                {
                    this.onOutput?.Invoke("File succesfully compiled.");
                    this.onError?.Invoke(string.Empty);
                    return;
                }

                var sbErrors = new StringBuilder($"{DateTime.Now:HH:mm:ss} Compilation Errors:");

                foreach (var error in this.CompileResults.Errors)
                {
                    sbErrors.AppendLine(error);
                }

                this.onError?.Invoke(sbErrors.ToString());

                this.CompileResults = null;
            }
            catch (Exception ex)
            {
                var exception = ex;

                while (exception != null)
                {
                    this.onOutput?.Invoke($"{ex.Message}\\n{ex.StackTrace}\\n");
                    exception = exception.InnerException;
                }
            }
        }

        /// <summary>
        /// Get the data representation for the report
        /// </summary>
        /// <returns>The datasource as an <see cref="IDataCollector"/></returns>
        public object GetDataSource(Iteration iteration, ISession session)
        {
            if (this.CompileResults == null)
            {
                this.onOutput?.Invoke("Build data source code first.");
                return null;
            }

            AppDomain.CurrentDomain.AssemblyResolve += this.AssemblyResolver;

            try
            {
                var editorFullClassName =
                    this.CompileResults.CompiledAssembly
                        .GetTypes()
                        .FirstOrDefault(t => t.GetInterfaces()
                            .Any(i => i == typeof(IDataCollector))
                        )?.FullName;

                if (editorFullClassName == null)
                {
                    this.onOutput?.Invoke($"No class that implements from {nameof(IDataCollector)} was found.");

                    return null;
                }

                var instObj = this.CompileResults.CompiledAssembly.CreateInstance(editorFullClassName) as IDataCollector;

                if (instObj == null)
                {
                    this.onOutput?.Invoke("DataCollector class not found.");
                    return null;
                }

                if (instObj is IIterationDependentDataCollector iterationDependentDataCollector)
                {
                    iterationDependentDataCollector.Initialize(iteration, session);
                }

                this.CurrentDataCollector = instObj;

                return instObj.CreateDataObject();
            }
            catch (Exception ex)
            {
                this.onError?.Invoke($"{ex.Message}\n{ex.StackTrace}");
                throw;
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= this.AssemblyResolver;
            }
        }

        /// <summary>
        /// Check if the compiled assembly built from the code editor contains a class that implements the <see cref="IReportingParameters"/> interface
        /// If true, then execute the class' <see cref="IReportingParameters.CreateParameters"/> method.
        /// </summary>
        /// <param name="dataSource">The datasource, which could be used to create parameters</param>
        /// <returns>The <see cref="IEnumerable{IReportingParameter}"/></returns>
        public IReadOnlyList<IReportingParameter> GetParameters(object dataSource)
        {
            var result = new List<IReportingParameter>();

            if (this.CompileResults == null)
            {
                this.onOutput?.Invoke("Compile data source code first.");
                return result;
            }

            AppDomain.CurrentDomain.AssemblyResolve += this.AssemblyResolver;

            try
            {
                var editorFullClassName =
                    this.CompileResults
                        .CompiledAssembly
                        .GetTypes()
                        .FirstOrDefault(t => t.GetInterfaces()
                            .Any(i => i == typeof(IReportingParameters))
                        )?.FullName;

                if (editorFullClassName == null)
                {
                    return result;
                }

                if (!(this.CompileResults.CompiledAssembly.CreateInstance(editorFullClassName) is IReportingParameters instObj))
                {
                    this.onOutput?.Invoke("Report parameter class not found.");
                    return result;
                }

                result = instObj.CreateParameters(dataSource, this.CurrentDataCollector)?.ToList();
            }
            catch (Exception ex)
            {
                this.onOutput?.Invoke(ex.ToString());
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= this.AssemblyResolver;
            }

            return result;
        }

        /// <summary>
        /// Check if the compiled assembly built from the code editor contains a class that implements the <see cref="IReportingParameters"/> interface
        /// If true, then execute the class' <see cref="IReportingParameters.CreateFilterString"/> method.
        /// </summary>
        /// <param name="parameters">The <see cref="IEnumerable{IReportingParameter}"/>, which could be used to create a filter string</param>
        /// <returns>The create Filter string in <see cref="IReportingParameters.CreateFilterString"/></returns>.
        public string GetFilterString(IEnumerable<IReportingParameter> parameters)
        {
            if (this.CompileResults == null)
            {
                this.onOutput?.Invoke("Compile data source code first.");
                return null;
            }

            AppDomain.CurrentDomain.AssemblyResolve += this.AssemblyResolver;

            try
            {
                var editorFullClassName =
                    this.CompileResults
                        .CompiledAssembly
                        .GetTypes()
                        .FirstOrDefault(t => t.GetInterfaces()
                            .Any(i => i == typeof(IReportingParameters))
                        )?.FullName;

                if (editorFullClassName == null)
                {
                    return null;
                }

                if (!(this.CompileResults.CompiledAssembly.CreateInstance(editorFullClassName) is IReportingParameters instObj))
                {
                    this.onOutput?.Invoke("Report parameter class not found.");
                    return null;
                }

                return instObj.CreateFilterString(parameters);
            }
            catch (Exception ex)
            {
                this.onOutput?.Invoke(ex.ToString());
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= this.AssemblyResolver;
            }

            return null;
        }

        /// <summary>
        /// Needed for using the CDP4Reporting assembly
        /// </summary>
        /// <param name="sender">The sender <see cref="object"/></param>
        /// <param name="args">The <see cref="ResolveEventArgs"/></param>
        /// <returns></returns>
        private Assembly AssemblyResolver(object sender, ResolveEventArgs args)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(x => x.FullName == args.Name);

            if (assembly != null)
            {
                return assembly;
            }

            return null;
        }

        /// <summary>
        /// Get report zip archive components
        /// </summary>
        /// <param name="rep4File">archive zip file</param>
        /// <returns>The <see cref="ReportZipArchive"/></returns>
        public ReportZipArchive GetReportZipArchive(string rep4File)
        {
            using (var zipFile = ZipFile.OpenRead(rep4File))
            {
                return this.GetReportZipArchive(zipFile);
            }
        }

        /// <summary>
        /// Get report zip archive components
        /// </summary>
        /// <param name="archive">The <see cref="ZipArchive"/></param>
        /// <returns>The <see cref="ReportZipArchive"/></returns>
        public ReportZipArchive GetReportZipArchive(ZipArchive archive)
        {
            var repxStream = new MemoryStream();
            var dataSourceStream = new MemoryStream();

            archive.Entries.FirstOrDefault(x => x.Name.EndsWith(".repx"))?.Open().CopyTo(repxStream);
            repxStream.Position = 0;
            archive.Entries.FirstOrDefault(x => x.Name.EndsWith(".cs"))?.Open().CopyTo(dataSourceStream);
            dataSourceStream.Position = 0;

            return new ReportZipArchive
            {
                ReportDefinition = repxStream,
                DataSourceCode = dataSourceStream
            };
        }

        /// <summary>
        /// Rebuild the report's datasource
        /// </summary>
        /// <param name="notifyParameterChange">Indicates if message should be shown when parameter values have been added, or removed.</param>
        /// <param name="iteration">The <see cref="Iteration"/></param>
        /// <param name="session">The <see cref="ISession"/></param>
        /// <returns>true if parameterchange message needs to be sent to the user, otherwise false</returns>
        public bool RebuildDataSource(Iteration iteration, ISession session, bool notifyParameterChange = false) 
        {
            const string dataSourceName = "ReportDataSource";

            object dataSource = string.Empty;

            try
            {
                dataSource = this.GetDataSource(iteration, session);
            }
            catch (Exception ex)
            {
                this.onError?.Invoke($"{ex.Message}\n{ex.StackTrace}");
                return false;
            }

            var parameters = this.GetParameters(dataSource);
            var filterString = string.Empty;

            if (parameters?.Any() ?? false)
            {
                filterString = this.GetFilterString(parameters);
            }

            this.xtraReportHandler.SetReportFilterString(filterString);

            var result = this.CheckParameters(parameters, notifyParameterChange);

            this.xtraReportHandler.SetReportDataSource(dataSourceName, dataSource);

            return result;
        }

        /// <summary>
        /// Check if the compiled assembly built from the code editor contains a class that implements the <see cref="IReportingParameters"/> interface
        /// If true, then create report parameters using that class.
        /// </summary>
        /// <param name="parameters">
        /// The <see cref="IEnumerable{IReportingParameter}"/> that contains the report's parameters
        /// </param>
        /// <param name="notifyParameterChange">Indicates if message should be shown when parameter values have been added, or removed.</param>
        private bool CheckParameters(IEnumerable<IReportingParameter> parameters, bool notifyParameterChange)
        {
            var notifyUser = false;
            var currentParameters = this.xtraReportHandler.GetCurrentParameters().ToList();
            var previouslySetValues = this.xtraReportHandler.GetPreviouslySetValues();

            if (notifyParameterChange)
            {
                var unChangedParameters = this.xtraReportHandler.GetUnChangedParameters(parameters).ToList();

                if (!unChangedParameters.Count.Equals(currentParameters.Count) || !unChangedParameters.Count.Equals(parameters.Count()))
                {
                    notifyUser = true;
                }
            }

            // Remove old dynamic parameters
            if (currentParameters.Any())
            {
                foreach (var reportParameter in currentParameters)
                {
                    this.xtraReportHandler.RemoveParameterIfExists(reportParameter);
                }
            }

            // Create new dynamic parameters
            foreach (var reportingParameter in parameters)
            {
                var previouslySetValue =
                    reportingParameter.Visible && previouslySetValues.ContainsKey(reportingParameter.ParameterName)
                        ? previouslySetValues[reportingParameter.ParameterName]
                        : null;

                this.CreateDynamicParameter(reportingParameter, previouslySetValue);

                if (notifyParameterChange)
                {
                    this.xtraReportHandler.SetParameterDefaultValues(reportingParameter);
                }
            }

            return notifyUser;
        }

        /// <summary>
        /// Create a dynamic parameter, set its default value based on previously set values and add it to the current Report
        /// </summary>
        /// <param name="reportingParameter">The <see cref="IReportingParameter"/></param>
        /// <param name="previouslySetValue">The previously set value in the report designer.</param>
        private void CreateDynamicParameter(IReportingParameter reportingParameter, object previouslySetValue)
        {
            var newReportParameter = this.xtraReportHandler.GetNewParameter(reportingParameter, true);

            if (reportingParameter.LookUpValues.Any())
            {
                this.xtraReportHandler.SetParameterStaticLookUpList(newReportParameter, reportingParameter);
            }

            // Restore default values
            if (previouslySetValue != null && !reportingParameter.ForceDefaultValue)
            {
                this.xtraReportHandler.SetParameterDefaultValue(newReportParameter, previouslySetValue);
            }
            else if (reportingParameter.DefaultValue != null)
            {
                this.xtraReportHandler.SetParameterDefaultValue(newReportParameter, reportingParameter.DefaultValue);
            }

            this.xtraReportHandler.SetParameterVisibility(newReportParameter, reportingParameter.Visible);

            // Add dynamic parameter to report definition
            this.xtraReportHandler.AddParameter(newReportParameter);
        }
    }
}
