using AlphabeticalNavigation.Data;
using AlphabeticalNavigation.Helpers;

namespace AlphabeticalNavigation.Models
{
    public class UsersListVM
    {
        public List<char> FirstLetters { get; set; }
        public List<User> Users { get; set; }
        public char CurrentLetter { get; set; }
        public Pagination Pagination { get; set; }
    }
}
