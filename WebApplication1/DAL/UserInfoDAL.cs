using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.DAL
{
    public class UserInfoDAL
    {
        SQLHelper sqlHelp = new SQLHelper();

        #region 用户登录
        public UserInfo SelectUser(string userName)
        {
            UserInfo user = new UserInfo();
            SqlDataReader reader = sqlHelp.ExecuteSqlReader("select * from T_login where username=@userName",
                new SqlParameter("@userName", userName));
            while (reader.Read())
            {
                user.userName = reader.GetString(1);
            }
            reader.Close();
            return user;
        }
        #endregion

        #region 用户注册
        public void Insert(UserInfo user)
        {
            sqlHelp.ExecuteNonQuery(@"INSERT INTO T_login
                       (username,password)                                 
                        VALUES
                       (@UserName,@password)",
                new SqlParameter("@userName", user.userName),
                new SqlParameter("@password", user.password));
        }
        #endregion
    }
}