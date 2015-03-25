// --------------------------------------------------------------------------
// <copyright file="ActionAssignGroup.cs" company="Nexcel Solutions Vietnam">
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
    /// ActionAssignGroup Class.
    /// </summary>
    public class ActionAssignGroup : BaseAction
    {
        public int CustId { get; set; }

        public int GroupId { get; set; }

        public override bool TakeAction()
        {
            throw new NotImplementedException();
        }
    }
}
