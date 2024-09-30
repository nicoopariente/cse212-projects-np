﻿/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        //The user shall specify the maximum size of the Customer Service Queue when it is created. If the size is invalid (less than or equal to 0) then the size shall default to 10.

        // Expected Result: 
        Console.WriteLine("Test 1");
        var test1 = new CustomerService(0);
        Console.WriteLine( test1);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        //The AddNewCustomer method shall enqueue a new customer into the queue.
        // Expected Result: 
        Console.WriteLine("Test 2");

        var test2 = new CustomerService(1);
        test2.AddNewCustomer();
        Console.WriteLine( test2);
        // // Defect(s) Found: the if statement shoud be greater or equal than instead of greater than only.

         Console.WriteLine("=================");


        // // Test 3
        // // Scenario: 
        // //If the queue is full when trying to add a customer, then an error message will be displayed.
        // // Expected Result: 
        Console.WriteLine("Test 3");
        var test3 = new CustomerService(1);
        test3.AddNewCustomer();
        test3.AddNewCustomer();
        Console.WriteLine( test3);
        // // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 4
        // Scenario: 
        //The ServeCustomer function shall dequeue the next customer from the queue and display the details.
        // Expected Result: 
        Console.WriteLine("Test 4");
        var test4 = new CustomerService(1);
        test4.AddNewCustomer();
        test4.ServeCustomer();
        // // Defect(s) Found: the line "_queue.RemoveAt(0);" should go at the end of the function

        Console.WriteLine("=================");


        // Test 5
        // Scenario: 
        //If the queue is empty when trying to serve a customer, then an error message will be displayed.
        // Expected Result: 
        Console.WriteLine("Test 5");

        var test5 = new CustomerService(1);
        test5.ServeCustomer();

        // Defect(s) Found: An if statement was needed in order to handle the empty queue

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        
        
        if (_queue.Count == 0){
            Console.WriteLine("The queue is empty");
        }else{
            var customer = _queue[0];
            Console.WriteLine(customer);
            _queue.RemoveAt(0);
        }
        
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}