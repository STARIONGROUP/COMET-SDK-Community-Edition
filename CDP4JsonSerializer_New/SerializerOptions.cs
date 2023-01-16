using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace CDP4JsonSerializer_SystemTextJson
{
    class SerializerOptions
    {
        private SerializerOptions() { }

        private static JsonSerializerOptions options;

        private static readonly object Lock = new object();

        public static JsonSerializerOptions Options
        {
            get
            {
                if(options == null)
                {
                    lock (Lock)
                    {
                        if(options == null)
                        {
                            options = new JsonSerializerOptions()
                            {
                                WriteIndented = true,
                                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,                             
                                PropertyNameCaseInsensitive = true,
                                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString, 
                            };                            
                        }
                    }
                }

                return options;
            }
        }

        public static JsonSerializerOptions Copy()
        {
            return new JsonSerializerOptions(Options);
        }
    }
}
