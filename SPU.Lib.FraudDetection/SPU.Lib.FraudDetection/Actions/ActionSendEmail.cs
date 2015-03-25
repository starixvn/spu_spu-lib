// --------------------------------------------------------------------------
// <copyright file="ActionSendEmail.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Controller
{
    using System;

    /// <summary>
    /// ActionSendEmail Class.
    /// </summary>
    public class ActionSendEmail : BaseAction
    {
        public string Email { get; set; }

        public override bool TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
