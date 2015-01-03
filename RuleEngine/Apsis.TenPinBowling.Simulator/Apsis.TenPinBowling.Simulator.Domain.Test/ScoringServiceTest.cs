using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apsis.TenPinBowling.Simulator.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using Apsis.TenPinBowling.Simulator.Domain.Service;

namespace Apsis.TenPinBowling.Simulator.Domain.Test
{
    [TestClass]
    public class ScoringServiceTest
    {
        [TestMethod]
        public void RandomGameScore()
        {
            var scoreCard = new ScoreCard();
            scoreCard.Frames = new List<Frame>(){
                new Frame(7,2),
                new Frame(10,0),
                new Frame(9,0),
                new Frame(0,3),
                new Frame(8,2), 
                new Frame(7,3), 
                new Frame(8,1), 
                new Frame(4,5), 
                new Frame(0,7), 
                new Frame(10,0), 
                new Frame(6,4)
            };

            var scoringService = new ScoringService();
            scoringService.Score(scoreCard);

            Assert.AreEqual(120, scoreCard.Score);
        }

        [TestMethod]
        public void PerfectGameScore()
        {
            var scoreCard = new ScoreCard();
            scoreCard.Frames = new List<Frame>(){
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
                 new Frame(10,0),
            };

            var scoringService = new ScoringService();
            scoringService.Score(scoreCard);

            Assert.AreEqual(300, scoreCard.Score);
        }
    }
}
