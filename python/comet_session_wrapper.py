"""High level wrapper for establishing a COMET session from Python via pythonnet.

This module demonstrates how to use the .NET COMET SDK assemblies from an
existing CPython environment. It relies on pythonnet to bridge between the
Python and .NET runtimes and provides a small convenience class that mirrors the
C# sample:

.. code-block:: csharp

    var uri = new Uri("https://cdp4services-public.cdp4.org");
    var credentials = new Credentials("some-user-name", "some-password", uri);
    var dal = new CdpServicesDal();
    var session = new Session(dal, credentials);

The :class:`CometSession` class consolidates these steps for Python projects.
"""

from __future__ import annotations

from dataclasses import dataclass
from pathlib import Path
from typing import Iterable, Optional

import clr  # type: ignore[attr-defined]


# Assemblies that are required to load the COMET SDK types that participate in the
# session establishment flow. The list can be extended if your application uses
# additional features from the SDK.
_DEFAULT_ASSEMBLIES: tuple[str, ...] = (
    "CDP4Common.dll",
    "CDP4Dal.dll",
    "CDP4ServicesDal.dll",
)


def add_comet_references(search_paths: Iterable[Path], assemblies: Optional[Iterable[str]] = None) -> None:
    """Register COMET SDK assemblies with pythonnet.

    Parameters
    ----------
    search_paths:
        A sequence of directories that contain the built COMET SDK ``.dll``
        files. Each path is added to ``sys.path`` visible to pythonnet so that
        the assemblies can be resolved.
    assemblies:
        The assemblies to load. When omitted, a sensible default set that is
        sufficient for session creation is used.

    Notes
    -----
    ``pythonnet`` resolves assemblies relative to the interpreter process. By
    pushing the build output directories first we can keep the calling
    environment self-contained.
    """

    from sys import path as sys_path

    assembly_names = tuple(assemblies) if assemblies is not None else _DEFAULT_ASSEMBLIES

    for candidate in search_paths:
        resolved = Path(candidate).expanduser().resolve()
        if resolved.is_dir():
            sys_path.insert(0, str(resolved))

    for assembly in assembly_names:
        clr.AddReference(assembly)


@dataclass
class CometSession:
    """Helper that encapsulates the creation of a COMET session.

    Attributes
    ----------
    url:
        The service endpoint (e.g. ``"https://cdp4services-public.cdp4.org"``).
    username:
        Username for the COMET service.
    password:
        Password for the COMET service.
    dal:
        Instance of :class:`CDP4ServicesDal.CdpServicesDal` used to communicate
        with the service. The default creates a fresh instance, but a custom one
        can be supplied if a pre-configured DAL is required.
    session:
        The managed :class:`CDP4Dal.Session` created after calling
        :meth:`connect`.
    """

    url: str
    username: str
    password: str
    dal: Optional["CdpServicesDal"] = None

    def __post_init__(self) -> None:
        self._session: Optional["Session"] = None

    @property
    def session(self) -> "Session":
        """The underlying COMET session.

        Raises
        ------
        RuntimeError
            If :meth:`connect` has not been called yet.
        """

        if self._session is None:
            raise RuntimeError("Session has not been established. Call connect() first.")
        return self._session

    def connect(self) -> "Session":
        """Create the COMET session and return the managed .NET object."""

        from System import Uri  # type: ignore[attr-defined]
        from CDP4Dal.DAL import Credentials  # type: ignore[attr-defined]
        from CDP4ServicesDal import CdpServicesDal  # type: ignore[attr-defined]
        from CDP4Dal import Session  # type: ignore[attr-defined]

        uri = Uri(self.url)
        credentials = Credentials(self.username, self.password, uri)
        dal = self.dal or CdpServicesDal()
        self._session = Session(dal, credentials)
        return self._session

    def disconnect(self) -> None:
        """Dispose of the session if it has been created."""

        if self._session is not None:
            self._session.Dispose()
            self._session = None


__all__ = ["CometSession", "add_comet_references"]

