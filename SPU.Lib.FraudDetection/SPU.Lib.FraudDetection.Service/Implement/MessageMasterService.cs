namespace FD.Lib.Service.Implement
{
    using Fanex.Data.Repository;
    using Fanex.NAP.Framework.Command;
    using FD.Lib.DataAccess.Implement;
    using FD.Lib.DTO;
    using FD.Lib.Service.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class MessageMasterService : QueryService, IMessageMasterService
    {
        private readonly MessageMasterDataAccess messMasterDataAccess;

        public MessageMasterService()
        {
            messMasterDataAccess = new MessageMasterDataAccess();
        }

        public ICommandResult InsertMessage(ICriteria criteria)
        {
            ICommandResult result = new CommandResult();
            if (criteria.IsValid())
            {
                result = messMasterDataAccess.Insert(criteria);
            }

            return result;
        }

        public ICommandResult DeleteMessage(ICriteria criteria)
        {
            ICommandResult result = new CommandResult();
            if (criteria.IsValid())
            {
                result = messMasterDataAccess.Delete(criteria);
            }

            return result;
        }

        public ICommandResult UpdateMessage(ICriteria criteria)
        {
            ICommandResult result = new CommandResult();
            if (criteria.IsValid())
            {
                result = messMasterDataAccess.Update(criteria);
            }

            return result;
        }

        public List<MessageMaster> GetAllMessage(ICriteria criteria)
        {
            var messages = new List<MessageMaster>();
            if (criteria.IsValid())
            {
                messages = GetData<MessageMaster>(criteria).ToList();
            }

            return messages;
        }

        public MessageMaster GetMessageById(ICriteria criteria)
        {
            var messages = new List<MessageMaster>();
            if (criteria.IsValid())
            {
                messages = GetData<MessageMaster>(criteria).ToList();
            }

            return messages.SingleOrDefault();
        }
    }
}
