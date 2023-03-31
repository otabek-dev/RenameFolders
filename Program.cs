namespace RenameFolders
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            string dirName = @"O:\";
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                Console.WriteLine();
            }


            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                    //dirName + s.Substring(dirName.Length).Replace("[SW.BAND]", "").Trim()
                }
                Console.WriteLine(new string('-', 30));

                //Console.WriteLine("Файлы:");
                //string[] files = Directory.GetFiles(dirName);
                //foreach (string s in files)
                //{
                //    Console.WriteLine(s);
                //}
                ReplaceFolderName replace = new ReplaceFolderName(dirName, "", "[SW.BAND]", "[Infosklad.org]", "[sharewood.biz]");
                replace.Run();
            }


        }
    }
}