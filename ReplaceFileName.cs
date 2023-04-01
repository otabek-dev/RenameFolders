using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RenameFolders
{
    internal class ReplaceFileName : ReplaceFolderName
    {
        public ReplaceFileName(string path, string newValu, params string[] oldValue) 
            : base(path, newValu, oldValue)
        {
        }

        protected void DeleteUrls(string[] dirs)
        {
            foreach (string dir in dirs)
            {
                if (dir.EndsWith(".url"))
                {
                    File.Delete(dir);
                }
                else if (dir.EndsWith("Прочти перед изучением!.docx"))
                {
                    File.Delete(dir);
                }
            }
        }

        public override void Run()
        {
            string[] dirs = Directory.GetFiles(Path);
            RenameDirsAndFiles(dirs);
            DeleteUrls(dirs);

            Console.WriteLine();
        }
    }
}
