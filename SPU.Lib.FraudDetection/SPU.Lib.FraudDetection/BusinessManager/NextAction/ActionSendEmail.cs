// --------------------------------------------------------------------------
// <copyright file="ActionSendEmail.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

using System.IO;
using SPU.Lib.FraudDetection.MailMasterRenders;
using SPU.Lib.FraudDetection.MailSenders;
using SPU.Lib.FraudDetection.ReportTemplateRenders;
using SPU.Lib.FraudDetection.Service.Implement;
using SPU.Lib.FraudDetection.Service.Interface;

namespace SPU.Lib.FraudDetection.BusinessManager.NextAction
{
    using System;
    using System.Collections.Generic;
    using DTO;

    /// <summary>
    /// ActionSendEmail Class.
    /// </summary>
    public class ActionSendEmail : BaseAction
    {
        private readonly IList<SuspiciousInfo> _suspiciousList;

        private readonly int _mailMasterId;

        public IMailSender MailSender { get; set; }

        public IReportService ReportService { get; set; }

        public ActionSendEmail(List<SuspiciousInfo> suspiciousList, int mailMasterId)
        {
            _suspiciousList = suspiciousList;
            _mailMasterId = mailMasterId;
            MailSender = new SpuMailSender();
            ReportService = new ReportService();
        }

        public override void TakeAction()
        {
            if (_suspiciousList.Count > 0)
            {
                var model = ReportService.GetSuspiciousCustomerStatistics(_suspiciousList);

                var renderFactory = new SuspiciousStatisticReporRenderAbstractFactory
                {
                    SuspiciousStatisticViewModel = model
                };

                var mailMasterRenderAbstractFactory = new MailMasterRenderAbstractFactory
                {
                    ReportRenderFactory = renderFactory
                };

                MailSender.MailMasterRenderAbstractFactory = mailMasterRenderAbstractFactory;

                MailSender.SendMail(_mailMasterId);
            }
            else
            {
                
            }
        }
    }
}