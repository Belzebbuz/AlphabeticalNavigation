using AlphabeticalNavigation.Models;

namespace AlphabeticalNavigation.Repositories
{
    public interface IUserRepository
    {
        List<char> GetLastNamesFirstLetters();
        UsersListVM GetUsersListVM(int page, char firstLetter);
        UserDetailsVM GetUserDetailsVM(int id, int page, char firstLetter);
    }
}
