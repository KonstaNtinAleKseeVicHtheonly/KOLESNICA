using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataCommandTest.Manage
{
    public static class POSTGRE_DATA
    {
        public static void Push_into_db(string executor, string file)
        {
            var newRecordProcess = new ProcessStartInfo();
            newRecordProcess.FileName = executor;
            var script = file;
            newRecordProcess.Arguments = $"\"{script}\"";
            newRecordProcess.UseShellExecute = false;
            newRecordProcess.CreateNoWindow = true;
            newRecordProcess.RedirectStandardOutput = true;
            newRecordProcess.RedirectStandardError = true;

            var errors = "";

            using (var process = Process.Start(newRecordProcess))
            {
                errors = process!.StandardError.ReadToEnd();
                if (errors != string.Empty)
                    MessageBox.Show(errors, "TIMURCHE", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
