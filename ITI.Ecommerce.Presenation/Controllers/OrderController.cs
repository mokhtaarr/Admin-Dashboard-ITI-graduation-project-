using DTOs;
using ITI.Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace ITI.Ecommerce.Presenation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IPaymentService _paymentService;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderController(IOrderService orderService , ICustomerService customerService,
                               IPaymentService paymentService, IShoppingCartService shoppingCartService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _paymentService = paymentService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var Customers = await _customerService.GetAll();
            ViewBag.Customer = Customers.Select(i => new SelectListItem(i.FullName, i.ID.ToString()));

            var Payments = await _paymentService.GetAll();
            ViewBag.Payment = Payments.Select(i => new SelectListItem(i.ID.ToString(), i.ID.ToString()));

            var ShoppingCarts = await _shoppingCartService.GetAll();
            ViewBag.ShoppingCart = ShoppingCarts.Select(i => new SelectListItem(i.ID.ToString(), i.ID.ToString()));
            return View();
        }
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            await _orderService.add(orderDto);
            return RedirectToAction("GetAllOrders");
        }

        public async Task<IActionResult> GetAllOrders()
        {
            var Orders = await _orderService.GetAll();
            return View(Orders);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrderyByID()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetOrderyByID(int ID)
        {
            var Order = await _orderService.GetById(ID);
            ViewBag.Done = true;
            return View(Order);
        }

        //public IActionResult Delete(OrderDto orderDto)
        //{
        //    _orderService.Delete(orderDto);
        //    return View();
        //}

        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("GetAllOrders");
        }
        [HttpGet]
        public async Task<IActionResult> UpDate(int id)
        {
            var order = await _orderService.GetById(id);

            var Customers = await _customerService.GetAll();
            ViewBag.Customer = Customers.Select(i => new SelectListItem(i.FullName, i.ID.ToString()));

            var Payments = await _paymentService.GetAll();
            ViewBag.Payment = Payments.Select(i => new SelectListItem(i.ID.ToString(), i.ID.ToString()));

            var ShoppingCarts = await _shoppingCartService.GetAll();
            ViewBag.ShoppingCart = ShoppingCarts.Select(i => new SelectListItem(i.ID.ToString(), i.ID.ToString()));

            return View(order);
        }
        [HttpPost]
        public IActionResult UpDate(OrderDto orderDto)
        {
            _orderService.Update(orderDto);
            return RedirectToAction("GetAllOrders");
        }
        

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

    }
}
