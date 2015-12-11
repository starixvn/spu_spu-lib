// --------------------------------------------------------------------------
// <copyright file="FDExportExcelSuspiciousCustomer.cs" company="Nexcel Solutions Vietnam">
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
    using Model.Reports.SuspiciousCustomer;
    using NPOI.SS.UserModel;

    /// <summary>
    /// Fraud Detection Export Excel - Suspicious Customer report.
    /// </summary>
    public class FDExportExcelSuspiciousCustomer : FDExportExcel
    {
        #region Attributes

        private IEnumerable<SuspiciousCustomerReportModel> Data { get; set; }

        #endregion

        #region Constructor
        public FDExportExcelSuspiciousCustomer(
            string filePath,
            string sheetName,
            IEnumerable<Legend> legends,
            IEnumerable<string> headers,
            IEnumerable<SuspiciousCustomerReportModel> data)
            : base(filePath, sheetName, legends, headers)
        {
            Data = data.ToList();
        }
        #endregion

        protected override void GenerateReportLegend()
        {
            // There is no Legend for Suspicious Customer report.
        }

        protected override void GenerateReportContent()
        {
            if (!Data.Any())
            {
                SetUpACell(Sheet.CreateRow(RowIndex), 0, "There is no data.", ReportContentFont(), DecorateCellAlignment(ReportContentCellStyle(), HorizontalAlignment.Center));
                Sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(RowIndex, RowIndex, 0, Headers.Count() - 1));
                return;
            }

            foreach (var dataRow in Data)
            {
                var row = Sheet.CreateRow(RowIndex);
                SetUpACell(row, 0, dataRow.Row.ToString(), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, 1, dataRow.IsDelinquent ? "Yes" : "No", ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, 2, dataRow.IsVerified ? "Yes" : "No", ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Center));
                SetUpACell(row, 3, dataRow.Customer.CustName, ReportContentFont(), ReportContentCellStyle());
                SetUpACell(row, 4, dataRow.TotalViolations.ToString(), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, 5, dataRow.NewViolations.ToString(), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, 6, dataRow.ViolatedCases.ToString(), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));
                SetUpACell(row, 7, dataRow.Assignees == null ? "-" : dataRow.Assignees.Length > 0 ? dataRow.Assignees : "-", ReportContentFont(), ReportContentCellStyle());
                //SetUpACell(row, 2, dataRow.Group.GroupName, ReportContentFont(), ReportContentCellStyle());
                //SetUpACell(row, 3, dataRow.SuspiciousTime.ToString(), ReportContentFont(), ReportContentCellStyle(HorizontalAlignment.Right));

                RowIndex++;
            }
        }

        protected override void SetColumnsWidth()
        {
            Sheet.SetColumnWidth(0, 2000);
            Sheet.SetColumnWidth(1, 4000);
            Sheet.SetColumnWidth(2, 3000);
            Sheet.SetColumnWidth(3, 4000);
            Sheet.SetColumnWidth(4, 4000);
            Sheet.SetColumnWidth(5, 4000);
            Sheet.SetColumnWidth(6, 4000);
            Sheet.SetColumnWidth(7, 8000);
        }

        protected override void AutoSizeColumnsWidth()
        {
            // Do nothing for Columns Width of Fraud Case Details report.
        }
    }
}
