using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apsis.TenPinBowling.Simulator.Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apsis.TenPinBowling.Simulator.Domain.Test
{
    [TestClass]
    public class ScoreCardTest
    {
        [TestMethod]
        public void TestNumbersAreValid()
        {
            var frames = new List<Frame>();
            var result = ScoreCard.ValidateFrames(frames, new ValidationContext(frames));

            Assert.AreNotEqual(ValidationResult.Success, result);

            frames.Add(new Frame());
            result = ScoreCard.ValidateFrames(frames, new ValidationContext(frames));

            Assert.AreNotEqual(ValidationResult.Success, result);

        }


        [TestMethod]
        public void WhenTenthIsStrike_AndEleventhIsNotStrike_TwelthMustNoBeSet()
        {
            var frames = new List<Frame>(){
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(),
                new Frame(10,0),
                new Frame(9,1),
                new Frame(10,0)
            };
            var result = ScoreCard.ValidateFrames(frames, new ValidationContext(frames));

            Assert.AreNotEqual(ValidationResult.Success, result);

            frames[11].First = 0;
            frames[11].Second = 0;

            result = ScoreCard.ValidateFrames(frames, new ValidationContext(frames));

            Assert.AreEqual(ValidationResult.Success, result);

        }
    }
}
