using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

namespace BusinessManager.Data
{
    public class BaseUserDAL
    {
        public static List<UserDataModel> GetAll()
        {
            List<UserDataModel> users = new List<UserDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUsers", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                UserDataModel user = new UserDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    user.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["FirstName"].GetType() != typeof(DBNull))
                {
                    user.FirstName = Convert.ToString(item["FirstName"]);
                }
                if (item["LastName"].GetType() != typeof(DBNull))
                {
                    user.LastName = Convert.ToString(item["LastName"]);
                }
                if (item["Email"].GetType() != typeof(DBNull))
                {
                    user.Email = Convert.ToString(item["Email"]);
                }
                if (item["Password"].GetType() != typeof(DBNull))
                {
                    user.Password = Convert.ToString(item["Password"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    user.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    user.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }

                users.Add(user);
            }

            return users;
        }

        public static UserDataModel Get(int id)
        {
            UserDataModel user = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUserByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                user = new UserDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    user.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["FirstName"].GetType() != typeof(DBNull))
                {
                    user.FirstName = Convert.ToString(item["FirstName"]);
                }
                if (item["LastName"].GetType() != typeof(DBNull))
                {
                    user.LastName = Convert.ToString(item["LastName"]);
                }
                if (item["Email"].GetType() != typeof(DBNull))
                {
                    user.Email = Convert.ToString(item["Email"]);
                }
                if (item["Password"].GetType() != typeof(DBNull))
                {
                    user.Password = Convert.ToString(item["Password"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    user.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    user.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
            }

            return user;
        }

        public static void Update(UserDataModel user)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", user.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramFirstName = new MySqlParameter("pFirstName", user.FirstName);
            paramFirstName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramFirstName);
            MySqlParameter paramLastName = new MySqlParameter("pLastName", user.LastName);
            paramLastName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramLastName);
            MySqlParameter paramEmail = new MySqlParameter("pEmail", user.Email);
            paramEmail.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramEmail);
            MySqlParameter paramPassword = new MySqlParameter("pPassword", user.Password);
            paramPassword.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramPassword);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", user.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", user.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(UserDataModel user)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", user.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramFirstName = new MySqlParameter("pFirstName", user.FirstName);
            paramFirstName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramFirstName);
            MySqlParameter paramLastName = new MySqlParameter("pLastName", user.LastName);
            paramLastName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramLastName);
            MySqlParameter paramEmail = new MySqlParameter("pEmail", user.Email);
            paramEmail.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramEmail);
            MySqlParameter paramPassword = new MySqlParameter("pPassword", user.Password);
            paramPassword.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramPassword);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", user.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", user.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }       

        public static List<UserDataModel> GetBy(int id)
        {
            List<UserDataModel> users = new List<UserDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUsersBy", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                UserDataModel user = new UserDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    user.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["FirstName"].GetType() != typeof(DBNull))
                {
                    user.FirstName = Convert.ToString(item["FirstName"]);
                }
                if (item["LastName"].GetType() != typeof(DBNull))
                {
                    user.LastName = Convert.ToString(item["LastName"]);
                }
                if (item["Email"].GetType() != typeof(DBNull))
                {
                    user.Email = Convert.ToString(item["Email"]);
                }
                if (item["Password"].GetType() != typeof(DBNull))
                {
                    user.Password = Convert.ToString(item["Password"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    user.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    user.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }

                users.Add(user);
            }

            return users;
        }

        public static int GetUserCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUserUserCount", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];

                if (item["count"].GetType() != typeof(DBNull))
                {
                    count = Convert.ToInt32(item["count"]);
                }
            }

            return count;
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
