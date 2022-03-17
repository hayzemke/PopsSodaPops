using System.Collections.Generic;
using Xunit;


public class POCOs_TestingSite
{
    [Fact]
    public void CreateAnInstanceOf_Employee()
    {
        //AAA SETUP

        //* Arrange
        Employee employee = new Employee("John", "Doe");
        employee.ID = 1;

        //* Act
        int expectedEmpID = 1;
        int actualEmpID = employee.ID;

        //* Assert
        Assert.Equal(expectedEmpID, actualEmpID);
    }

    [Fact]

    public void CreateAnInstanceOf_Vendor()
    {
        //* Arrange
        Vendor vendor = new Vendor("Pepsi Cola");

        //* Act 
        string expected = "Pepsi";
        string actual = vendor.Name;


        //* Assert
        Assert.Contains(expected, actual);

    }

    [Fact]

    public void CreateAnInstanceOf_Store()
    {
        //* Arrange
        Store store = new Store();

        //* obj (List<T>) initialization
        //* allows us to create a List<Employee> on the fly
        store.Employees = new List<Employee>
        {
            new Employee("John", "Doe")
        };


        //* Act
        int expected = 1;
        int actual = store.Employees.Count;

        //* Assert
        Assert.Equal(expected, actual);

    }
}