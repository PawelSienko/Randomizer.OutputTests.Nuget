﻿using System.Globalization;
using Randomizer.Interfaces.ValueTypes;
using Randomizer.OutputTests.Base;

namespace Randomizer.OutputTests.Tests.Integer
{
    public class IntegerPositiveValueOutputTest : OutputTestBase<int>
    {
        // ReSharper disable once InconsistentNaming
        private readonly IRandomInteger randomInteger;
        public IntegerPositiveValueOutputTest(IRandomInteger randomInteger, ILogger logger)
            : base(logger)
        {
            this.randomInteger = randomInteger;
        }

        public override void PerformTest(params int[] parameters)
        {
            for (int i = 0; i < ExecutionTimes; i++)
            {
                int randomValue = randomInteger.GeneratePositiveValue();
                if (randomValue < 0)
                {
                    WrongResults.Add(randomValue.ToString(CultureInfo.InvariantCulture));
                }
            }
            fileLogger.LogResult(WrongResults);
        }
    }
}