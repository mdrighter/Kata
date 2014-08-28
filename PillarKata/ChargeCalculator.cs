using System;

namespace PillarKata
{
    public class ChargeCalculator
    {
        public int ValuateHours(string startTime, string bedTime, string endTime)
        {
            var accruedCharge = 0;
            var midnight = DateTime.Parse("8/28/2014 00:00");
            var dtCurrentHour = DateTime.Parse(startTime);
            var dtBedTime = bedTime == "" ? DateTime.MinValue : DateTime.Parse(bedTime);       
            var dtEndTime = DateTime.Parse(endTime);
            
            //If a value exists for bedtime, assign the appropriate hourly rate by iterating through
            //the hours worked.
            if (dtBedTime != DateTime.MinValue)
            {
                while (dtCurrentHour < dtEndTime)
                {
                    if (dtCurrentHour < dtBedTime && dtCurrentHour < midnight)
                    {
                        accruedCharge += 12;
                    }
                    else if (dtCurrentHour >= dtBedTime && dtCurrentHour < midnight)
                    {
                        accruedCharge += 8;
                    }       
                    else if (dtCurrentHour > dtBedTime && dtCurrentHour >= midnight)
                    {
                        accruedCharge += 16;
                    }
                    else if (dtCurrentHour <= dtBedTime && dtCurrentHour >= midnight)
                    {
                        accruedCharge += 16;
                    }

                    dtCurrentHour = dtCurrentHour.AddHours(1);
                }
            }
            else
            {
                //If no value for bedtime exists (because they're a cool babysitter), assign the 
                //appropriate hourly rate by iterating through the hours worked ignoring the rate
                //change for post-bedtime hours.
                while (dtCurrentHour < dtEndTime)
                {
                    if (dtCurrentHour < midnight)
                        accruedCharge += 12;
                    else
                    {
                        accruedCharge += 16;
                    }

                    dtCurrentHour = dtCurrentHour.AddHours(1);
                }
            }

            return accruedCharge;
        }
    }
}