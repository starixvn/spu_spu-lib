using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public interface IMailMasterRender
    {
        int MailMasterId { get; set; }

        MailMasterInfo RenderContentOfMailMaster();
    }
}