using SQLiteSample.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLiteSample
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                if(Session[typeof(UserEntity).Name] == null){
                    Response.Redirect("Login.aspx", true);
                    return;
                }
            }
        }
    }
}