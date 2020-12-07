using System;
using System.Collections.Generic;

namespace Loop
{
    public class CustomerMenu
    {
        List<Customer> customers;
        public void AddCustomer(List<Customer> customers)
        {
            this.customers = customers;
        }

        public void DisplayCustomerMenu()
        {
            foreach(var customer in this.customers)
            {
                Console.WriteLine("Details of all users joined");
                Console.WriteLine(customer.DisplayCustomerDetail());
            }
        }
    }
}
