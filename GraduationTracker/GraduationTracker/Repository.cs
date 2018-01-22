using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Repository
    {
        public static Student GetStudent(int id)
        {
            var students = GetStudents();
            Student student  = students.FirstOrDefault(o => o.Id == id);
            //Student student = null;
            
            //for (int i = 0; i < students.Length; i++)
            //{
            //    if (id == students[i].Id)
            //    {
            //        student = students[i];
            //    }
            //}
            return student;
        }

        public static Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            Diploma diploma = diplomas.FirstOrDefault(o => o.Id == id);
            //Diploma diploma = null;

            //for (int i = 0; i < diplomas.Length; i++)
            //{
            //    if (id == diplomas[i].Id)
            //    {
            //        diploma = diplomas[i];
            //    }
            //}
            return diploma;

        }

        public static Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            Requirement requirement = requirements.FirstOrDefault(o => o.Id == id);
            //Requirement requirement = null;

            //for (int i = 0; i < requirements.Length; i++)
            //{
            //    if (id == requirements[i].Id)
            //    {
            //        requirement = requirements[i];
            //    }
            //}
            return requirement;
        }

        public static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Credits = 4,
                    Requirements = new int[]{100,102,103,104}
                }
            };
        }

        public static Requirement[] GetRequirements()
        {   
            return new[]
            {
                new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
                new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
                new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
                new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
            };
        }
        public static Student[] GetStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                },
                new Student
                {
                    Id = 5,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=100 },
                        new Course{Id = 2, Name = "Science", Mark=100 },
                        new Course{Id = 3, Name = "Literature", Mark=49 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=100 }
                    }
                }
            };
        }

        static public STANDING GetSTANDING(double average)
        {
            var standing = STANDING.None;

            if (average < 50)
            {
                standing = STANDING.Remedial;
            }
            else if (average < 80)
            {
                standing = STANDING.Average;
            }
            else if (average < 95)
            {
                standing = STANDING.MagnaCumLaude;
            }
            else
            {
                standing = STANDING.SumaCumLaude;
            }

            return standing;
        }
    }


}
