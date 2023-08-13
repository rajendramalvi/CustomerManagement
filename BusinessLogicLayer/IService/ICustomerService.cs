using BusinessObjectModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List</returns>
        List<Customer> GetAllCustomer();

        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>object</returns>
        Customer GetCustomer(int id);

        /// <summary>
        /// Insert new Customer
        /// </summary>
        /// <param name="objCustomer">Customer model</param>
        void Insert(Customer objCustomer);

        /// <summary>
        /// Update existing Customer
        /// </summary>
        /// <param name="objCustomer">Customer model</param>
        void Update(Customer objCustomer);

        /// <summary>
        /// Delete existing record
        /// </summary>
        /// <param name="id">Customer Id</param>
        void Delete(int id);
    }
}
