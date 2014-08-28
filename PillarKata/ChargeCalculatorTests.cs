using NUnit.Framework;

namespace PillarKata
{
    [TestFixture]
    public class ChargeCalculatorTests
    {
        readonly ChargeCalculator _calculator = new ChargeCalculator();

        [TestCase("CalculateBedTimeBeforeMidnight", "8/27/2014 17:00", "8/27/2014 21:00", "8/28/2014 4:00", Result = 136)]
        [TestCase("CalculateBedTimeAfterMidnight", "8/27/2014 17:00", "8/28/2014 1:00", "8/28/2014 4:00", Result = 148)]
        [TestCase("CalculateNoBedTime", "8/27/2014 17:00", "", "8/28/2014 4:00", Result = 148)]
        [TestCase("CalculateStartAndEndBeforeMidnight", "8/27/2014 17:00", "8/27/2014 20:00", "8/27/2014 23:00", Result = 60)]
        [TestCase("CalculateStartAndEndAfterMidnight", "8/28/2014 1:00", "8/28/2014 3:00", "8/28/2014 4:00", Result = 48)]
        public int CalculateTime(string testCase, string startTime, string bedTime, string endTime)
        {
            return _calculator.ValuateHours(startTime, bedTime, endTime);
        }
    }
}
