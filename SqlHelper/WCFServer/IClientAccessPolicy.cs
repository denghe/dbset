using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFServer
{
    [ServiceContract]
    public interface IClientAccessPolicy
    {
        [OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
        Stream GetClientAccessPolicy();
    }
}