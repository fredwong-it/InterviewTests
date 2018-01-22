using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        GraduationTracker _tracker = new GraduationTracker();
        Diploma _diploma;
        Student[] _students;
        List<Tuple<int, bool, STANDING>> _graduated;

        [TestInitialize()]
        public void Initialize()
        {
            _diploma = Repository.GetDiploma(1);
            _students = Repository.GetStudents();
            _graduated = new List<Tuple<int, bool, STANDING>>();
        }

        private void CalculateGraduated()
        {
            foreach (var student in _students)
            {
                _graduated.Add(_tracker.HasGraduated(_diploma, student));
            }
        }

        [TestMethod]
        //public void TestHasCredits()
        public void Graduate_Count_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(3, _graduated.Count(o => o.Item2 == true));
        }

        [TestMethod]
        public void Failed_Count_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(2, _graduated.Count(o => o.Item2 == false));
        }

        [TestMethod]
        public void Graduate_SumaCumLaude_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(_students[0].Id, _graduated.FirstOrDefault(o => o.Item2 == true && o.Item3 == STANDING.SumaCumLaude).Item1);
        }

        [TestMethod]
        public void Graduate_MagnaCumLaude_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(_students[1].Id, _graduated.FirstOrDefault(o => o.Item2 == true && o.Item3 == STANDING.MagnaCumLaude).Item1);
        }

        [TestMethod]
        public void Graduate_Average_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(_students[2].Id, _graduated.FirstOrDefault(o => o.Item2 == true && o.Item3 == STANDING.Average).Item1);
        }

        [TestMethod]
        public void Failed_Remedial_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(_students[3].Id, _graduated.FirstOrDefault(o => o.Item2 == false && o.Item3 == STANDING.Remedial).Item1);
        }

        [TestMethod]
        public void Failed_MagnaCumLaude_Test()
        {
            CalculateGraduated();

            Assert.AreEqual(_students[4].Id, _graduated.FirstOrDefault(o => o.Item2 == false && o.Item3 == STANDING.MagnaCumLaude).Item1);
        }
    }
}
