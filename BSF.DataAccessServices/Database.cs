using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSF.DataAccessServices
{
    public class Database: IDatabase
    {
        public string ConnectionString { get; set; }

        public void ExecuteCommand(string commandText, List<Tuple<string, object>> parameters)
        {
            //TODO: get a properly set up database
            return;

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();

            //    using (SqlCommand command = new SqlCommand(commandText, connection))
            //    {
            //        foreach (var param in parameters)
            //        {
            //            command.Parameters.AddWithValue(param.Item1, param.Item2);
            //        }

            //        command.ExecuteNonQuery();
            //    }
            //}
        }        
    }
}
