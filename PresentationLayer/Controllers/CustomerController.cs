using BusinessLogicLayer.IService;
using BusinessObjectModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
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

        public IActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Get all customers details from the API.
        /// </summary>
        /// <returns>list of all customers details.</returns>
        [HttpGet]
        public JsonResult GetCustomers()
            => Json(_customerService.GetAllCustomer());

        /// <summary>
        /// Get customer details from the API.
        /// </summary>
        /// <returns>customer details.</returns>
        [HttpGet]
        public JsonResult GetCustomer(int id)
            => Json(_customerService.GetCustomer(id));

        /// <summary>
        /// Create a new customer by using the API.
        /// </summary>
        /// <returns>List of all employees</returns>
        [HttpPost]
        public JsonResult CreateCustomer(Customer customer)
        {
            customer.eTag = new ETag();
            _customerService.Insert(customer);
            return Json(_customerService.GetAllCustomer());
        }

        /// <summary>
        /// Updates an existing Customer by using the API.
        /// </summary>
        /// <returns>List of all employees</returns>
        [HttpPost]
        public JsonResult UpdateCustomer(Customer objCustomer)
        {
            objCustomer.eTag = new ETag();
            _customerService.Update(objCustomer);
            return Json(_customerService.GetAllCustomer());
        }

        /// <summary>
        ///Removes an existing Customer from the API.
        /// </summary>
        /// <returns>customer details.</returns>
        [HttpDelete]
        public JsonResult DeleteCustomer(int id)
        {
            _customerService.Delete(id);
            return Json(_customerService.GetAllCustomer());
        }
    }
}
