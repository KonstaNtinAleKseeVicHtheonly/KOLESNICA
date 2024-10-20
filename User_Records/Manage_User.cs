using DataCommandTest.Manage;
using DataCommandTest.User_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace DataCommandTest
{
    public class Manage_User
    {
        public string? Login {  get; private set; }
        public string? Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool IsGood { get; private set; }

        public Manage_User() 
        {
            Login = null;
            Password = null;
            IsGood = false;
            IsAdmin = false;
        }
        
        public void LoadDataMenu(string login, string password, bool conditionAuthorized)
        {
            Login = login;
            Password = password;
            IsGood = CheckIsGood(conditionAuthorized);
            IsAdmin = Check_IsAdminOrUser_Info();
        }

        private bool CheckIsGood(bool conditionAuthorized)
        {
            if (conditionAuthorized)
            {
                Push_Data.Push_Data_Record(this, "SearchUserRecord.json");
                // Отправляем джейсон на селектирование (ПРОЦЕСС)
            }
            else
            {
                Push_Data.Push_Data_Record(this, "AddUserRecord.json");
                // Отправляем джейсон на вставку (ПРОЦЕСС)
            }
            return true;
        }
        private bool Check_IsAdminOrUser_Info() => IsGood && Login == "Admin";
    }
}
