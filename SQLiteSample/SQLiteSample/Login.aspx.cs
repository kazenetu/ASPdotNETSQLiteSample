using SQLiteSample.App_Code.Database;
using SQLiteSample.App_Code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLiteSample
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// ページロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoginID.Attributes.Add("required","");
            this.LoginID.Attributes.Add("autofocus", "");

            this.Password.Attributes.Add("required", "");
        }

        /// <summary>
        /// ログインボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var loginModel = new LoginModel(Server);
            if(loginModel.Login(this.LoginID.Text.Trim(),this.Password.Text.Trim())){
                //セッションにユーザー情報を追加
                Session[typeof(UserEntity).Name] = loginModel.UserEntity;

                //メイン画面にリダイレクト
                Response.Redirect("Main.aspx", true);
            }else{
                    this.ErrorMessage.Text = "ユーザーID または パスワードが異なります";
            }
        }
    }
}