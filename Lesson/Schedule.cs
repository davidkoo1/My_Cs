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
                Console.WriteLine("\n\t" + dayInWeek);
                foreach (var subject in schedules[dayInWeek])
                {
                    Console.Write("\n" +  "\tSubject:\t" +subject.subjectName + " \tTeacher:\t" + subject.teacherName);
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            //Кол-во уроков на каждый день
            foreach (KeyValuePair<DayOfWeek, List<Subject>> pair in schedules)
            {
                Console.WriteLine(pair.Key + " " + pair.Value.Count());

                /*
                if (pair.Value.Count <= 0)
                {
                    Console.WriteLine("null");
                }*/
                /*foreach (var item in pair.Value)
                {
                    Console.WriteLine(item.teacherName);
                }*/

            }

        }

//!Методы по урокам
        
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

        //!Методы по учетилям

        //Метод возвращает кол-во уроков учителя
        public int TeacherNumber(string nameTeacher)
        {
            int d = 0;

            foreach (List<Subject> list in schedules.Values)
            {
                foreach (Subject teacherSubject in list)
                {
                    if (teacherSubject.teacherName == nameTeacher)
                    {
                        d++;
                    }
                }
            }

            return d;
            //void Console.WriteLine(d);
        }

        public void ReplaceTeacher(string teacher, string replaceTeacher)
        {

            foreach (List<Subject> teacherList in schedules.Values)
            {
                foreach (Subject teachers in teacherList)
                {
                    if (teachers.teacherName == teacher)
                    {
                        teachers.teacherName = replaceTeacher;
                    }
                }
            }
        }

        //Удаление учителя с расписания
        public void ClearTeacher(string teacher)
        {

            foreach (List<Subject> teachers in schedules.Values)
            {
                for (int i = 0; i < teachers.Count; i++)
                {
                    if (teachers[i].teacherName == teacher)
                    {
                        teachers.Remove(teachers[i]);
                        i--;
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