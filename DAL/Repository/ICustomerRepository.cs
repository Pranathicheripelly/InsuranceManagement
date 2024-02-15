using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    //This interface outlines the contract for interacting with a customer repository.
    public interface ICustomerRepository
    {
        // Create

        //This method, customerSaveChanges, is likely intended to save changes made to the customer data
        //in the underlying data store.
        int customerSAveChanges();
        //This method, GetCustomerByUserName, retrieves a customer based on their username.
        Customer GetCustomerByUserName(string userName);
        //This method, CreateCustomer, is used to create a new customer. It takes a Customer object as a parameter,
        //representing the new customer, and returns the created Customer object.
        Customer CreateCustomer(Customer customer);
       // This method, CustomerExistsEmail, checks if a customer with a specific email exists.It returns a
       // boolean indicating whether a customer with the specified email exists.
        bool CustomerExistsEmail(string Email);
        // Read

        //This method, GetCustomerById, retrieves a customer by their ID.
        Customer GetCustomerById(int customerId);
        //This method, GetAllCustomers, retrieves all customers and returns them as an enumerable collection.
        IEnumerable<Customer> GetAllCustomers();
        //This method, CustomerExists, checks if a customer with a specific username exists. It returns a boolean
        bool CustomerExists(string userName);
        // Update
        //It takes a Customer object with updated information as a parameter and returns the updated Customer object.
        Customer UpdateCustomer(Customer customer);
        //int GetCurrentCustomerId(string userName);
        // Delete

  //DeleteCustomer, is used to delete a customer by their ID. It takes a customer ID as a parameter and returns the deleted Customer object.
        Customer DeleteCustomer(int customerId);
        //This method, GetCustomerByUserNamePhone, retrieves a customer based on both username and phone number.
        Customer GetCustomerByUserNamePhone(string UserName, string PhoneNumber);

    }
}
