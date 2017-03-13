// --------------------------------------------------------------------------
// <copyright file="FDExportExcelDailyDataMonitoring.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.13">Created</change>
// </history>

namespace FD.Lib.Core.ExportExcel
{
    using System.Collections.Generic;
    using System.Linq;
    using Model.Reports.DailyDataMonitoring;
    using NPOI.SS.UserModel;

    /// <summary>
    /// Fraud Detection Export Excel - Daily Data Monitoring report.
    /// </summary>
    public class FDExportExcelDailyDataMonitoring : FDExportExcel
    {
        #region Attributes

        private IEnumerable<DailyDataMonitoringModel> _data;

        #endregion

        #region Constructor
        public FDExportExcelDailyDataMonitoring(
            string filePath,
            string sheetName,
            IEnumerable<Legend> legends,
            IEnumerable<string> headers,
            IEnumerable<DailyDataMonitoringModel> data)
            : base(filePath, sheetName, legends, headers)
        {
            _data = data.ToList();
        }
        #endregion

        protected override void GenerateReportLegend()
        {
            // There is no Legend for Fraud Case Details report.
        }

        protected override void GenerateReportContent()
        {
            if (!_data.Any())
            {
                SetUpACell(Sheet.CreateRow(RowIndex), 0, "There is no data.", ReportContentFont(), DecorateCellAlignment(ReportContentCellStyle(), HorizontalAlignment.Center));
                Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(RowIndex, RowIndex, 0, Headers.Count() - 1));
                return;
            }

            foreach (var dataRow in _data)
            {   
                var rowCount = 0;
                var row = Sheet.CreateRow(RowIndex);
                SetUpACell(row, rowCount++, dataRow.Event, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, rowCount++, dataRow.EventDate, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, rowCount++, dataRow.DataType, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, rowCount++, dataRow.OldDate, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, rowCount++, dataRow.OldValue, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, rowCount++, dataRow.NewDate, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, rowCount++, dataRow.NewValue, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));

                RowIndex++;
            }
        }

        protected override void SetColumnsWidth()
        {
            var rowCount = 0;
            Sheet.SetColumnWidth(rowCount++, 12000);
            Sheet.SetColumnWidth(rowCount++, 5000);
            Sheet.SetColumnWidth(rowCount++, 10000);
            Sheet.SetColumnWidth(rowCount++, 5000);
            Sheet.SetColumnWidth(rowCount++, 4000);
            Sheet.SetColumnWidth(rowCount++, 5000);
            Sheet.SetColumnWidth(rowCount++, 4000);
        }

        protected override void AutoSizeColumnsWidth()
        {
            // Do nothing for Columns Width of Fraud Case Details report.
        }
    }
}
