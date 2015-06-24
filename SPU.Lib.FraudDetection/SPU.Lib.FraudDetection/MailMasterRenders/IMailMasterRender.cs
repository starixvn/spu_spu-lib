namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    using DTO;

    public interface IMailMasterRender
    {
        MailMasterInfo RenderContentOfMailMaster(int mailMasterId);
    }
}