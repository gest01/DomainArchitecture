using System.ComponentModel.DataAnnotations;

namespace Example.Domain.Entities
{
    public class MyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
