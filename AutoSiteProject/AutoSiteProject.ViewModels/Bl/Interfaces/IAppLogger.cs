using System;

namespace AutoSiteProject.Models.Bl.Interfaces
{
    public interface IAppLogger
    {
        void WriteError(Exception ex);
    }
}
