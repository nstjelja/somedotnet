using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Apsis.TenPinBowling.Simulator.DTO
{
   
    [DataContract]
    public class ScoringResponseDTO
    {
        #region Properties
        [DataMember]
        public bool IsError { get; set; }

        [DataMember]
        public List<String> Messages {get;set;}

        [DataMember]
        public int Score { get; set; }
        #endregion Properties
    }
}