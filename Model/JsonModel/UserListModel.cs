using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.JsonModel
{
    [DataContract]
    public class UserListModel
    {
        [DataMember(Order = 0)]
        public int total;
        [DataMember(Order=1)]
        public int count ;
        [DataMember(Order=2)]
        public UserListData data;
        [DataMember(Order=3)]
        public string next_openid;
    }

    [DataContract]
    public class UserListData
    {
        [DataMember(Order=0)]
        public string[] openid;
    }
}
