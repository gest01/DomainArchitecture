using System.ComponentModel.DataAnnotations;

namespace Example.Application.DTO
{
    public class MyDemoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
