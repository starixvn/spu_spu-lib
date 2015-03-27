// --------------------------------------------------------------------------
// <copyright file="ActionAssignGroup.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    using System;
    using SPU.Lib.FraudDetection.Criteria;

    /// <summary>
    ///  Assign a suspicious customer to a customer group.
    /// </summary>
    public class ActionAssignGroup : BaseAction
    {
        public int CustId { get; set; }

        public int GroupId { get; set; }

        public override bool TakeAction()
        {
            CustomerGroupAssignCriteria criteria = new CustomerGroupAssignCriteria(); //todo

            throw new NotImplementedException();
        }
    }
}
