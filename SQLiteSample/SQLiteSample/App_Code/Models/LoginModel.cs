using SQLiteSample.App_Code.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SQLiteSample.App_Code.Models
{
    /// <summary>
    /// Loginモデルクラス
    /// </summary>
    public class LoginModel
    {
        #region プライベートフィールド
        
        /// <summary>
        /// Serverインスタンス
        /// </summary>
        private HttpServerUtility server;

        #endregion

        #region パブリックフィールド

        /// <summary>
        /// ユーザーエンティティ
        /// </summary>
        /// <remarks>Loginメソッド成功時にインスタンスが入る</remarks>
        public UserEntity UserEntity { get; private set; }

        #endregion


        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="server">Serverインスタンス</param>
        /// <remarks>デフォルトの設定を利用する</remarks>
        public LoginModel(HttpServerUtility server)
        {
            this.server = server;
            this.UserEntity = null;
        }

        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="userId">ユーザーID</param>
        /// <param name="password">パスワード</param>
        /// <returns>ログイン成否</returns>
        public bool Login(string userId, string password)
        {
            using (var db = new SQLiteDB(this.server))
            {
                var whereStrings = new List<string>();
                //パラメータ設
                db.AddParam("@userId", userId);
                db.AddParam("@password", password);

                //SQL発行
                var sql = new StringBuilder();
                sql.Append("SELECT");
                sql.Append("  USER_NAME ");
                sql.Append("FROM MT_USER ");
                sql.Append("WHERE ");
                sql.Append(" USER_ID = @userId ");
                sql.Append(" AND PASSWORD = @password ");

                var result = db.Fill(sql.ToString());
                if (result.Rows.Count <= 0)
                {
                    return false;
                }

                //ユーザーエンティティのインスタンスを生成
                this.UserEntity = new UserEntity()
                {
                    UserId = userId,
                    UserName = result.Rows[0]["USER_NAME"].ToString()
                };
            }

            return true;
        }
    }

    /// <summary>
    /// ユーザーエンティティ
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        public string UserId { set; get; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        public string UserName { set; get; }
    }
}