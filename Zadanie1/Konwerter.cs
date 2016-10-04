using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConverter
{
    public class Konwerter : ISQLConverter
    {
        public override List<SqlQuery> ConvertToSqlInsert(string tabName, string typesBuff, string colNamBuff, string dataBuff)
        {
            //insert into tabName (colNamBuff) values (dataBuff)
            throw new NotImplementedException();
        }
    }
}
