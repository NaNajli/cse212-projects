using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 5);
        var item = priorityQueue.Dequeue();
        Assert.AreEqual("apple", item);

        // Assert.Fail("Implement the test case and then remove this.");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: The Dequeue function shall remove the item with the highest priority and return its value.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 5);
        priorityQueue.Enqueue("mango", 8);
        priorityQueue.Enqueue("mango", 2);
        var item = priorityQueue.Dequeue();
        Assert.AreEqual("mango", item);
        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: 
    // Expected Result:If there are more than one item with the highest priority, then the item closest to the front of the queue will be removed and its value returned.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("apple", 8);
        priorityQueue.Enqueue("mango", 8);
        priorityQueue.Enqueue("potato", 2);
        var item = priorityQueue.Dequeue();
        Assert.AreEqual("mango", item);
    }

    [TestMethod]
    // Scenario: 
    // Expected Result:If the queue is empty, then an error exception shall be thrown. This exception should be an InvalidOperationException with a message of "The queue is empty."
    // Defect(s) Found: 

    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("tomate", 0);

        try
        {
            priorityQueue.Dequeue();
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
            throw;
        }
    }

}