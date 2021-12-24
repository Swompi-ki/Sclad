using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sclad
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost"; // адрес
            int port = 3306; // порт подключения
            string database = "2haggler"; // наименование бд
            string username = "root"; // логин
            string password = "root"; // пароль

            return MySQLDBUtils.GetDBConnection(host, port, database, username, password);

        }
    }
}
