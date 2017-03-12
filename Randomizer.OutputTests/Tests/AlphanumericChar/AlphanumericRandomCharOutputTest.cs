﻿using System.Globalization;
using System.Linq;
using Randomizer.Interfaces.ReferenceTypes;

namespace Randomizer.OutputTests.Tests.AlphanumericChar
{
    public class AlphanumericRandomCharOutputTest : AlphanumericCharOutputTest
    {
        public AlphanumericRandomCharOutputTest(IRandomCharacter randomCharacter, ILogger fileLogger)
            : base(randomCharacter, fileLogger)
        {
        }
        
        public override void PerformTest(params char[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                char randomValue = randomCharacter.GenerateValue();
                var randomArrayValues = new string(new[] { randomValue });
                if (randomArrayValues.Any(char.IsLetter) == false && randomArrayValues.Any(char.IsDigit) == false)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}