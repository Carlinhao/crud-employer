﻿using System.Threading.Tasks;

namespace employers.application.Interfaces.ExportReport
{
    public interface IExportCsvAsync
    {
        Task<string> ExportCsv();
    }
}
