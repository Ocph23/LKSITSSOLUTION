using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKSITSSOLUTION
{
    public class MyConnection
    {
        public static SqlConnection GetConnection()
        {
            
           // return new SqlConnection("Data Source=DESKTOP-V7BC4VT\\SQLEXPRESS; Initial Catalog=hotel; integrated security=true");
            return new SqlConnection("Data Source=DESKTOP-JVS72VO\\SQLEXPRESS; Initial Catalog=hoteldb; integrated security=true");
        }

    }
}
