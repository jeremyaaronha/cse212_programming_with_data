using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

[TestClass]
public class CustomerServiceTests
{
    [TestMethod]
    // scenario: create a customer service queue with size -1 (invalid)
    // expected result: the max size should default to 10
    // defect(s) found: none
    public void Test_InvalidSizeDefaultsTo10()
    {
        var cs = new CustomerService(-1);
        StringAssert.Contains(cs.ToString(), "max_size=10");
    }

    [TestMethod]
    // scenario: add a customer to the queue
    // expected result: customer is added and appears in the queue
    // defect(s) found: none
    public void Test_AddNewCustomer_AddsCorrectly()
    {
        var cs = new CustomerService(3);

        // simulate console input
        var input = new StringReader("Alice\n001\nPassword issue\n");
        Console.SetIn(input);

        var output = new StringWriter();
        Console.SetOut(output);

        var method = typeof(CustomerService).GetMethod("AddNewCustomer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        method.Invoke(cs, null);

        StringAssert.Contains(cs.ToString(), "Alice");
    }

    [TestMethod]
    // scenario: try to add a customer when queue is full
    // expected result: display error message
    // defect(s) found: the queue allows one extra customer (off-by-one bug)
    public void Test_AddNewCustomer_WhenFull_ShowsError()
    {
        var cs = new CustomerService(1);

        // fill queue
        var input1 = new StringReader("Bob\n002\nLogin problem\n");
        Console.SetIn(input1);
        var method = typeof(CustomerService).GetMethod("AddNewCustomer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        method.Invoke(cs, null);

        // try to add another customer
        var input2 = new StringReader("Charlie\n003\nBilling issue\n");
        Console.SetIn(input2);
        var output = new StringWriter();
        Console.SetOut(output);

        method.Invoke(cs, null);
        StringAssert.Contains(output.ToString(), "Maximum Number of Customers in Queue");
    }

    [TestMethod]
    // scenario: serve a customer
    // expected result: display first customer in queue
    // defect(s) found: removes first before showing second customer (wrong logic)
    public void Test_ServeCustomer_ShowsCorrectCustomer()
    {
        var cs = new CustomerService(2);

        // add a customer
        var input = new StringReader("Dave\n004\nConnection issue\n");
        Console.SetIn(input);
        var addMethod = typeof(CustomerService).GetMethod("AddNewCustomer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        addMethod.Invoke(cs, null);

        // capture output
        var output = new StringWriter();
        Console.SetOut(output);

        var serveMethod = typeof(CustomerService).GetMethod("ServeCustomer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        serveMethod.Invoke(cs, null);

        StringAssert.Contains(output.ToString(), "Dave (004)");
    }

    [TestMethod]
    // scenario: serve a customer when queue is empty
    // expected result: display error instead of crashing
    // defect(s) found: throws index out of range
    public void Test_ServeCustomer_WhenEmpty_ShowsError()
    {
        var cs = new CustomerService(2);

        var output = new StringWriter();
        Console.SetOut(output);

        var serveMethod = typeof(CustomerService).GetMethod("ServeCustomer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

        try
        {
            serveMethod.Invoke(cs, null);
        }
        catch { }

        StringAssert.Contains(output.ToString(), "No customers to serve");
    }
}