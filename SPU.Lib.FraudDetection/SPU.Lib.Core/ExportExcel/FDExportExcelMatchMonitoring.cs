// --------------------------------------------------------------------------
// <copyright file="FDExportExcel.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.10.13">Created</change>
// </history>

using System.Globalization;

namespace FD.Lib.Core.ExportExcel
{
    using DTO;
    using NPOI.SS.UserModel;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Fraud Detection Export Excel - Match Monitoring report.
    /// </summary>
    public class FDExportExcelMatchMonitoring : FDExportExcel
    {
        #region Attributes
        private const string NotScanned = "Not Scanned";

        private const string ScannedNosuspicious = "Scanned-No Suspicious";

        private const string ScannedHassuspicious = "Scanned-Has Suspiciou(s)";

        private IEnumerable<MatchMonitoring> _data;

        private ICellStyle _cellStyleNotScanned;

        private ICellStyle _cellStyleScannedNoSus;

        private ICellStyle _cellStyleScannedHasSus;
        #endregion

        #region Constructor
        public FDExportExcelMatchMonitoring(
            string filePath,
            string sheetName,
            IEnumerable<Legend> legends,
            IEnumerable<string> headers,
            IEnumerable<MatchMonitoring> data)
            : base(filePath, sheetName, legends, headers)
        {
            _data = data.ToList();
            GenerateCellStyles();
        }
        #endregion

        private void GenerateCellStyles()
        {
            _cellStyleNotScanned = Workbook.CreateCellStyle();
            _cellStyleNotScanned.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            _cellStyleNotScanned.FillPattern = FillPattern.SolidForeground;

            _cellStyleScannedNoSus = Workbook.CreateCellStyle();
            _cellStyleScannedNoSus.FillForegroundColor = IndexedColors.LightGreen.Index;
            _cellStyleScannedNoSus.FillPattern = FillPattern.SolidForeground;

            _cellStyleScannedHasSus = Workbook.CreateCellStyle();
            _cellStyleScannedHasSus.FillForegroundColor = IndexedColors.Red.Index;
            _cellStyleScannedHasSus.FillPattern = FillPattern.SolidForeground;
        }

        protected override void GenerateReportLegend()
        {
            SetUpACell(Sheet.GetRow(1), 4, NotScanned, ReportContentFont(), DecorateCellAlignment(DecorateCellBorder(_cellStyleNotScanned), HorizontalAlignment.Center));
            Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 4, 6));

            SetUpACell(
                Sheet.GetRow(3), 4, ScannedNosuspicious, ReportContentFont(), DecorateCellAlignment(DecorateCellBorder(_cellStyleScannedNoSus), HorizontalAlignment.Center));
            Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(3, 3, 4, 6));

            SetUpACell(
                Sheet.GetRow(5), 4, ScannedHassuspicious, ReportContentFont(), DecorateCellAlignment(DecorateCellBorder(_cellStyleScannedHasSus), HorizontalAlignment.Center));
            Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(5, 5, 4, 6));
        }

        protected override void GenerateReportContent()
        {
            if (!_data.Any())
            {
                SetUpACell(Sheet.CreateRow(RowIndex), 0, "There is no data.", ReportContentFont(), DecorateCellAlignment(ReportContentCellStyle(), HorizontalAlignment.Center));
                Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(RowIndex, RowIndex, 0, Headers.Count() - 1));
                return;
            }

            var rowCount = 0;
            foreach (var dataRow in _data)
            {
                var row = Sheet.CreateRow(RowIndex);
                row.Height = 519;
                var index = 0;
                rowCount++;
                SetUpACell(row, index++, rowCount.ToString(CultureInfo.InvariantCulture), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, index++, dataRow.IsDelinquent != null ? (dataRow.IsDelinquent.Value ? "Yes" : "No") : "No", ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, index++, dataRow.IsVerified != null ? (dataRow.IsVerified.Value ? "Yes" : "No") : "No", ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, index++, dataRow.LastVerifiedBy.Length > 0 ? dataRow.LastVerifiedBy : "-", ReportContentFont(), ReportContentCellStyle());
                ////SetUpACell(row, index++, dataRow.LeagueName, ReportContentFont(), ReportContentCellStyle());
                ////SetUpACell(row, index++, dataRow.MatchCode, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, index++, dataRow.Event, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, index++, dataRow.EventStatus, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));

                var setupCellIndex = index;
                for (; index <= (dataRow.SuspiciousCases.Count + setupCellIndex - 1); index++)
                {
                    SetUpACell(
                        row,
                        index,
                        string.Empty,
                        ReportContentFont(),
                        GetCellStyleBySuspiciousStatus(dataRow.SuspiciousCases.ElementAt(index - setupCellIndex).Value));
                }

                RowIndex++;
            }
        }

        protected override void SetColumnsWidth()
        {
            var index = 0;

            Sheet.SetColumnWidth(index++, 1800);
            Sheet.SetColumnWidth(index++, 3000);
            Sheet.SetColumnWidth(index++, 3000);
            Sheet.SetColumnWidth(index++, 5000);
            Sheet.SetColumnWidth(index++, 13000);
            Sheet.SetColumnWidth(index++, 5000);

            if (!_data.Any())
            {
                return;
            }

            var setupCellIndex = index;

            for (; index <= (_data.ElementAt(0).SuspiciousCases.Count + setupCellIndex - 1); index++)
            {
                Sheet.SetColumnWidth(index, 3000);
            }
        }

        protected override void AutoSizeColumnsWidth()
        {
            Sheet.AutoSizeColumn(1);
            Sheet.AutoSizeColumn(2);
            Sheet.AutoSizeColumn(3);
            Sheet.AutoSizeColumn(4);
            Sheet.AutoSizeColumn(5);
            Sheet.AutoSizeColumn(6);
            Sheet.AutoSizeColumn(7);
        }

        private ICellStyle GetCellStyleBySuspiciousStatus(int suspiciousStatus)
        {
            return suspiciousStatus == -1
                ? DecorateCellBorder(_cellStyleNotScanned)
                : (suspiciousStatus > 0 ? DecorateCellBorder(_cellStyleScannedHasSus) : DecorateCellBorder(_cellStyleScannedNoSus));
        }
    }
}
