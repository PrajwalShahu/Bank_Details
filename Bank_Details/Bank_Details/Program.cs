using System;
using System.Xml.Linq;

class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Taluka { get; set; }
    public string Village { get; set; }
    public string CustomerId { get; set; }
}

class GraminBank
{
    const int MAX_CUSTOMERS = 100;
    Customer[] customers = new Customer[MAX_CUSTOMERS];
    int numCustomers = 0;

    public void Task1()
    {

        Console.WriteLine("Enter customer details:");
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("Phone number: ");
        string phone = Console.ReadLine();
        Console.Write("Date of birth (dd/mm/yyyy): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());
        Console.Write("Taluka: ");
        string taluka = Console.ReadLine();
        Console.Write("Village : ");
        string Village = Console.ReadLine();

        // Check for valid phone number format
        if (phone.Length != 10 || phone.StartsWith("0"))
        {
            Console.WriteLine("Invalid phone number. Please enter a 10-digit number ");
            phone = Console.ReadLine();
        }
        string cid = GenerateCustomerId(firstName, lastName);

        // Add new customer to array
        Customer newCustomer = new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            Phone = phone,
            DateOfBirth = dob,
            Taluka = taluka,
            Village = Village,
            CustomerId = cid
        };
        customers[numCustomers] = newCustomer;
        numCustomers++;

        Console.WriteLine();
        Console.WriteLine("Customer added successfully.");
        Console.WriteLine("Customer ID: " + newCustomer.CustomerId);
    }
    private string GenerateCustomerId(string firstName, string lastName)
    {
        Random rand = new Random();
        int randomNumber = rand.Next(10, 99);
        string customerId = $"{firstName[0]}{lastName[0]}{randomNumber}";
        return customerId;
    }

    public void DisplaybyLastName()
    {
        // Display customer details by last name
        Console.WriteLine();
        Console.Write("Enter last name of customer to search: ");
        string searchLastName = Console.ReadLine();
        for (int i = 0; i < numCustomers; i++)
        {
            if (customers[i].LastName == searchLastName)
            {
                Console.WriteLine();
                Console.WriteLine("Customer ID: " + customers[i].CustomerId);
                Console.WriteLine("Name: " + customers[i].FirstName + " " + customers[i].LastName);
                Console.WriteLine("Address: " + customers[i].Address);
                Console.WriteLine("Phone: " + customers[i].Phone);
                Console.WriteLine("Date of birth: " + customers[i].DateOfBirth.ToString("dd/MM/yyyy"));
                Console.WriteLine("taluka : " + customers[i].Taluka);
                Console.WriteLine("village : " + customers[i].Village);
            }
        }
    }

    public void DisplaybyTalukaorVillage()
    {
        // Display list of customers by taluk or village
        Console.Write("Enter taluk or village name to search: ");
        string searchTalukOrVillage = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Customers in " + searchTalukOrVillage + ":");
        Console.WriteLine("----------------------------------------------------------------------------------------");
        Console.WriteLine("|  Customer ID  |      Name      |    Address   |   Number   |   Taluka   |   Village  |");
        Console.WriteLine("----------------------------------------------------------------------------------------");

        for (int i = 0; i < numCustomers; i++)
        {
            if (customers[i].Taluka.ToLower() == searchTalukOrVillage.ToLower() || customers[i].Village.ToLower() == searchTalukOrVillage.ToLower())
            {
                Console.WriteLine($"\t{customers[i].CustomerId}\t  {customers[i].FirstName} {customers[i].LastName}\t     {customers[i].Address}\t {customers[i].Phone}\t{customers[i].Taluka}\t    {customers[i].Village}");
            }
        }

        Console.WriteLine("----------------------------------------------------------------------------------------");
    }

}

class Program
{
    static void Main(string[] args)
    {
        GraminBank graminBank = new GraminBank();
        while (true)
        {
            Console.WriteLine("Enter your choice");
            Console.WriteLine("1. For Adding the customer");
            Console.WriteLine("2. Display details by last name");
            Console.WriteLine("3. Display details by Taluka and village");
            //Console.WriteLine("4. Exit");
            //graminBank.Task1();
            //graminBank.DisplaybyLastName();
            //graminBank.DisplaybyTalukaorVillage();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    graminBank.Task1();
                    Console.WriteLine();
                    break;
                case "2":
                    graminBank.DisplaybyLastName();
                    Console.WriteLine();
                    break;
                case "3":
                    graminBank.DisplaybyTalukaorVillage();
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }

    }
}
