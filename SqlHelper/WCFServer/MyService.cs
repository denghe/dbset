using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServer {
    public class MyService : IMyService, IClientAccessPolicy {

        #region IClientAccessPolicy Members

        private static Stream _ps = null;

        public MyService() {
            const string result = @"<?xml version=""1.0"" encoding=""utf-8""?>
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
</access-policy>";
            _ps = new MemoryStream(Encoding.UTF8.GetBytes(result));
        }

        [OperationBehavior]
        public Stream GetClientAccessPolicy() {
            if(WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return _ps;
        }


        #endregion

        #region IService Members

        public int Add(int a, int b) {
            return (a + b);
        }

        #endregion
    }

}