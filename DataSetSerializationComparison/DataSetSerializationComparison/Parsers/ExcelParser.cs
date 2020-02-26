using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DataSetSerializationComparison.Parsers
{
    public class ExcelParser : IParser
    {
        public IEnumerable<YieldCurveModel> Parse(string resourceName)
        {
            var yieldCurveContents = new List<YieldCurveModel>();

            using (var spreadsheetDocument = SpreadsheetDocument.Open(resourceName, false))
            {
                var workBook = spreadsheetDocument.WorkbookPart;
                var workSheet = workBook.WorksheetParts.First();
                var sheetData = workSheet.Worksheet.Elements<SheetData>().First();

                foreach (var row in sheetData.Elements<Row>())
                {
                    try
                    {
                        if (row.RowIndex == 1)
                        {
                            continue;
                        }

                        var cellContents = new List<string>();

                        foreach (var cell in row.Elements<Cell>())
                        {
                            cellContents.Add(cell.InnerText);
                        }

                        yieldCurveContents.Add(new YieldCurveModel
                                                   {
                                                       YearsToMaturity = Convert.ToInt32(cellContents[0], CultureInfo.InvariantCulture),
                                                       Term = DateTime.Parse(cellContents[1], CultureInfo.InvariantCulture),
                                                       Value = Convert.ToDouble(cellContents[2], CultureInfo.InvariantCulture)
                                                   });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return yieldCurveContents;
        }
    }
}