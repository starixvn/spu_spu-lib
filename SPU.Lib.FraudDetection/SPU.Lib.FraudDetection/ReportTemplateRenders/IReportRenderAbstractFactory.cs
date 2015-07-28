// --------------------------------------------------------------------------
// <copyright file="IReportRenderAbstractFactory.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    public interface IReportRenderAbstractFactory
    {
        IReportTemplateRender GetReportTemplateRender();
    }
}