namespace FD.Lib.Service.Implement
{
    using FD.Lib.Service.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Fanex.NAP.Framework.Command;
    using Fanex.Data.Repository;

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

        public IEnumerable<DTO.MessageMaster> GetAllMessage(ICriteria criteria)
        {
            throw new NotImplementedException();
        }

        public DTO.MessageMaster GetMessageById(ICriteria criteria)
        {
            throw new NotImplementedException();
        }
    }
}
