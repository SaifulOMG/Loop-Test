using System;
namespace Loop
{
    public class Customer
    {
        protected string _phoneNumber;
        public string Name
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string DisplayCustomerDetail()
        {
            RegionalAreaCode areaCode = new RegionalAreaCode();
            string readablePhoneNumber = areaCode.MatchUKAreaCode(PhoneNumber);
            return "Username: " + Name + " " + "Phone Number: " + readablePhoneNumber;
        }
    }
}
