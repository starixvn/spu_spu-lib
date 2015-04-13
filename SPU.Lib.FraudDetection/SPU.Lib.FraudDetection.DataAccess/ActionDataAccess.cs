// --------------------------------------------------------------------------
// <copyright file="ActionDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.DataAccess
{
    using System.Collections.Generic;
    using Fanex.NAP.Framework.Data;
    using SPU.Lib.FraudDetection.Criteria;

    /// <summary>
    /// Action Data Access.
    /// </summary>
    public class ActionDataAccess : BaseDataAccess
    {
        public ActionDataAccess() : base()
        {
        }
        
        public List<Bettype> GetActions(ICriteria criteria)
        {
            return null;
        }
    }
}
