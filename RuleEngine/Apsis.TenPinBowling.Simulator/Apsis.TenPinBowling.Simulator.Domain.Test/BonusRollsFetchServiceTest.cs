using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apsis.TenPinBowling.Simulator.Domain.Entity;
using Apsis.TenPinBowling.Simulator.Domain.Service;

namespace Apsis.TenPinBowling.Simulator.Domain.Test
{
    [TestClass]
    public class BonusRollsFetchServiceTest
    {
        [TestMethod]
        public void NoBonusBalls()
        {
            var frame =  new Frame(10,0);

            var scoreCard = new ScoreCard()
            {
                Frames = new System.Collections.Generic.List<Frame>(){
                    frame
                }
            };

            var service = new BonusRollsFetchService();
            var bonusBalls = service.GetMeBonusRollsForScoring(scoreCard, frame);

            Assert.IsNotNull(bonusBalls);
            Assert.AreEqual(0, bonusBalls.Item1);
            Assert.AreEqual(0, bonusBalls.Item2);
        }

        [TestMethod]
        public void FrameIsStike_FirstFrameExists_And_IsStrike_NoSecondFrame() {
            var frame = new Frame(10,0);
            var firstFrame = new Frame(10,0);

            var scoreCard = new ScoreCard()
            {
                Frames = new System.Collections.Generic.List<Frame>(){
                    frame,
                    firstFrame
                }
            };

            var service = new BonusRollsFetchService();
            var bonusBalls = service.GetMeBonusRollsForScoring(scoreCard, frame);

            Assert.IsNotNull(bonusBalls);
            Assert.AreEqual(10, bonusBalls.Item1);
            Assert.AreEqual(0, bonusBalls.Item2);
        
        }

        [TestMethod]
        public void FrameIsStike_FirstFrameExists_And_IsStrike_SecondFrameExists() 
        {
            var frame = new Frame(10,0);
            var firstFrame = new Frame(10,0);
            var secondFrame = new Frame(10,0);

            var scoreCard = new ScoreCard()
            {
                Frames = new System.Collections.Generic.List<Frame>(){
                    frame,
                    firstFrame,
                    secondFrame
                }
            };

            var service = new BonusRollsFetchService();
            var bonusBalls = service.GetMeBonusRollsForScoring(scoreCard, frame);

            Assert.IsNotNull(bonusBalls);
            Assert.AreEqual(10, bonusBalls.Item1);
            Assert.AreEqual(10, bonusBalls.Item2);
        }

        [TestMethod]
        public void FrameIsStike_FirstFrameExists_And_IsSpare()
        {
            var frame = new Frame(10,0);
            var firstFrame = new Frame(6,4);
            var scoreCard = new ScoreCard()
            {
                Frames = new System.Collections.Generic.List<Frame>(){
                    frame,
                    firstFrame
                }
            };

            var service = new BonusRollsFetchService();
            var bonusBalls = service.GetMeBonusRollsForScoring(scoreCard, frame);

            Assert.IsNotNull(bonusBalls);
            Assert.AreEqual(6, bonusBalls.Item1);
            Assert.AreEqual(4, bonusBalls.Item2);
        }

        [TestMethod]
        public void FrameIsSpare_FirstFrameDoesntExists() {
            var frame = new Frame(9,2);
           
            var scoreCard = new ScoreCard()
            {
                Frames = new System.Collections.Generic.List<Frame>(){
                    frame
                }
            };

            var service = new BonusRollsFetchService();
            var bonusBalls = service.GetMeBonusRollsForScoring(scoreCard, frame);

            Assert.IsNotNull(bonusBalls);
            Assert.AreEqual(0, bonusBalls.Item1);
            Assert.AreEqual(0, bonusBalls.Item2);
        
        }

        [TestMethod]
        public void FrameIsSpare_FirstFrameExists() {
            var frame = new Frame(6,4);
            var firstFrame = new Frame(5,4);

            var scoreCard = new ScoreCard()
            {
                Frames = new System.Collections.Generic.List<Frame>(){
                    frame,
                    firstFrame
                }
            };

            var service = new BonusRollsFetchService();
            var bonusBalls = service.GetMeBonusRollsForScoring(scoreCard, frame);

            Assert.IsNotNull(bonusBalls);
            Assert.AreEqual(5, bonusBalls.Item1);
            Assert.AreEqual(0, bonusBalls.Item2);
        }
    }
}
