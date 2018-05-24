using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Model;

namespace WebApplication1.BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL userInfoDal = new UserInfoDAL();
        public UserInfo SelectUser(string userName)
        {
            return userInfoDal.SelectUser(userName);
        }
        public void Insert(UserInfo user)
        {
            userInfoDal.Insert(user);
        }
    }
}