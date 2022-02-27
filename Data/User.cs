using System.ComponentModel.DataAnnotations;

namespace AlphabeticalNavigation.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
