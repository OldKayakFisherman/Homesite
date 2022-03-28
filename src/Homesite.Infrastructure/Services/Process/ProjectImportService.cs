using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Infrastructure.Services.Responses.Process;
using OfficeOpenXml;

namespace Homesite.Infrastructure.Services.Process
{
    public class ProjectImportService: IProjectImportService
    {
        public IProjectImportResult ImportProjects(MemoryStream fileData)
        {
            IProjectImportResult result = new ProjectImportResult();

            try
            {
                using (ExcelPackage pkg = new ExcelPackage(fileData))
                {
                    ExcelWorksheet worksheet = pkg.Workbook.Worksheets[0];

                    ExcelCellAddress endRangeAddress = worksheet.Dimension.End;

                    for (int row = 2; row <= endRangeAddress.Row; row++)
                    {
                        if (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Value.ToString()))
                        {
                            ProjectImportRecord record = new ProjectImportRecord();

                            record.Name = worksheet.Cells[row, 1].Value.ToString();
                            record.Client = worksheet.Cells[row, 2].Value.ToString();

                            if (worksheet.Cells[row, 3].Value != null)
                            {
                                record.StartYear =
                                    short.Parse(worksheet.Cells[row, 3].Value.ToString() ?? string.Empty);
                            }
                            else
                            {
                                result.Success = false;
                                result.Messages.Add($"Project Start Year must have a value at worksheet row ${row}");
                                return result;
                            }

                            record.EndYear = short.Parse(worksheet.Cells[row, 4].Value.ToString() ?? string.Empty);
                            record.Description = worksheet.Cells[row, 5].Value.ToString() ?? string.Empty;

                            if (worksheet.Cells[row, 6].Value != null &&
                                !string.IsNullOrEmpty(worksheet.Cells[row, 6].Value.ToString()))
                            {
                                foreach (var listValue in worksheet.Cells[row, 6].Value.ToString().Split(','))
                                {
                                    record.Roles.Add(listValue);
                                }
                            }

                            if (worksheet.Cells[row, 7].Value != null &&
                                !string.IsNullOrEmpty(worksheet.Cells[row, 7].Value.ToString()))
                            {
                                foreach (var listValue in worksheet.Cells[row, 7].Value.ToString().Split(','))
                                {
                                    record.Languages.Add(listValue);
                                }
                            }

                            if (worksheet.Cells[row, 8].Value != null &&
                                !string.IsNullOrEmpty(worksheet.Cells[row, 8].Value.ToString()))
                            {
                                foreach (var listValue in worksheet.Cells[row, 8].Value.ToString().Split(','))
                                {
                                    record.Databases.Add(listValue);
                                }
                            }

                            if (worksheet.Cells[row, 9].Value != null &&
                                !string.IsNullOrEmpty(worksheet.Cells[row, 9].Value.ToString()))
                            {
                                foreach (var listValue in worksheet.Cells[row, 9].Value.ToString().Split(','))
                                {
                                    record.Toolkits.Add(listValue);
                                }
                            }

                            if (worksheet.Cells[row, 10].Value != null &&
                                !string.IsNullOrEmpty(worksheet.Cells[row, 10].Value.ToString()))
                            {
                                foreach (var listValue in worksheet.Cells[row, 10].Value.ToString().Split(','))
                                {
                                    record.Methodologies.Add(listValue);
                                }
                            }

                            result.ProjectImports.Add(record);
                        }
                    }

                }

                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = ex;
            }

            return result;
        }
    }
}
