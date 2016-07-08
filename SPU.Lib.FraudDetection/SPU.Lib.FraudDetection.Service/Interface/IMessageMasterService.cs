namespace FD.Lib.Service.Interface
{
    using Fanex.NAP.Framework.Command;
    using FD.Lib.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.Data.Repository;

    public interface IMessageMasterService
    {
        ICommandResult InsertMessage(ICriteria criteria);

        ICommandResult DeleteMessage(ICriteria criteria);

        ICommandResult UpdateMessage(ICriteria criteria);

        List<MessageMaster> GetAllMessage(ICriteria criteria);

        MessageMaster GetMessageById(ICriteria criteria);
    }
}
