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
    public class Subject
    {
        public string subjectName;
        public string teacherName;
    }

    [Serializable]
    public enum DayOfWeek
    {
        Monday = 0,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    [Serializable]
    class Schedule
    {
       public Dictionary<DayOfWeek, List<Subject>> schedules = new Dictionary<DayOfWeek, List<Subject>>();
       
        public void PrintDayInfo(DayOfWeek day)
        {
            foreach (var n in schedules[day])
            {
                Console.WriteLine(n.subjectName);
            }
        }

    }

    
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

        public static Schedule DeserializeFromFile(string patch)
        {
            Schedule schedule = new Schedule();
            
            BinaryFormatter formatter = new BinaryFormatter(); 

            using (FileStream fs = new FileStream(patch, FileMode.OpenOrCreate))
            {
                schedule = (Schedule)formatter.Deserialize(fs);
            }

            return schedule;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string output = "output.dat";
            string input = @"C:\Users\sverc\OneDrive\Рабочий стол\irogi\CS\Exer9_1\Exer9_1\bin\Debug\net5.0\input.dat";

            Schedule sh1 = /*new Schedule();*/FileControl.DeserializeFromFile(input);
            /*
            List<Subject> subjectsForMonday = new List<Subject>
        {
            new Subject {subjectName = "Физика"},
            new Subject {subjectName = "История"},
            new Subject {subjectName = "Математика"},
            new Subject {subjectName = "Биология"},
            new Subject {subjectName = "География"},
            new Subject {subjectName = "СПОРТ"},
            new Subject {subjectName = "Химия"}

        };
         sh1.schedules.Add(DayOfWeek.Monday, subjectsForMonday);

            List<Subject> subjectsForFriday = new List<Subject>
        {
            new Subject {subjectName = "Физика"},
            new Subject {subjectName = "История"},
            new Subject {subjectName = "Математика"},
            new Subject {subjectName = "Химия"}

        };
            
            sh1.schedules.Add(DayOfWeek.Friday, subjectsForFriday);
            */
            sh1.PrintDayInfo(DayOfWeek.Friday);
            /*
            FileControl.SerializeToFile(sh1, output);
            */
            
        }
    }
}
