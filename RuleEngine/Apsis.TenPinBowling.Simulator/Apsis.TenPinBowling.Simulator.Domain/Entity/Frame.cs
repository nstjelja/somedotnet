using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Apsis.TenPinBowling.Simulator.Domain.Entity{

    [DataContract]
    [CustomValidation(typeof(Frame), "MaxPinValidation")]
    public class Frame
    {
        #region Constructor
        public Frame(int first, int second) {
            First = first;
            Second = second;
        }

        public Frame() { }
        #endregion Constructor


        #region Properties
        public int First {get;set;}
        public int Second {get;set;}
        public int BonusFirst {get;set;}
        public int BonusSecond {get;set;}
       
        public int Score {
            get{
                return First + Second + BonusFirst + BonusSecond;
            }
        }

        public bool IsStrike {
            get {
                return First == 10;
            }
        }

        public bool IsSpare {
            get {
                return First != 10 & ((First + Second )== 10);
            }
        }

        public bool IsOpen {
            get {
                return (First + Second) < 10;
            }
        }
        #endregion Properties

        #region Methods
        public static ValidationResult MaxPinValidation(Frame frame, ValidationContext context) {
            if ((frame.First + frame.Second) <= 10)
                return ValidationResult.Success;

            return new ValidationResult("The sum of all thrown pins must not exceed 10");
        }
        #endregion Methods
    }
}
