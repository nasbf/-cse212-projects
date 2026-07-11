using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add an item (data and priority) to the queue
    // Expected Result: The item added is in the back position in the queue.
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("data 1", 3); 
        var result = priorityQueue.Dequeue();
        
        Assert.AreEqual("data 1", result);
        
    }

    [TestMethod]
    // Scenario: Add three items with different priorities. (priority 1,2,3) when dequeue runs obtain the higest priority item first (3) in this case. 
    // Expected Result: item with priority 3.
    // Defect(s) Found: do not examine all items in the queue, so the highestpriority item could be skipped.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("data 1", 1);
        priorityQueue.Enqueue("data 2", 2);
        priorityQueue.Enqueue("data 3", 3);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("data 3", result);
        
    }


    [TestMethod]
    // Scenario: Add four items where two items share the highest priority. Verify that the first one added (FIFO) is dequeued first.
    // Expected Result: display the item with highest priority (3) and delete it from the queue.
    // Defect(s) Found: the function Dequeue() did nor return the first item with the first highest priority, it used the simbol >= so it display the last item with the hihest priority, 
    // also the function did not remove the item from the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("data 1", 1);
        priorityQueue.Enqueue("data 2", 3);
        priorityQueue.Enqueue("data 3", 2);
        priorityQueue.Enqueue("data 4", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("data 2", result);
        var result2 = priorityQueue.Dequeue();
        Assert.AreEqual("data 4", result2);
    }


    [TestMethod]
    // Scenario: Add items where one of them has a 0 priority it indicates that it has an infinity number of turns, so if it is dequeued it should be added back to the queue.
    // Expected Result: the item with 0 or less priority shold be added back to the queue.
    // Defect(s) Found: None.

    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
        () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
    

    // Add more test cases as needed below.
}