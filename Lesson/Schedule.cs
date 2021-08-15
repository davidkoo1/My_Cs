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

            //Кол-во уроков на каждый день
            foreach (KeyValuePair<DayOfWeek, List<Subject>> pair in schedules)
            {
                Console.WriteLine(pair.Key + " " + pair.Value.Count());
            }

        }

        
        //Метод возвращает кол-во s урока по всей недели
        public int DayNumber(string nameSubject)
        {
            int d = 0;

            foreach (List<Subject> listSubject in schedules.Values)
            {
                foreach (Subject schedulesSubject in listSubject)
                {
                    if (schedulesSubject.subjectName == nameSubject)
                    {
                        d++;
                    }
                }
            }

            return d;
            //void Console.WriteLine(d);
        }


        //Замена предметов 
        public void ReplaceLesson(string subject, string replaceSubject)
        {

            foreach (List<Subject> subjectList in schedules.Values)
            {
                foreach (Subject lesson in subjectList)
                {
                    if (lesson.subjectName == subject)
                    {
                        lesson.subjectName = replaceSubject;
                    }
                }
            }
        }

        //Удаление предмета
        public void ClearDay(string subject)
        {

            foreach (List<Subject> subjects in schedules.Values)
            {
               for (int i = 0; i < subjects.Count; i++)
                {
                    if (subjects[i].subjectName == subject)
                    {
                        subjects.Remove(subjects[i]);
                    }
                }
            }
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