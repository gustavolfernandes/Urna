using System.ComponentModel.DataAnnotations;

namespace Urna.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
