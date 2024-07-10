using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ex2_Remasterd_do_Remake
{
    internal class SaveJson
    {
        public static string filePathName = @"C:\ex2 Remasterd do Remake\ex2 Remasterd do Remake.json";

        public void CreateDirectory()
        {
            string path = @"C:\ex2 Remasterd do Remake";

            if (!Directory.Exists(filePathName))
            {
                Directory.CreateDirectory(path);
            }
        }
        
        public void CreateFile()
        {
            CreateDirectory();
            FileStream ss = File.Open(filePathName, FileMode.OpenOrCreate);
            ss.Close();
        }
        public void SaveKeysInFile()
        {
            CreateFile();
            string json = JsonConvert.SerializeObject(Print.results);
            File.WriteAllText(filePathName, json);            

        }
        public void SaveFileKeysInList()
        {
            string jsonContent = File.ReadAllText(filePathName);
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                SaveCsv fs = new SaveCsv();
                fs.ReadKeysFromFile();
                return;
            }
            Print.results = JsonConvert.DeserializeObject<List<Result>>(jsonContent);
        }
    }
}
