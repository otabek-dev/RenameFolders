using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RenameFolders
{
    internal class ReplaceFolderName
    {
        private string path = string.Empty;
        public string Path 
        {
            get { return path; }
            
            set 
            {
                if (Directory.Exists(value))
                {
                    path = value;
                }
                else
                {
                    Console.WriteLine("Не существующий путь!");
                }
            } 
        }

        public string[] OldValue { get; set; }
        public string NewValue { get; set; } = string.Empty;

        public ReplaceFolderName(string path, string newValu, params string[] oldValue) 
        {
            Path = path ?? throw new ArgumentNullException("Оибка путь не может быть пустым");
            OldValue = oldValue;
            NewValue = newValu ?? string.Empty;
        }

        protected void RenameDirsAndFiles(string[] dirs)
        {
            string newPath = string.Empty;

            foreach (string dir in dirs)
            {
                foreach (var value in OldValue)
                {
                    if (dir.Substring(path.Length).Trim().StartsWith(value))
                    {
                        newPath = path + dir.Substring(path.Length).Trim().Replace(value, NewValue).Trim();
                        Console.WriteLine(newPath);

                        if (Directory.Exists(newPath))
                        {
                            Directory.Move(dir, newPath);
                        }
                        else if (File.Exists(newPath))
                        {
                            File.Move(dir, newPath);
                        }
                    }
                }
            }
        }

        public virtual void Run()
        {
            string[] dirs = Directory.GetDirectories(Path);
            RenameDirsAndFiles(dirs);
            
            Console.WriteLine();
        }
    }
}
