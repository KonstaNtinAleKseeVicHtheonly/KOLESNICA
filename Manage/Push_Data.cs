using DataCommandTest.Enums;
using DataCommandTest.User_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataCommandTest.Manage
{
    public static class Push_Data
    {
        public static async void Push_Data_New(Queue<TextBox> data, User user, string files)
        {
            string type = user.GetType().ToString();
            user.SetData(data);
            if (File.Exists(files))
                File.Delete(files);
            using FileStream fs = new(files, FileMode.OpenOrCreate);
            switch (type)
            {
                case "DataCommandTest.User_Data.UserGeneral":
                    await JsonSerializer.SerializeAsync<UserGeneral>(fs, (UserGeneral) user);
                    break;
                case "DataCommandTest.User_Data.UserContacts":
                    await JsonSerializer.SerializeAsync<UserContacts>(fs, (UserContacts) user);
                    break;
                case "DataCommandTest.User_Data.UserWork":
                    await JsonSerializer.SerializeAsync<UserWork>(fs, (UserWork) user);
                    break;
                case "DataCommandTest.User_Data.UserAuto":
                    await JsonSerializer.SerializeAsync<UserAuto>(fs, (UserAuto) user);
                    break;
                case "DataCommandTest.User_Data.UserCredits":
                    await JsonSerializer.SerializeAsync<UserCredits>(fs, (UserCredits) user);
                    break;
                default:
                    break;
            }
        }
        public static async void Push_Data_New(Queue<Label> data, User user, string files)
        {
            string type = user.GetType().ToString();
            user.SetData(data);
            if (File.Exists(files))
                File.Delete(files);
            using FileStream fs = new(files, FileMode.OpenOrCreate);
            switch (type)
            {
                case "DataCommandTest.User_Data.UserGeneral":
                    await JsonSerializer.SerializeAsync<UserGeneral>(fs, (UserGeneral)user);
                    break;
                case "DataCommandTest.User_Data.UserContacts":
                    await JsonSerializer.SerializeAsync<UserContacts>(fs, (UserContacts)user);
                    break;
                case "DataCommandTest.User_Data.UserWork":
                    await JsonSerializer.SerializeAsync<UserWork>(fs, (UserWork)user);
                    break;
                case "DataCommandTest.User_Data.UserAuto":
                    await JsonSerializer.SerializeAsync<UserAuto>(fs, (UserAuto)user);
                    break;
                case "DataCommandTest.User_Data.UserCredits":
                    await JsonSerializer.SerializeAsync<UserCredits>(fs, (UserCredits)user);
                    break;
                default:
                    break;
            }
        }
        public static async void Push_Data_Record(Manage_User muser, string file)
        {
            if (File.Exists(file))
                File.Delete(file);
            using FileStream fs = new(file, FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync<Manage_User>(fs, (Manage_User)muser);
        }
    }
}
