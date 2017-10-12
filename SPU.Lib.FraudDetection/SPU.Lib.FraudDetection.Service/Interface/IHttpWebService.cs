namespace FD.Lib.Service.Interface
{
    using System.Threading.Tasks;

    public interface IHttpWebService
    {
        string GetJson(string url);

        string PostJson(string url, string serializedDataString);
    }
}
