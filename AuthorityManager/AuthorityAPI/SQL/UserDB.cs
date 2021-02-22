using SQLLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using AuthorityAPI.Models;

namespace AuthorityAPI.SQL
{
    internal class UserDB : BaseSQLDB
    {
        #region Parameters Setting
        private string PageTableName = "Pages";
        private string AuthorityTableName = "UserAuthority";
        private string UserTableName = "Users";

        public override MySQLConnectData SetSQLConnectData()
        {
            return new MySQLConnectData
            {
                Server = "larrychen.ddns.net",
                Port = 3307,
                UserID = "larry980808",
                Password = "l0911604518",
                DataBase = "User"
            };
        }
        #endregion

        public string Login(string user, string password)
        {
            SQL.Select(UserTableName).SelectAll().Where().Column("User").EqualsValue(user)
                .Complete().Execute(out DataTable table);
            if (table == null || table.Rows.Count == 0)
                throw new CustomException("Please register first!!");
            if (password != SQLConvert.ToString(table.Rows[0]["Password"]))
                throw new CustomException("Wrong password!!");
            return SQLConvert.ToString(table.Rows[0]["Idx"]);
        }

        public bool AddNewUser(string user, string password)
        {
            return SQL.Insert(UserTableName).InsertColumn("User", user).InsertColumn("Password", password).Complete().Execute();
        }

        public bool UserExist(string user)
        {
            SQL.Select(UserTableName).SelectColumn("User").Where().Column("User").EqualsValue(user).Complete().Execute(out DataTable table);
            if (table == null || table.Rows.Count == 0)
                return false;
            return true;
        }

        public User GetAuthority(string userIdx)
        {
            User userResult = new User();
            userResult.UserName = userIdx;
            SQL.Select(AuthorityTableName).SelectColumn($"{PageTableName}.PageName").InnerJoin("PageIdx", PageTableName, "Idx")
                .Where().Column("UserIdx").EqualsValue(userIdx)
                .Complete().Execute(out DataTable table);
            userResult.PageNames = new List<string>();
            if(table != null)
            {
                foreach (DataRow row in table.Rows)
                    userResult.PageNames.Add(SQLConvert.ToString(row["PageName"]));
            }
            return userResult;
        }

        public string[] GetAllPageNames()
        {
            SQL.Select(PageTableName).SelectColumn("PageName").Complete().Execute(out DataTable table);
            List<string> pages = new List<string>();
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                    pages.Add(SQLConvert.ToString(row["PageName"]));
            }
            return pages.ToArray();
        }

        public bool ChangePageAuthority(int userIdx, string page, bool isOpen)
        {
            DataTable table;
            SQL.Select(AuthorityTableName).SelectAll().LeftJoin("PageIdx", PageTableName, "Idx")
            .Where().Column("UserIdx").EqualsValue(userIdx).And().Column($"{PageTableName}.PageName").EqualsValue(page)
            .Complete().Execute(out table);
            
            if ((isOpen && (table != null && table.Rows.Count != 0)) 
                || (!isOpen && (table == null || table.Rows.Count == 0)))
                return true;

            try
            {
                if (isOpen)
                    return SQL.Execute($"Insert Into UserAuthority (userIdx, pageIdx) Select Users.Idx userIdx, Pages.Idx pageIdx From Users, Pages Where Users.Idx={userIdx} and Pages.PageName='{page}';");
                else
                    return SQL.Execute($"Delete From UserAuthority Where UserIdx={userIdx} and PageIdx=(Select Pages.Idx From Pages Where Pages.PageName='{page}');");
            }
            catch(Exception ex)
            {
                throw new CustomException(ex.Message);
            }
        }

        public string[] GetAllowedPages(int userIdx)
        {
            SQL.Select(AuthorityTableName).SelectColumn("Pages.PageName").LeftJoin("PageIdx", PageTableName, "Idx")
                .Where().Column("UserIdx").EqualsValue(userIdx).Complete().Execute(out DataTable table);
            List<string> allowedPages = new List<string>();
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                    allowedPages.Add(SQLConvert.ToString(row["PageName"]));
            }
            return allowedPages.ToArray();
        }
    }
}