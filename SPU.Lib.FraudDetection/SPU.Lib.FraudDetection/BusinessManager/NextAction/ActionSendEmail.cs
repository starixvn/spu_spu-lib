// --------------------------------------------------------------------------
// <copyright file="ActionSendEmail.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager.NextAction
{
    using System.Collections.Generic;
    using DTO;
    using MailMasterRenders;
    using MailSenders;
    using ReportTemplateRenders;
    using Service.Implement;
    using Service.Interface;

    /// <summary>
    ///     ActionSendEmail Class.
    /// </summary>
    public class ActionSendEmail : BaseAction
    {
        private readonly int _mailMasterId;
        private readonly IList<SuspiciousInfo> _suspiciousList;

        public ActionSendEmail(IList<SuspiciousInfo> suspiciousList, int mailMasterId)
        {
            _suspiciousList = suspiciousList;
            _mailMasterId = mailMasterId;
            MailSender = new SpuMailSender();
            ReportService = new ReportService();
        }

        public IMailSender MailSender { get; set; }
        public IReportService ReportService { get; set; }

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
        }
    }
}