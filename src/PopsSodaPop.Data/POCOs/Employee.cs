using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//* blueprint of what we think an employee should be
public class Employee
{
    //* ctor: how the employee obj can be made in the application
    public Employee() { }

    public Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    //* properties: just describe the obj (employee)
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}