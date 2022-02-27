using AlphabeticalNavigation.Data;
using AlphabeticalNavigation.Helpers;
using AlphabeticalNavigation.Models;

namespace AlphabeticalNavigation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<char> GetLastNamesFirstLetters()
        {
            return _context.Users.Select(name => name.LastName.Substring(0, 1))
                    .Distinct()
                    .Select(letter => letter.ToCharArray()[0])
                    .ToList();
        }

        public UserDetailsVM GetUserDetailsVM(int id, int page, char firstLetter)
        {
            var userDetailsVM = GetUsersVM(page, firstLetter);
            userDetailsVM.SelectedUser = userDetailsVM.Users.FirstOrDefault(user => user.Id == id);
            return userDetailsVM;
        }

        public UsersListVM GetUsersListVM(int page, char firstLetter)
        {
            return GetUsersVM(page, firstLetter);
        }

        private UserDetailsVM GetUsersVM(int page, char firstLetter)
        {
            var pagination = new Pagination(page);
            var queryable = _context.Users.AsQueryable();
            var users = queryable
                .Where(name => name.LastName.StartsWith(firstLetter.ToString()))
                .OrderBy(name => name.LastName)
                .Paginate(pagination).ToList();
            return new UserDetailsVM()
            {
                Users = users,
                FirstLetters = GetLastNamesFirstLetters(),
                CurrentLetter = firstLetter,
                Pagination = pagination
            };
        }
    }
}
