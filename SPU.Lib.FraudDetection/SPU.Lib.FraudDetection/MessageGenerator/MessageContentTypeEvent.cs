namespace FD.Lib.BusinessManager.MessageGenerator
{
    using FD.Lib.DTO;
    using Fanex.BetList.Core.Builder;
    using Fanex.BetList.Core.TicketHelper;
    using RemotingRef;
    using System.Collections.Generic;

    public class MessageContentTypeEvent : MessageContentType
    {
        public MessageContentTypeEvent() : base()
        {
            ContentTypeName = "";
        }

        public override List<Message> FormatContentType(List<Message> messages)
        {
            foreach (var message in messages)
            {
                if (message.MessageContent.IndexOf(ContentTypeName) > 0)
                {
                    message.MessageContent = message.MessageContent.Replace(
                        ContentTypeName,
                        CacheRef.GetTeamName(message.HomeId) + " - vs - " + CacheRef.GetTeamName(message.AwayId));
                }
            }

            return messages;
        }
    }
}
