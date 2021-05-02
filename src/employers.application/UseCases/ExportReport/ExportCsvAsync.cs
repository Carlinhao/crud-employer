﻿using employers.application.Interfaces.ExportReport;
using employers.domain.Interfaces.Repositories.Employers;
using System.Text;
using System.Threading.Tasks;

namespace employers.application.UseCases.ExportReport
{
    public class ExportCsvAsync : IExportCsvAsync
    {
        private readonly IEmployerRepository _employerRepository;

        public ExportCsvAsync(IEmployerRepository employerRepository)
        {
            _employerRepository = employerRepository;
        }

        public async Task<string> ExportCsv()
        {
            var request = await _employerRepository.GetAll();

            var sb = new StringBuilder();
            sb.AppendFormat("Id, Name, Gender, Id Departament, Id Occupation, Active");
            sb.AppendLine();
            foreach (var item in request)
            {
                sb.AppendFormat("{0},{1},{2},{3},{4},{5}",
                     item.Id,
                     item.Name,
                     item.Gender,
                     item.IdDepartament,
                     item.IdOccupation,
                     item.Active);
                sb.AppendLine();
            }
            return await Task.FromResult(sb.ToString());
        }
    }
}
