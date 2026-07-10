using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funcdemo
{
    internal class FuncDemo
    {

        internal void RunLogicApplication()
        {
            string userText = Console.ReadLine();
            SaveFile(userText, "c:/temp/demo.txt");


            SaveFile("configuratie", "c:/app/config.cfg");

            FileInfo userFile = new FileInfo("c:/app/config.cfg");
            string fileContent = LoadFile(userFile);
        }

        internal void SaveFile(string text, string filename)
        {

            //File.WriteAllText(text, filename);
        }

        internal string LoadFile(FileInfo fi)
        {

            string content = File.ReadAllText(fi.FullName);
            return content;
        }

    }


}



