using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Exer9_1
{


    [Serializable]
    class FileControl
    {
        public static void SerializeToFile(Schedule schedule, string path)
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, schedule);

            }
        }
    }
