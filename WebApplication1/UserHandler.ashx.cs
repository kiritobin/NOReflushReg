using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.BLL;
using WebApplication1.Model;

namespace WebApplication1
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler
    {
        UserInfo user = new UserInfo();
        UserInfoBLL userBll = new UserInfoBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userName = context.Request.QueryString["userName"].ToString();
            string password = context.Request.QueryString["pwd"].ToString();
            user = userBll.SelectUser(userName);
            if (userName == user.userName)
            {
                context.Response.Write("用户名已经存在！");
                return;
            }
            else if (userName=="")
            {
                context.Response.Write("用户名不能为空！");
                return;
            }
            else if (password=="")
            {
                context.Response.Write("密码不能为空！");
                return;
            }
            else
            {
                user.userName = userName;
                user.password = password;
                userBll.Insert(user);
                context.Response.Write("注册成功！");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}