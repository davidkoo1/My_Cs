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
            new Subject {subjectName = "Физика"},
            new Subject {subjectName = "История"},
            new Subject {subjectName = "Математика"},
            new Subject {subjectName = "Биология"},
            new Subject {subjectName = "География"},
            new Subject {subjectName = "СПОРТ"},
            new Subject {subjectName = "Химия"}

        };
         sh1.schedules.Add(DayOfWeek.Monday, subjectsForMonday);

            //Уроки для вторника 
            List<Subject> subjectsForTuesday = new List<Subject>
        {
           
            new Subject {subjectName = "Биология"},
            new Subject {subjectName = "География"},
            new Subject {subjectName = "СПОРТ"},
            new Subject {subjectName = "Химия"}

        };
            sh1.schedules.Add(DayOfWeek.Tuesday, subjectsForTuesday);



            //Уроки для среды 
            List<Subject> subjectsForWednesday = new List<Subject>
        {
           
            new Subject {subjectName = "Физика"},
            new Subject {subjectName = "История"},
            new Subject {subjectName = "Математика"}

        };
            sh1.schedules.Add(DayOfWeek.Wednesday, subjectsForWednesday);
            


            //Уроки для четверга 
            List<Subject> subjectsForThursday = new List<Subject>
        {

            new Subject {subjectName = "Биология"},
            new Subject {subjectName = "География"},
            new Subject {subjectName = "СПОРТ"},
            new Subject {subjectName = "Химия"}

        };
            sh1.schedules.Add(DayOfWeek.Thursday, subjectsForThursday);


            //Уроки для пятницы
            List<Subject> subjectsForFriday = new List<Subject>
        {
            new Subject {subjectName = "Физика"},
            new Subject {subjectName = "История"},
            new Subject {subjectName = "Математика"},
            new Subject {subjectName = "Химия"}

        };
            
            sh1.schedules.Add(DayOfWeek.Friday, subjectsForFriday);



            //Уроки для субботы
            List<Subject> subjectsForSaturday = new List<Subject>
        {
            new Subject {subjectName = "Физика"},
            new Subject {subjectName = "Химия"}

        };

            sh1.schedules.Add(DayOfWeek.Saturday, subjectsForSaturday);

            //Уроки для воскресенье
            List<Subject> subjectsForSunday = new List<Subject>
        {
            new Subject {subjectName = "Информатика"},
            new Subject {subjectName = "Рисование"},
            new Subject {subjectName = "DMSV"}

        };

            sh1.schedules.Add(DayOfWeek.Sunday, subjectsForSunday);

            sh1.PrintDayInfo(DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday);
            /*
            FileControl.SerializeToFile(sh1, output);
            */
            
        }
    }
}
