// --------------------------------------------------------------------------
// <copyright file="IReportTemplateRender.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    using System.Collections.Generic;
    using TableRenders;

    public interface IReportTemplateRender
    {
        IList<ITableRender> TableRenders { get; set; }

        string RenderContent();
    }
}