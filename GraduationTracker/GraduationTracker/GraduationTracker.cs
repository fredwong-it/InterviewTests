using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<int, bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            // this implementation is n^3 in Big O
            //var creditsOld = 0;
            //var averageOld = 0;
        
            //for(int i = 0; i < diploma.Requirements.Length; i++)
            //{
            //    for(int j = 0; j < student.Courses.Length; j++)
            //    {
            //        var requirement = Repository.GetRequirement(diploma.Requirements[i]);

            //        for (int k = 0; k < requirement.Courses.Length; k++)
            //        {
            //            if (requirement.Courses[k] == student.Courses[j].Id)
            //            {
            //                averageOld += student.Courses[j].Mark;
            //                if (student.Courses[j].Mark >= requirement.MinimumMark)
            //                {
            //                    creditsOld += requirement.Credits;
            //                }
            //            }
            //        }
            //    }
            //}

            //averageOld = averageOld / student.Courses.Length;

            int credits = 0;
            double average = 0;

            // calculate credit
            var requirements = Repository.GetRequirements();

            // loop all courses in a student
            foreach (Course course in student.Courses)
            {
                // assume 1 to 1 relationship for course and requirement although Requirement got the Course array
                // it didn't make sense to me for a course with many different requirement
                // unless a course with different requirement based on different diploma
                // but I assume 1 to 1 relationship based on the predefined data

                // find the requirement from the course
                var requirement = requirements.FirstOrDefault(o => o.Courses[0] == course.Id);

                // check if the requirement is under the diploma
                if (diploma.Requirements.Contains(requirement.Id))
                {
                    // check if the course mark higher than requirement minimum mark
                    if (course.Mark >= requirement.MinimumMark)
                    {
                        credits += requirement.Credits;
                    }
                }
            }

            // calculate average
            average = student.Courses.Average(o => o.Mark);

            // credits need to be larger or equal to diploma.Credits in order to graduate
            bool graduate = credits >= diploma.Credits;
            STANDING standing = Repository.GetSTANDING(average);

            return new Tuple<int, bool, STANDING>(student.Id, graduate, standing);
        }

        
    }
}
