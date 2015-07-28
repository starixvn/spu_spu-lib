// --------------------------------------------------------------------------
// <copyright file="IMailMasterRender.cs" company="Nexcel Solutions Vietnam">
// Copyright (coffee) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Long.Luu" date="2015.07.23">Created</change>
// </history>

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    using DTO;

    public interface IMailMasterRender
    {
        MailMasterInfo RenderContentOfMailMaster(int mailMasterId);
    }
}