using Apsis.TenPinBowling.Simulator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsis.TenPinBowling.Simulator.Domain.Service
{
    public class ScoringService
    {
        public void Score(ScoreCard scoreCard) {
            if (scoreCard == null)
                throw new ArgumentNullException("Score card must not be null");

            if (scoreCard.Frames == null)
                scoreCard.Frames = new List<Frame>();

            var bonusRollsFetchService = new BonusRollsFetchService();

            scoreCard.Frames.ForEach(frame => {
                if (scoreCard.Frames.IndexOf(frame) > 9)
                    return;

                var bonusRolls = bonusRollsFetchService.GetMeBonusRollsForScoring(scoreCard, frame);

                frame.BonusFirst = bonusRolls.Item1;
                frame.BonusSecond = bonusRolls.Item2;

                scoreCard.Score += frame.Score;
            });
        }

        
    }
}
