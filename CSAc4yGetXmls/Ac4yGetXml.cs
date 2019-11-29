using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CSAc4yGetXmls
{
    public class Ac4yGetXml
    {

        private SqlConnection Connection { get; set; }

        public Ac4yGetXml() { }

        public Ac4yGetXml(SqlConnection connection)
        {
            Connection = connection;
        }
        public List<string> GetXmlsByGuids(List<string> guidList)
        {
            int i = 0;
            List<string> xmlList = new List<string>();
            foreach (var guid in guidList)
            {
                using (SqlCommand command = new SqlCommand("SELECT serialization FROM RAMetaObjektums WHERE GUID = @aGuid", Connection))
                {
                    command.Parameters.Add("@aGUID", SqlDbType.VarChar).Value = guid;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            xmlList.Add(reader.GetValue(0).ToString());
                        }
                    }
                }
            }
            return xmlList;
        }
    }
}
