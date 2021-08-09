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

    
    class main
    {
        static void Main(string[] args)
        {
            string output = "output.dat";
            string input = @"C:\Users\sverc\OneDrive\Рабочий стол\irogi\CS\Exer9_1\Exer9_1\bin\Debug\net5.0\input.dat";

            Schedule sh1 = new Schedule();//FileControl.DeserializeFromFile(input);
            
            //Уроки для понедельника 
            List<Subject> subjectsForMonday = new List<Subject>
        {
            new Subject {subjectName = "Физика", teacherName = "Ирина"},
            new Subject {subjectName = "История", teacherName = "Виктория"},
            new Subject {subjectName = "Математика", teacherName = "Мария"},
            new Subject {subjectName = "Биология", teacherName = "Николай"},
            new Subject {subjectName = "География", teacherName = "Александр"},
            new Subject {subjectName = "СПОРТ", teacherName = "ЖИЗНЬ"},
            new Subject {subjectName = "Химия", teacherName = "КОТ"}

        };
         sh1.schedules.Add(DayOfWeek.Monday, subjectsForMonday);

            //Уроки для вторника 
            List<Subject> subjectsForTuesday = new List<Subject>
        {
           
            new Subject {subjectName = "Биология", teacherName = "Ирина"},
            new Subject {subjectName = "География", teacherName = "Александр"},
            new Subject {subjectName = "СПОРТ", teacherName = "ЖИЗНЬ"},
            new Subject {subjectName = "Химия", teacherName = "КОТ"}

        };
            sh1.schedules.Add(DayOfWeek.Tuesday, subjectsForTuesday);



            //Уроки для среды 
            List<Subject> subjectsForWednesday = new List<Subject>
        {
           
            new Subject {subjectName = "Физика", teacherName = "Ирина"},
            new Subject {subjectName = "История", teacherName = "Виктория"},
            new Subject {subjectName = "Математика", teacherName = "Мария"}

        };
            sh1.schedules.Add(DayOfWeek.Wednesday, subjectsForWednesday);
            


            //Уроки для четверга 
            List<Subject> subjectsForThursday = new List<Subject>
        {

            new Subject {subjectName = "Биология", teacherName = "Пётр"},
            new Subject {subjectName = "География", teacherName = "Антон"},
            new Subject {subjectName = "СПОРТ", teacherName = "Александр"},
            new Subject {subjectName = "Химия", teacherName = "Ирина"}

        };
            sh1.schedules.Add(DayOfWeek.Thursday, subjectsForThursday);


            //Уроки для пятницы
            List<Subject> subjectsForFriday = new List<Subject>
        {
            new Subject {subjectName = "Физика", teacherName = "КОТ"},
            new Subject {subjectName = "История", teacherName = "Виктория"},
            new Subject {subjectName = "Математика", teacherName = "Пётр"},
            new Subject {subjectName = "Химия", teacherName = "ЖИЗНЬ"}

        };
            
            sh1.schedules.Add(DayOfWeek.Friday, subjectsForFriday);



            //Уроки для субботы
            List<Subject> subjectsForSaturday = new List<Subject>
        {
            new Subject {subjectName = "Физика", teacherName = "Ирина"},
            new Subject {subjectName = "Химия", teacherName = "КОТ"}

        };

            sh1.schedules.Add(DayOfWeek.Saturday, subjectsForSaturday);

            //Уроки для воскресенье
            List<Subject> subjectsForSunday = new List<Subject>
        {
            new Subject {subjectName = "Информатика", teacherName = "Игорь"},
            new Subject {subjectName = "Рисование", teacherName = "Игорь"},
            new Subject {subjectName = "DMSV", teacherName = "Игорь"}

        };

            sh1.schedules.Add(DayOfWeek.Sunday, subjectsForSunday);

            sh1.PrintDayInfo(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday);
            /*
            FileControl.SerializeToFile(sh1, output);
            */
            
        }
    }
}
