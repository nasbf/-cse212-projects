/// <summary>
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
        // Scenario: The user specify an invalid size for the queue (<= 0).  The default value of 10 should be used.
        // Expected Result: the value of max_size should be 10.
        Console.WriteLine("Test 1");

        // Defect(s) Found: 
        var service = new CustomerService(0);
        for (int i = 0; i < 10; i++) {
            service.AddNewCustomer("Client", i.ToString(), "learning c#");
            }   
        service.AddNewCustomer("newClient", "123456", "testing");
            
        
        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add a new client to the queue.
        // Expected Result: The queue should contain the new client.
        Console.WriteLine("Test 2");

        // Defect(s) Found: 
        var newClient = new CustomerService(5);
        newClient.AddNewCustomer("newClient", "123458", "test");
        Console.WriteLine(newClient);
        Console.WriteLine("=================");

        // Test 3
        // Scenario: Fill the queue to its maximum capacity and then add one more customer.
        // Expected Result: Display an error message indicatingthat the queue is full.
        Console.WriteLine("Test 3");

        // Defect(s) Found: 
        var fullQueue = new CustomerService(2);
        fullQueue.AddNewCustomer("Client1", "123456", "learning c#");

        fullQueue.AddNewCustomer("Client2", "123457", "learning c#");
        fullQueue.AddNewCustomer("Client3", "123458", "learning c#");
        Console.WriteLine("The Queue is full");
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Dequeue a customer from the queue.
        // Expected Result: Display the details of the dequeued customer.
        Console.WriteLine("Test 4");

        // Defect(s) Found: 
        var deleteClient = new CustomerService(3);
        deleteClient.AddNewCustomer("Client1", "123456", "learning c#");
        deleteClient.AddNewCustomer("Client2", "123457", "learning c#");    

        deleteClient.ServeCustomer();
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Attempt to serve a customer when the queue is empty.
        // Expected Result: Display a message indicating the queue is empty.
        Console.WriteLine("Test 5");

        // Defect(s) Found: 
        var emptyQueue = new CustomerService(3);
        emptyQueue.ServeCustomer();

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
    private void AddNewCustomer(string name, string accountId, string problem) {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        // Console.Write("Customer Name: ");
        // var name = Console.ReadLine()!.Trim();
        // Console.Write("Account Id: ");
        // var accountId = Console.ReadLine()!.Trim();
        // Console.Write("Problem: ");
        // var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("Queue is empty.");
            return;
        }
        var customer = _queue[0];        
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
         
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