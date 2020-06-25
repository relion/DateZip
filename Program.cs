using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace DateZip
{
  static class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      // MessageBox.Show(args.Length.ToString());
      ProcessStartInfo p = new ProcessStartInfo();
      p.FileName = @"C:\Program Files\7-Zip\7zG.exe";
      string files_and_folders_to_compress = "";
      for (int i = 0; i < args.Length; i++)
      {
        files_and_folders_to_compress += @" """ + args[i] + @"""";
      }
      string folder_path = Path.GetFullPath(args[0]);
      DirectoryInfo parent_dir = Directory.GetParent(folder_path);
      string file_or_folder_path = parent_dir.ToString();
      string file_name;
      if (args.Length == 1)
      {
        file_name = System.IO.Path.GetFileName(folder_path);
      }
      else
      {
        file_name = parent_dir.Name.ToString();
      }
      string date_numbers = DateTime.Now.ToString("yyMMddHHmm"); // ss
      p.Arguments = string.Format(@"a -tzip -slp- -- ""{0}\{1} {2}.zip"" {3}", file_or_folder_path, date_numbers, file_name, files_and_folders_to_compress);
      // MessageBox.Show(p.Arguments);
      // p.WindowStyle = ProcessWindowStyle.Hidden;
      Process x = Process.Start(p);
      x.WaitForExit();
    }
  }
}
