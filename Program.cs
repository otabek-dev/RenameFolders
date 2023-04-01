namespace RenameFolders
{
    internal class Program
    {

        /*
         * Task 1 = замена названия деректории по заданому пользователем значения
         * Task 2 = заменя названия папок и подпапок
         * Task 3 = замена названия файлов и подфайлов
         * Task 4 = добавления нумерации фалам и папкам
         * Task 5 = Улучшить интерфейс
         * Task 6 = Проверки на входные значения
         */
        static void Main(string[] args)
        {
            string dirName = @"O:\";

            if (Directory.Exists(dirName))
            {
                //Console.WriteLine("Подкаталоги:");
                //string[] dirs = Directory.GetDirectories(dirName);
                //foreach (string s in dirs)
                //{
                //    Console.WriteLine(s);
                //    //dirName + s.Substring(dirName.Length).Replace("[SW.BAND]", "").Trim()
                //}
                Console.WriteLine(new string('-', 30));

                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

                ReplaceFolderName replace = new ReplaceFolderName(dirName, "", "[SW.BAND]", "[Infosklad.org]", "[sharewood.biz]");
                replace.Run();
                ReplaceFileName reFile = new ReplaceFileName(dirName, "", "[SW.BAND]", "[Infosklad.org]", "[sharewood.biz]");
                reFile.Run();
            }


        }
    }
}