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
    using System.Collections.Generic;
    using System.Linq;
    using DTO;
    using NPOI.SS.UserModel;

    /// <summary>
    /// Fraud Detection Export Excel - Match Monitoring report.
    /// </summary>
    public class FDExportExcelMatchMonitoring : FDExportExcel
    {
        #region Attributes
        private const string NotScanned = "Not Scanned";

        private const string ScannedNosuspicious = "Scanned-No Suspicious";

        private const string ScannedHassuspicious = "Scanned-Has Suspiciou(s)";

        private IEnumerable<MatchMonitoring> Data { get; set; }

        private ICellStyle CellStyleNotScanned { get; set; }

        private ICellStyle CellStyleScannedNoSus { get; set; }

        private ICellStyle CellStyleScannedHasSus { get; set; }
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
            Data = data.ToList();
            GenerateCellStyles();
        }
        #endregion

        private void GenerateCellStyles()
        {
            CellStyleNotScanned = Workbook.CreateCellStyle();
            CellStyleNotScanned.FillForegroundColor = IndexedColors.Grey25Percent.Index;
            CellStyleNotScanned.FillPattern = FillPattern.SolidForeground;

            CellStyleScannedNoSus = Workbook.CreateCellStyle();
            CellStyleScannedNoSus.FillForegroundColor = IndexedColors.LightGreen.Index;
            CellStyleScannedNoSus.FillPattern = FillPattern.SolidForeground;

            CellStyleScannedHasSus = Workbook.CreateCellStyle();
            CellStyleScannedHasSus.FillForegroundColor = IndexedColors.Red.Index;
            CellStyleScannedHasSus.FillPattern = FillPattern.SolidForeground;
        }

        protected override void GenerateReportLegend()
        {
            SetUpACell(Sheet.GetRow(1), 4, NotScanned, ReportContentFont(), DecorateCellAlignment(DecorateCellBorder(CellStyleNotScanned), HorizontalAlignment.Center));
            Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 4, 6));

            SetUpACell(Sheet.GetRow(3), 4, ScannedNosuspicious, ReportContentFont(), DecorateCellAlignment(DecorateCellBorder(CellStyleScannedNoSus), HorizontalAlignment.Center));
            Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(3, 3, 4, 6));

            SetUpACell(Sheet.GetRow(5), 4, ScannedHassuspicious, ReportContentFont(), DecorateCellAlignment(DecorateCellBorder(CellStyleScannedHasSus), HorizontalAlignment.Center));
            Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(5, 5, 4, 6));
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
                var row = Sheet.CreateRow(RowIndex);
                row.Height = 519;
                var index = 0;
                rowCount++;
                SetUpACell(row, index++, rowCount.ToString(CultureInfo.InvariantCulture), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, index++, dataRow.IsDelinquent != null ? (dataRow.IsDelinquent.Value ? "Yes" : "No") : "No", ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, index++, dataRow.IsVerified != null ? (dataRow.IsVerified.Value ? "Yes" : "No") : "No", ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, index++, dataRow.LastVerifiedBy.Length > 0 ? dataRow.LastVerifiedBy : "-", ReportContentFont(), ReportContentCellStyle());
                //SetUpACell(row, index++, dataRow.LeagueName, ReportContentFont(), ReportContentCellStyle());
                //SetUpACell(row, index++, dataRow.MatchCode, ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
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

            if (!Data.Any())
            {
                return;
            }

            var setupCellIndex = index;

            for (; index <= (Data.ElementAt(0).SuspiciousCases.Count + setupCellIndex - 1); index++)
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
                ? DecorateCellBorder(CellStyleNotScanned)
                : (suspiciousStatus > 0 ? DecorateCellBorder(CellStyleScannedHasSus) : DecorateCellBorder(CellStyleScannedNoSus));
        }
    }
}
