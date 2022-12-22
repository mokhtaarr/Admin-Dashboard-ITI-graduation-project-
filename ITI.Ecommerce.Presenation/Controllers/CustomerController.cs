using Microsoft.AspNetCore.Mvc;
using DTOs;
using ITI.Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ITI.Ecommerce.Presenation.Controllers
{
   //[Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
       public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            //List<CustomerDto> li=new List<CustomerDto>();
            var User = await _customerService.GetAll();
            // CustomerDto dto = new CustomerDto()
            // {
            //     NameAR = "احمد",
            //     NameEN = "Ahmed",
            //     FullName = "ahmed ali",
            //     Address = "sohage",
            //     Email = "ahmed@gmail",
            //     MobileNumber = "12020920"
            // };
            // li.Add(dto);
            //await  _customerService.GetAll();
            return View(User);
        }

       [HttpGet]



        public async Task<IActionResult> UpdateUser(string ID)
        {
            var User = await _customerService.GetById(ID);

            return View(User);
        }
        [HttpPost]
        public IActionResult UpdateUser(CustomerDto customerDto)
        {
              _customerService.Update(customerDto);

            return RedirectToAction("GetAllUser","Customer");
        }
        //[Route("{ID:Guid}")]
      
        public IActionResult Delete(string ID)
        {
            _customerService.Delete(ID);

            return RedirectToAction("GetAllUser", "Customer");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUserDeleted()
        {
            //List<CustomerDto> li=new List<CustomerDto>();
            var User = await _customerService.GetAllDeleted();
            // CustomerDto dto = new CustomerDto()
            // {
            //     NameAR = "احمد",
            //     NameEN = "Ahmed",
            //     FullName = "ahmed ali",
            //     Address = "sohage",
            //     Email = "ahmed@gmail",
            //     MobileNumber = "12020920"
            // };
            // li.Add(dto);
            //await  _customerService.GetAll();
            return View(User);
        }

        public async Task<IActionResult> Restore(string ID)
        {
            _customerService.Restore(ID);

            return RedirectToAction("GetAllUserDeleted", "Customer");

        }

    }
}
