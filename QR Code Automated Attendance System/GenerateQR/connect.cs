using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateQR
{
    class connect
    {
        public SqlConnection conn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public string locate = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\FLAG\source\repos\GenerateQR\GenerateQR\QRTestDB.mdf;Integrated Security = True";

    }
}
