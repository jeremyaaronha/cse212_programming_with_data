using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.



// tests for the priority queue class
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // scenario: enqueue 3 values with different priorities and dequeue them
    // expected result: the one with highest priority is returned first
    // defect found: returns the wrong value if highest priority is at the end
    public void Test_Dequeue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 3); // highest
        priorityQueue.Enqueue("c", 2);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("b", result);
    }

    [TestMethod]
    // scenario: enqueue 3 values with same priority and dequeue one
    // expected result: the first inserted value is returned
    // defect found: may not return the first one if comparison uses >=
    public void Test_Dequeue_SamePriority_FIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 5);
        priorityQueue.Enqueue("b", 5);
        priorityQueue.Enqueue("c", 5);

        string result = priorityQueue.Dequeue();

        Assert.AreEqual("a", result);
    }

    [TestMethod]
    // scenario: try to dequeue from an empty queue
    // expected result: throws an exception with correct message
    // defect found: no defects
    public void Test_Dequeue_EmptyQueue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // scenario: enqueue values in order and check string representation
    // expected result: order of items in string should match enqueue order
    // defect(s) found: no defects
    public void Test_Enqueue_AddsToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("x", 1);
        priorityQueue.Enqueue("y", 2);
        priorityQueue.Enqueue("z", 3);

        string result = priorityQueue.ToString();

        Assert.AreEqual("[x (Pri:1), y (Pri:2), z (Pri:3)]", result);
    }
}