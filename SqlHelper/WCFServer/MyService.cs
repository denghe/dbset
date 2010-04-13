using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Text;

using DAL;
using SqlLib;
using db = DAL.Database.Tables.dbo;
using qu = DAL.Queries.Tables.dbo;
//using SqlLib;

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
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
            return new MemoryStream(_buff);
        }

        #endregion

        #region IService Members

        public string Get_dbo_t3_Query_TSql(byte[] query) {
            var q = new qu.t3(query);
            return q.ToString();
        }

        public byte[] GetData(byte[] query) {
            var rows = new List<db.t3>();
            rows.Add(new db.t3 { c1 = 1, c2 = Guid.NewGuid(), c3 = DateTime.Now, c4 = "asdf" });
            rows.Add(new db.t3 { c1 = 2, c2 = Guid.NewGuid(), c3 = DateTime.Now, c4 = "qwert" });
            rows.Add(new db.t3 { c1 = 3, c2 = Guid.NewGuid(), c3 = DateTime.Now, c4 = "zxcvbn" });
            return rows.GetBytes();
        }

        #endregion
    }

}