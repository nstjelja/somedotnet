using Apsis.TenPinBowling.Simulator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apsis.TenPinBowling.Simulator.Domain.Service
{
    public class BonusRollsFetchService
    {
        public Tuple<int, int> GetMeBonusRollsForScoring(ScoreCard scoreCard, Frame fromMe)
        {
            if (scoreCard.Frames == null)
                scoreCard.Frames = new List<Frame>();

            if (scoreCard.Frames.Count == 0)
                return new Tuple<int, int>(0, 0);

            if (fromMe.IsOpen)
                return new Tuple<int, int>(0, 0);

            var myPosition = scoreCard.Frames.IndexOf(fromMe);


            //Handle spare logic
            if (fromMe.IsSpare)
            {
                var nextRolledFrame = scoreCard.Frames.ElementAtOrDefault(myPosition + 1);

                if (nextRolledFrame == null) nextRolledFrame = new Frame();

                return new Tuple<int, int>(nextRolledFrame.First, 0);
            }

            //Handle strike logic
            var firstNextRolledFrame = scoreCard.Frames.ElementAtOrDefault(myPosition + 1);

            if (firstNextRolledFrame == null)
                firstNextRolledFrame = new Frame();

            if (!firstNextRolledFrame.IsStrike)
            {
                return new Tuple<int, int>(firstNextRolledFrame.First, firstNextRolledFrame.Second);
            }

            var secondNextRolledFrame = scoreCard.Frames.ElementAtOrDefault(myPosition + 2);

            if (secondNextRolledFrame == null) secondNextRolledFrame = new Frame();


            return new Tuple<int, int>(firstNextRolledFrame.First, secondNextRolledFrame.First);


        }
    }
}
