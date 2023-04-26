using System;
using System.Collections.Generic;

class Customer
{
    public string firstName;
    public string lastName;
    public string phone;
    public string village;
    public string taluk;
    public string id;

    // constructor to initialize values
    public Customer(string fName, string lName, string phoneNum, string villageName, string talukName, string custID)
    {
        firstName = fName;
        lastName = lName;
        phone = phoneNum;
        village = villageName;
        taluk = talukName;
        id = custID;
    }
}

class BankExecutive
{
    static void Main(string[] args)
    {
        List<Customer> customers = new List<Customer>();

        // loop to enter customer details
        while (true)
        {
            Console.WriteLine("Enter customer details:");
            Console.Write("First Name: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lName = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNum = Console.ReadLine();
            Console.Write("Village: ");
            string villageName = Console.ReadLine();
            Console.Write("Taluk: ");
            string talukName = Console.ReadLine();

            // check if phone number is valid
            if (phoneNum.Length != 10)
            {
                Console.WriteLine("Invalid phone number");
                return;
            }

            // generate customer ID
            string custID = Guid.NewGuid().ToString();

            Customer customer = new Customer(fName, lName, phoneNum, villageName, talukName, custID);
            customers.Add(customer);

            Console.WriteLine("Customer added successfully.");

            // ask if user wants to add another customer
            Console.Write("Do you want to add another customer? (Y/N): ");
            string choice = Console.ReadLine().ToLower();

            if (choice != "y")
            {
                break;
            }
        }

        // display details of a particular customer by last name
        Console.Write("Enter last name of customer to display details: ");
        string lastName = Console.ReadLine();

        foreach (Customer cust in customers)
        {
            if (cust.lastName.ToLower() == lastName.ToLower())
            {
                Console.WriteLine("Customer ID: " + cust.id);
                Console.WriteLine("First Name: " + cust.firstName);
                Console.WriteLine("Last Name: " + cust.lastName);
                Console.WriteLine("Phone Number: " + cust.phone);
                Console.WriteLine("Village: " + cust.village);
                Console.WriteLine("Taluk: " + cust.taluk);
            }
        }

        // display list of customers belonging to a particular taluk or village in a tabular format
        Console.Write("Enter taluk or village name to display list of customers: ");
        string name = Console.ReadLine();

        Console.WriteLine("\nCustomers in " + name + ":\n");
        Console.WriteLine("Customer ID\t\t\t\t\tFirst Name\t\tLast Name\t\tPhone Number");

        foreach (Customer cust in customers)
        {
            if (cust.village.ToLower() == name.ToLower() || cust.taluk.ToLower() == name.ToLower())
            {
                Console.WriteLine(cust.id + "\t\t" + cust.firstName + "\t\t\t" + cust.lastName + "\t\t\t" + cust.phone);
            }
        }
    }
}