using AlphabeticalNavigation.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlphabeticalNavigation.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.GetLastNamesFirstLetters());
        }

        public IActionResult UsersList(int page, char firstLetter)
        {
            return View(_repository.GetUsersListVM(page, firstLetter));
        }

        public IActionResult UserDetails(int id, int page, char firstLetter)
        {
            var userDetails = _repository.GetUserDetailsVM(id, page, firstLetter);
            if(userDetails.SelectedUser == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

    }
}
