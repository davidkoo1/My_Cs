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
    class Schedule
    {
        public Dictionary<DayOfWeek, List<Subject>> schedules = new Dictionary<DayOfWeek, List<Subject>>();

        public void PrintDayInfo(params DayOfWeek[] days)
        {
            var countDay = schedules.Keys.Count();

            foreach (var dayInWeek in days)
            {
                Console.Write("\t" + dayInWeek);
                foreach (var subject in schedules[dayInWeek])
                {
                    Console.Write("\n" + subject.subjectName);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Остановился тут
            foreach (var day in days)
            {
                Console.WriteLine(day);
            }

            foreach (var item in schedules.Values)
            {
                Console.WriteLine(" " + item.Count());  
            }
            
        }
    }
}
