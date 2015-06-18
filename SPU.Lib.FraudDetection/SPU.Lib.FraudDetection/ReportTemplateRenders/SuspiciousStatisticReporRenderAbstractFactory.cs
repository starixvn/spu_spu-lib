using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SPU.Lib.FraudDetection.DTO.ReportTemplate;
using SPU.Lib.FraudDetection.ReportTemplateRenders.TableRenders;

namespace SPU.Lib.FraudDetection.ReportTemplateRenders
{
    public class SuspiciousStatisticReporRenderAbstractFactory : IReportRenderAbstractFactory
    {
        public SuspiciousStatisticViewModel SuspiciousStatisticViewModel { get; set; }

        public SuspiciousStatisticReporRenderAbstractFactory()
        {
            SuspiciousStatisticViewModel =new SuspiciousStatisticViewModel();
        }

        public string CurrentDirectory
        {
            get 
            { 
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public IReportTemplateRender GetReportTemplateRender()
        {
            var suspiciousTableRender = new SuspiciousStatisticsTableRender
            {
                Model = SuspiciousStatisticViewModel.SuspiciousCustormers,
                Template = File.ReadAllText(CurrentDirectory + TemplateFileManager.SuspiciousStatisticTemplateFile)
            };

            var marginTableRender = new MarginTableRender
            {
                Model = SuspiciousStatisticViewModel.MarginCustormers,
                Template = File.ReadAllText(CurrentDirectory + TemplateFileManager.MarginTemplateFile)
            };

            return new SuspiciousStatisticReportRender
            {
                TableRenders = new List<ITableRender>
                {
                    suspiciousTableRender,
                    marginTableRender
                }
            };
        }
    }
}