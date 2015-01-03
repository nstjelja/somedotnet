using Apsis.TenPinBowling.Simulator.Domain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Apsis.TenPinBowling.Simulator.Domain.Entity
{
    [DataContract]
    
    public class ScoreCard
    {
        #region Constructors
        public ScoreCard() {
            Frames = new List<Frame>();
        }
        #endregion Constructors

        #region Properties
        [CustomValidation(typeof(ScoreCard), "ValidateFrames")]
        public List<Frame> Frames { get; set; }
        public int Score { get; set; }
        #endregion Properties


        #region Validation
        public static ValidationResult ValidateFrames(List<Frame> frames, ValidationContext contect) {
         
            if (frames == null || frames.Count == 0)
                return new ValidationResult("No empty frames allowed");

            if (frames.Count != 12)
                return new ValidationResult("Max frame count is 12");

            var tenth = frames[9];
            var eleventh = frames[10];
            var twelth = frames[11];

            if (tenth.IsOpen)
                return ValidationResult.Success;

            if (tenth.IsStrike && !eleventh.IsStrike && !(twelth.First == 0 && twelth.Second == 0)) {
                return new ValidationResult("Twelth frame must not have values if the eleventh is not a strike");
            }

            if (tenth.IsSpare && eleventh.Second != 0) {
                return new ValidationResult("Eleventh frame must have only one roll registered is tenth is spare");
            }

            return ValidationResult.Success;
        }
        #endregion Validation

    }
}
