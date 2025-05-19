using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue function will add item to the back of the queue properly, Using: (Bob, 2), (Tim, 5), (Sue, 3)
    // Expected Result: sue
    // Defect(s) Found: Found that you couldn't easily check for last, so I needed to add that, and I needed to add someway to check length as well. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);
        
        var expectedResult = sue;

        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        var length = priorityQueue.Length;

        if (length == 0)
        {
            Assert.Fail("Queue should have something in it!");
        }

        var item = priorityQueue.Last();
        Assert.AreEqual(expectedResult.Value, item);

        
    }

    [TestMethod]
    // Scenario: the Dequeue will remove the item with the highest priority and return the value. Using: (Bob, 2), (Tim, 5), (Sue, 3)
    // Expected Result: Tim
    // Defect(s) Found: I did notice that it wasn't remove the person from the queue, so I fixed that.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);

        var expectedResult = tim;

        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        var length = priorityQueue.Length;

        if (length == 0)
        {
            Assert.Fail("Queue should have something in it!");
        }

        var item = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult.Value, item);
    }

    [TestMethod]
    // Scenario: If there are multiple items with the highest priority, then the item closest to the front will be retrieved. Using: (Bob, 5), (Tim, 2), (Sue, 5) (Fred, 3)
    // Expected Result: Bob, Sue, Fred, Tim
    // Defect(s) Found: First issue, it wasn't actually removing anything from the queue. Second, the for loop was incorrect with the minus 1. 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        var bob = new PriorityItem("Bob", 5);
        var tim = new PriorityItem("Tim", 2);
        var sue = new PriorityItem("Sue", 5);
        var fred = new PriorityItem("Fred", 3);

        PriorityItem[] expectedResult = [bob, sue, fred, tim];

        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(fred.Value, fred.Priority);

        if (priorityQueue.Length == 0)
        {
            Assert.Fail("Queue should have something in it!");
        }

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, person);
            i++;
        }
    }

    [TestMethod]
    // Scenario: If queue is empty, then an error exception shall be thrown.
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
    
}