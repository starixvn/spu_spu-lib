using SPU.Lib.FraudDetection.DTO;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public interface IMailMasterRender
    {
        MailMasterInfo RenderContentOfMailMaster(int mailMasterId);
    }
}