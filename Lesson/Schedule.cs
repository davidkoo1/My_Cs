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
            // var countDay = schedules.Keys.Count();

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

            //Сколько уроков на день
            foreach (KeyValuePair<DayOfWeek, List<Subject>> pair in schedules)
            {
                Console.WriteLine(pair.Key + " " + pair.Value.Count());
            }

        }

        
        //Метод должен быть возвращать int, но return d не сработало 
        public void DayNumber(string nameSubject)
        {
            List<string> subject = new List<string>();

            int d = 0;
            foreach (var n in schedules.Values)
            {
                foreach (var item in n)
                {
                    if (item.subjectName == nameSubject)
                    {
                        d++;
                    }
                }
            }

            Console.WriteLine(d);
        }
    }
}

/*

2) Вывести, сколько уроков по переданному предмету проходит в течение недели
3) Сделать замену одного предмета на другой: в метод передается 2 предмета, п1 п2, надо заменить все уроки п1 на урок п2
4) Сделать удаление всех уроков по переданному предмету
 
И сделать все те же задания, но с учителями
 
по уроку есть название предмета и имя учителя
 
то есть
1) Сколько уроков ведет определенный учитель
2) Удаление всех уроков которые ведет определенный учитель 

 
 */