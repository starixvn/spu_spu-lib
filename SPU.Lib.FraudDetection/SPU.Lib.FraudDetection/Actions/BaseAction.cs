// --------------------------------------------------------------------------
// <copyright file="BaseAction.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.Controller
{
    /// <summary>
    /// BaseAction Class.
    /// </summary>
    public abstract class BaseAction
    {
        protected int ActionID { get; set; }

        protected string ActionName { get; set; }

        protected bool IsActive { get; set; }

        public abstract bool TakeAction();
    }
}
