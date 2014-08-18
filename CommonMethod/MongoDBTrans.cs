using MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CommonMethod
{
    public class MongoDBTrans
    {
        #region 单例
        private static Mongo mongo;
        private static readonly string MongoConnectionString = "http://localhost:27017/";

        public MongoDBTrans()
        {
            mongo = new Mongo(MongoConnectionString);
        }




        #endregion
    }
}
