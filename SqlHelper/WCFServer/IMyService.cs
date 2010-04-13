using System.ServiceModel;

namespace WCFServer
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string Get_dbo_t3_Query_TSql(byte[] query);

        [OperationContract]
        byte[] GetData(byte[] query);
    }
}