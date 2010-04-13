using System.ServiceModel;

namespace WCFServer
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        int Add(int a, int b);
    }
}