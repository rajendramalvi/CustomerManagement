using BusinessLogicLayer.CommonMethod;
using BusinessLogicLayer.IService;
using BusinessObjectModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CustomerService : ICustomerService
    {
        public const string BASEURL = "https://getinvoices.azurewebsites.net/api/";
        public const string CUSTOMER = "Customer";

        public List<Customer> GetAllCustomer()
            => new CommonMethods<Customer>().CallApi<List<Customer>>($"{BASEURL}{CUSTOMER}s", HttpMethod.Get);

        public Customer GetCustomer(int id)
            => new CommonMethods<Customer>().CallApi<Customer>($"{BASEURL}{CUSTOMER}/{id}", HttpMethod.Get);

        public void Insert(Customer objCustomer)
            => new CommonMethods<Customer>().CallApi<Customer>($"{BASEURL}{CUSTOMER}", HttpMethod.Post, objCustomer);

        public void Update(Customer objCustomer)
            => new CommonMethods<Customer>().CallApi<Customer>($"{BASEURL}{CUSTOMER}/{objCustomer.id}", HttpMethod.Post, objCustomer);

        public void Delete(int id)
            => new CommonMethods<Customer>().CallApi<Customer>($"{BASEURL}{CUSTOMER}/{id}", HttpMethod.Delete);
    }
}
