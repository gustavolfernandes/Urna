using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Urna.Domain.Entities
{
    public class Vote : BaseEntity 
    {
        public bool flag;

        public DateTime VoteDate { get; set; }

        public bool Nulo { get; set; }
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
