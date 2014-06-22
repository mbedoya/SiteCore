using BusinessManager.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessManager.Data
{
    public class UserDAL : BaseUserDAL
    {
        public static UserDataModel CheckUser(string email, string password)
        {
            UserDataModel user = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("CheckUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            MySqlParameter paramID = new MySqlParameter("pEmail", email);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            MySqlParameter paramPassword = new MySqlParameter("pPassword", password);
            paramPassword.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramPassword);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];

                user = new UserDataModel();

                user.ID = Convert.ToInt32(item["ID"]);
                user.FirstName = Convert.ToString(item["FirstName"]);
                user.LastName = Convert.ToString(item["LastName"]);
                user.Email = Convert.ToString(item["Email"]);
                user.Password = Convert.ToString(item["Password"]);
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    user.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                user.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
            }

            return user;
        }
		
    }
}