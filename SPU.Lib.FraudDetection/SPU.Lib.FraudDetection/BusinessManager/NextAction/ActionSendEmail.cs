// --------------------------------------------------------------------------
// <copyright file="ActionSendEmail.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

using System;
using System.Collections.Generic;
using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection.BusinessManager.NextAction
{
    /// <summary>
    /// ActionSendEmail Class.
    /// </summary>
    public class ActionSendEmail : BaseAction
    {
        public string _emailList { get; set; } // format: a@abc.com; b@abc.com

        private List<SuspiciousInfo> _suspiciousList;

        public ActionSendEmail(List<SuspiciousInfo> suspiciousList, string emailList)
        {
            _suspiciousList = suspiciousList;
            _emailList = emailList;
        }

        public override void TakeAction()
        {
            try
            {
                string template = string.Empty;
                foreach (var info in _suspiciousList)
                {
                    template += info.CustId + "-->" + info.MatchId + "-->" + info.TransIdList + "\r\n";
                }
                Fanex.Logging.Logger.Log.Info("Suspicious info \r\n" + template);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception ActionSendEmail --", ex);
            }
        }
    }
}