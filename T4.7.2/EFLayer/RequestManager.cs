using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFLayer
{
    public class RequestManager
    {
        public IEnumerable<requestInfo> GetAllRequestInfo()
        {
            List<requestInfo> requests = null;
            using (RequestsEntities entities = new RequestsEntities())
            {
                requests = entities.requestInfoes.AsEnumerable().Select(x => new requestInfo { RequestId = x.RequestId, MobileNumber = x.MobileNumber, RequestDate = x.RequestDate }).ToList();

            }
                return requests;
        }
    }
}
