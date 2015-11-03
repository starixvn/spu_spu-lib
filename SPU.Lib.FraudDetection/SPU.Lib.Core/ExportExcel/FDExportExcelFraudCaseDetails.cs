// --------------------------------------------------------------------------
// <copyright file="FDExportExcelFraudCaseDetails.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.20">Created</change>
// </history>

namespace FD.Lib.Core.ExportExcel
{
    using System.Collections.Generic;
    using System.Linq;
    using Model.Reports.FraudCaseDetail;
    using NPOI.SS.UserModel;

    /// <summary>
    /// Fraud Detection Export Excel - Fraud Case Details report.
    /// </summary>
    public class FDExportExcelFraudCaseDetails : FDExportExcel
    {
        #region Attributes

        private IEnumerable<FraudCaseDetailItem> Data { get; set; }

        #endregion

        #region Constructor
        public FDExportExcelFraudCaseDetails(
            string filePath,
            string sheetName,
            IEnumerable<Legend> legends,
            IEnumerable<string> headers,
            IEnumerable<FraudCaseDetailItem> data)
            : base(filePath, sheetName, legends, headers)
        {
            Data = data.ToList();
        }
        #endregion

        protected override void GenerateReportLegend()
        {
            // There is no Legend for Fraud Case Details report.
        }

        protected override void GenerateReportContent()
        {
            if (!Data.Any())
            {
                SetUpACell(Sheet.CreateRow(RowIndex), 0, "There is no data.", ReportContentFont(), DecorateCellAlignment(ReportContentCellStyle(), HorizontalAlignment.Center));
                Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(RowIndex, RowIndex, 0, Headers.Count() - 1));
                return;
            }

            var rowCount = 0;
            foreach (var dataRow in Data)
            {
                var columnCount = 0;
                var row = Sheet.CreateRow(RowIndex);
                rowCount++;
                SetUpACell(row, columnCount++, rowCount.ToString(), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, columnCount++, dataRow.CustName, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, columnCount++, dataRow.TransDate, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, columnCount++, dataRow.TransId.ToString(), ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, columnCount++, dataRow.BetType, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, columnCount++, dataRow.Choice, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, columnCount++, dataRow.Score, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, columnCount++, dataRow.Odds, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, columnCount++, dataRow.Stake, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, columnCount++, string.Format("{0:#,##0.00}", dataRow.WinLoss), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, columnCount++, dataRow.Status, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, columnCount++, dataRow.IP, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));

                RowIndex++;
            }
        }

        protected override void SetColumnsWidth()
        {
            var counter = 0;
            Sheet.SetColumnWidth(counter++, 2000);
            Sheet.SetColumnWidth(counter++, 5000);
            Sheet.SetColumnWidth(counter++, 6000);
            Sheet.SetColumnWidth(counter++, 4000);
            Sheet.SetColumnWidth(counter++, 3000);
            Sheet.SetColumnWidth(counter++, 8000);
            Sheet.SetColumnWidth(counter++, 2000);
            Sheet.SetColumnWidth(counter++, 3000);
            Sheet.SetColumnWidth(counter++, 3000);
            Sheet.SetColumnWidth(counter++, 3000);
            Sheet.SetColumnWidth(counter++, 2000);
            Sheet.SetColumnWidth(counter++, 3000);
        }

        protected override void AutoSizeColumnsWidth()
        {
            // Do nothing for Columns Width of Fraud Case Details report.
        }
    }
}
