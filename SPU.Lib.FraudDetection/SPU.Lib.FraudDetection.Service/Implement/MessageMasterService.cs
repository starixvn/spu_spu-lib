namespace FD.Lib.Service.Implement
{
    using FD.Lib.Service.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;
    using FD.Lib.DTO;

    public class MessageMasterService : QueryService, IMessageMasterService
    {

        public ICommandResult InsertMessage(ICriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICommandResult DeleteMessage(ICriteria criteria)
        {
            throw new NotImplementedException();
        }

        public ICommandResult UpdateMessage(ICriteria criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageMaster> GetAllMessage(ICriteria criteria)
        {
            return GetData<MessageMaster>(criteria);
        }

        public MessageMaster GetMessageById(ICriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
