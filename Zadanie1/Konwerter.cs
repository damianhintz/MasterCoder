using System;
using System.IO;
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
            var queries = new List<SqlQuery>();
            var reader = new StringReader(dataBuff);
            var record = string.Empty;
            var names = colNamBuff.Split(';');
            var types = typesBuff.Split(';'); //STRING;STRING;INT;INT;INT;DATE
            while ((record = reader.ReadLine()) != null)
            {
                var sqlQuery = ParseQuery(record, tabName, names, types);
                queries.Add(sqlQuery);
            }
            return queries;
        }

        SqlQuery ParseQuery(string record, string table, string[] names, string[] types)
        {
            //0000000000001;Adam;Kowalskai;Lodz;;;mojemial1@wp.pl;adam1
            var pola = record.Split(';');
            //build components
            var columns = BuildColumnsComponents(pola, names);
            var values = BuildValuesComponents(pola, types);
            var components = BuildComponents(table, columns, values);
            var query = new SqlQuery(components);
            return query;
        }

        List<string> BuildComponents(string table, List<string> columns, List<string> values)
        {
            var components = new List<string>(new[] { "INSERT", "INTO", table, "(" });
            components.AddRange(columns);
            components.AddRange(new[] { ")", "VALUES", "(" });
            components.AddRange(values);
            components.AddRange(new[] { ")", ";" });
            //insert into tabName ( colNamBuff ) values ( dataBuff );
            return components;
        }

        List<string> BuildColumnsComponents(string[] pola, string[] names)
        {
            var columns = new List<string>();
            for (int i = 0; i < pola.Length; i++)
            {
                var value = pola[i].Trim();
                if (string.IsNullOrEmpty(value)) continue; //skip empty values
                var name = names[i].Trim();
                //insert column components
                if (columns.Count > 0) columns.Add(",");
                columns.Add(name);
            }
            return columns;
        }

        List<string> BuildValuesComponents(string[] pola, string[] types)
        {
            var values = new List<string>();
            for (int i = 0; i < pola.Length; i++)
            {
                var value = pola[i].Trim();
                if (string.IsNullOrEmpty(value)) continue; //skip empty values
                var type = types[i].Trim();
                //insert value components
                if (values.Count > 0) values.Add(","); //add comma
                if (type.Equals("INT")) values.Add(value);
                else values.Add("'" + value + "'"); //add quotes for strings and dates
            }
            return values;
        }
    }
}
