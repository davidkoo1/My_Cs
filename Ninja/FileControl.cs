using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
    public static class FileControl
    {
       
        public static void WriteToFile(List<Ninja> ninja, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var n in ninja)
                {
                    sw.WriteLine(n.GetType().Name + " " + n.name);
                }

            }
        }

        public static List<Ninja> ReadFromFile(string path)
        {
           List<Ninja> ninjas = new List<Ninja>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] info = line.Split(" ");

                    string typename = info[0];
                    string ninjaName = info[1];

                    Type ninjaFactory = typeof(NinjaFactory);
                    Ninja ninja = ninjaFactory.GetMethod("Create" + typename).Invoke(null, null) as Ninja;

                    ninja.name = ninjaName;

                    ninjas.Add(ninja);

                }
            }
            return ninjas;
        }


        public static void SerializeToFile(List<Ninja> ninja, string path)
        {

            BinaryFormatter formatter = new BinaryFormatter();

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ninja);
                //Console.WriteLine("Объект сериализован");
            }
        }

        public static List<Ninja> DeserializeFromFile(string patch)
        {
            List<Ninja> ninjas = new List<Ninja>();
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter(); // десериализация из файла people.dat
            
            using (FileStream fs = new FileStream(patch, FileMode.OpenOrCreate))
            {
                ninjas = (List<Ninja>)formatter.Deserialize(fs);
            }

            return ninjas;
        }
    }
}
