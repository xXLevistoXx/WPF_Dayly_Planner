using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;

namespace Daily_Planner
{
    class Serialize_Deserealize
    {
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string file = "Daily_Planner.json";

        public static void CheckData()
        {
            bool fileExists = File.Exists(path + "\\" + file);
            if (fileExists == true)
            {
                Note.Notes = ReadData<List<Note>>(file);
            }
        }

        public static void SaveData<T>(T obj, string file)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path + "\\", json);
        }

        public static T ReadData<T>(string file)
        {
            string json = File.ReadAllText(path + "\\" + file);
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}
