using System;
using System.ComponentModel.DataAnnotations;

namespace Urna.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string ViceName { get; set; }
        public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Subtitle { get; set; }

        public Vote Vote { get; set; }
    }
}
