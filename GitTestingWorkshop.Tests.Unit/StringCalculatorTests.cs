using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace GitTestingWorkshop.Tests.Unit
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_GivenNoNumbers_ReturnsZero()
        {
            AssertSum("", 0);
        }

        [TestMethod]
        public void Add_GivenOneNumber_ReturnsTheNumber()
        {
            AssertSum("1", 1);
        }

        [TestMethod]
        public void Add_GivenTwoNumber_ReturnsTheSum()
        {
            AssertSum("1,2", 3);
        }

        [TestMethod]
        public void Add_GivenManyNumbers_ReturnsTheSum()
        {
            AssertSum("1,2,3,4,5", 15);
        }

        private class RecordTest
        {
            public string ID { get; set; }
            public string Title { get; set; }
            public DateTime? Date { get; set; }
            public Guid? Guid { get; set; }
            public string[] Properties { get; set; }

        }

        [TestMethod]
        public void GetJson_GivenObjectWithNulledProperties_ReturnsValidJsonWithNoNulledProperties()
        {
            var calc = new StringCalculator();
            var pinky = new RecordTest
            {
                ID = "1",
                Title = "And his fellow Brain.",
                Date = null,
                Guid = null
            };

            var result = calc.GetJson(pinky);
            result.ShouldBe("{\"ID\":\"1\",\"Title\":\"And his fellow Brain.\"}");
        }

        private static void AssertSum(string numbers, int expected)
        {
            var calc = new StringCalculator();
            var result = calc.Add(numbers);
            result.ShouldBe(expected);
        }
    }
}
