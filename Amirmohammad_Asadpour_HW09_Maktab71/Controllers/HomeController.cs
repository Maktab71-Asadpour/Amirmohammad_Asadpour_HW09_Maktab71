using Amirmohammad_Asadpour_HW09_Maktab71.Models;
using Amirmohammad_Asadpour_HW09_Maktab71.Models._02_Infrasrtructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Amirmohammad_Asadpour_HW09_Maktab71.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IRepository<Member> _repository;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = new MemberSqlRepository();
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Back()
        {
            return View("Index", _repository.GetAll());
        }

        public IActionResult Search(string searchTxt)
        {
            List<Member> searchedMembers = new List<Member>();

            if (String.IsNullOrEmpty(searchTxt))
            {
                searchedMembers = _repository.GetAll();
            }
            else
            {
                foreach (var item in _repository.GetAll())
                {
                    if (item.FirstName.Contains(searchTxt) || item.LastName.Contains(searchTxt))
                    {
                        searchedMembers.Add(item);
                    }
                }
            }

            return View("Index", searchedMembers);
        }

        public IActionResult AddMember()
        {
            return View();
        }
        
        public IActionResult SubmitAddedMember(Member member)
        {
            member.RegisterDate = DateTime.Now;
            _repository.Add(member);
            return View("Index", _repository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_repository.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        public IActionResult SubmitEditedMember(Member member)
        {
            _repository.Update(member);
            return View("Index", _repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            _repository.DeleteById(id);
            return View("Index", _repository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}