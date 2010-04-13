using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServer {
    public class MyService : IMyService, IClientAccessPolicy {

        #region IClientAccessPolicy Members

        private static byte[] _buff = Encoding.UTF8.GetBytes(@"<?xml version=""1.0"" encoding=""utf-8""?>
<access-policy>
    <cross-domain-access>
        <policy>
            <allow-from>
                <domain uri=""*""/>
            </allow-from>
            <grant-to>
                <socket-resource port=""4502-4534"" protocol=""tcp""/>
            </grant-to>
        </policy>
    </cross-domain-access>
</access-policy>");

        [OperationBehavior]
        public Stream GetClientAccessPolicy() {
            if(WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return new MemoryStream(_buff);
        }

        #endregion

        #region IService Members

        public int Add(int a, int b) {
            return (a + b);
        }

        public byte[] GetData(byte[] query) {

            return null;
        }

        #endregion
    }

}