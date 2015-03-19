using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly int someMiles = 5;
        private readonly DateTime startDate = new DateTime(2015, 1, 05);
        private readonly DateTime endDate = new DateTime(2015, 2, 05);

        [Test()]
        public void TestFlightInitializes()
        {
            var target = new Flight(startDate, endDate, someMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestFlightHasCorrectMiles()
        {
            var target = new Flight(startDate, endDate, 25);
            Assert.AreEqual(25, target.Miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFlightThrowsBadMiles()
        {
            new Flight(startDate, endDate, -5);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEndDateBeforeStartDate()
        {
            DateTime end = new DateTime(2015, 1, 05);
            DateTime start = new DateTime(2015, 2, 05);
            new Flight(start, end, 0);
        }

        [Test()]
        public void TestFlightEqualsOtherFlight()
        {
            var target = new Flight(startDate, endDate, 25);
            var other = new Flight(startDate, endDate, 25);
            Assert.AreEqual(target, other);
        }

        [Test()]
        public void TestFlightNotEqualsOtherFlight()
        {
            var target = new Flight(startDate, endDate, 25);
            DateTime end = new DateTime(2015, 2, 05);
            DateTime start = new DateTime(2015, 1, 05);
            var other = new Flight(start, end, 15);

            Assert.AreNotEqual(target, other);
        }

        [Test()]
        public void TestFlightsWithDifferentStartDays()
        {
            var target = new Flight(startDate, endDate, 25);
            DateTime start = new DateTime(2015, 1, 05);
            var other = new Flight(start, endDate, 15);
            Assert.AreNotEqual(target, other);
        }

        [Test()]
        public void TestFlightsWithDifferentEndDays()
        {
            var target = new Flight(startDate, endDate, 25);
            DateTime end = new DateTime(2015, 2, 05);
            var other = new Flight(startDate, end, 15);
            Assert.AreNotEqual(target, other);
        }

        [Test()]
        public void TestFlightsWithDifferentMiles()
        {
            var target = new Flight(startDate, endDate, 25);
            var other = new Flight(startDate, endDate, 15);
            Assert.AreNotEqual(target, other);
        }

	}
}
