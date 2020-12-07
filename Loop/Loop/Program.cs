using System;
using System.Collections.Generic;

namespace Loop
{
    class Program
    {

        static void CustomerMeetingOptions()
        {
            Console.WriteLine("Enter 0 to join remote group meeting");
            Console.WriteLine("Enter 1 to exit");
        }

        static Customer AddCustomer(string name, string phoneNumber)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.PhoneNumber = phoneNumber;
            return customer;
        }

        static void Main(string[] args)
        {
            int optionNum;
            Boolean exitLoop = false;
            string customerName;
            string customerPhoneNumber;
            CustomerMenu menu = new CustomerMenu();
            List<Customer> customers = new List<Customer>();
            CustomerMeetingOptions();
            for (int i = 0; exitLoop != true; i++)
            {
                try
                {
                    optionNum = Int16.Parse(Console.ReadLine());
                    switch (optionNum)
                    {
                        case 0:
                            // input customer name
                            Console.WriteLine("Please enter name to join");
                            customerName = String.Format("{0}", Console.ReadLine());
                            // phone number input: +441339612345 output: 01339 612345
                            Console.WriteLine("Please enter phone number to join");
                            customerPhoneNumber = String.Format("{0}", Console.ReadLine());
                            customers.Add(AddCustomer(customerName, customerPhoneNumber));

                            break;
                        case 1:

                            Console.WriteLine("Are you sure you would like to exit enter Y to exit and N to continue");
                            char exitOption = Char.Parse(Console.ReadLine());
                            if (Char.ToUpper(exitOption) == 'Y')
                            {
                                exitLoop = true;
                            }
                            else if (Char.ToUpper(exitOption) != 'N')
                            {
                                throw new Exception("Only characters accepted are Y and N");
                            }

                            break;
                        default:
                            Console.WriteLine("Please enter a valid option from the list");
                            CustomerMeetingOptions();
                            break;
                    }

                    menu.AddCustomer(customers);
                    menu.DisplayCustomerMenu();
                    CustomerMeetingOptions();
                } catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

    }
}
