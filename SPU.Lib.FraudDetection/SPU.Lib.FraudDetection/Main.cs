// --------------------------------------------------------------------------
// <copyright file="Main.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Thai.Tran" date="2015.03.25">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.BusinessManager
{
    /// <summary>
    /// Main Class.
    /// </summary>
    public class Main
    {
        public static void Start(string[] args)
        {
            BaseAction action = new ActionSendEmail();
            action.TakeAction();
        }        
    }
}
