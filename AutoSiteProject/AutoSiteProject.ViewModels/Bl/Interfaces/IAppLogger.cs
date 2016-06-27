using System;

namespace AutoSiteProject.Models.Bl.Interfaces
{
    public interface IAppLogger
    {
        void WriteError(Exception ex);
        void WriteWarn(Exception ex);
        void WriteDebug(Exception ex);
        void WriteFatal(Exception ex);
    }
}
