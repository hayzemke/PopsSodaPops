using System.Collections.Generic;
using Xunit;

namespace PopsSodaPop.Repositories.Tests;

public class StoreRepo_Test
{
    //* Arrange
    //private variables that will be made but not intialize

    private readonly Store_Repository _sRepo; //* private variable #1, DO NOT ASSIGN VALUE HERE
    private Store _store;                     //* private variable #2, DO NOT ASSIGN VALUE HERE
    private Vendor _vendor;                   //* private variable #3, DO NOT ASSIGN VALUE HERE
    private Employee _employee;               //* private variable #4, DO NOT ASSIGN VALUE HERE

    //* the plan is to use ANY of these variables anywhere in testing as i choose. 

    //* constructor
    public StoreRepo_Test()
    {
        _sRepo = new Store_Repository();
        _vendor = new Vendor("Pepsi Cola");
        _employee = new Employee("John", "Doe");
        _store = new Store("Pops Soda House", new List<Employee> { _employee }, new List<Vendor> { _vendor });


        //* last thing: ADD THE CREATED _store TO THE DATABASE _sRepo

        _sRepo.AddStoreToDatabase(_store);

        //* our store will have the ID = 1 B/C of our _counter in Store_Repository class
    }


    [Fact]
    public void AddStoreToDatabase_ShouldReturnTrue()
    {
        //* Arrange
        var store = new Store("Soda Pop Shack");

        //* Act
        var expectingTrue = _sRepo.AddStoreToDatabase(store);

        //* Assert
        Assert.True(expectingTrue);
    }

    [Fact]
    public void RetrieveStoreDataByID_ShouldReturnCorrectID_True()
    {
        // Given
        var caliStore = new Store("7/11 Cali");
        _sRepo.AddStoreToDatabase(caliStore);

        // When
        var store = _sRepo.GetStoreByID(2);
        var actual = store.ID;
        var expected = 2;


        // Then
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetAllStores_CountShouldMatch()
    {
        // Given
        var store = new Store("Soda Pop Shack");
        var store2 = new Store("7/11 Cali");
        var store3 = new Store("7/11 Indy");

        // When
        //* add stores to db
        _sRepo.AddStoreToDatabase(store);
        _sRepo.AddStoreToDatabase(store2);
        _sRepo.AddStoreToDatabase(store3);

        var expectedStoreCount = 4;
        var actual = _sRepo.GetAllStores().Count;


        // Then
        Assert.Equal(expectedStoreCount, actual);


    }


    [Fact]
    public void UpdateStoreData_ShouldReturn_True()
    {
        //* ACT - already done for us using _store from above
        var oldstoreID = _store.ID;

        //* make new store to assing values

        var newStoreValues =
        new Store("UPDATED STORE...",
        new List<Employee>
        {
        new Employee
        {
            FirstName= "Mike",
            LastName= "Law"
        },
        new Employee
        {
            FirstName= "Jude",
            LastName= "Law"
        }
        },

        new List<Vendor>
        {
        new Vendor
        {
            Name = "Coca-Cola"
        }
        });

        var expected = _sRepo.UpdateStoreData(oldstoreID, newStoreValues);

        Assert.True(expected);
    }

    [Fact]
    public void DeleteStore_ShouldReturn_True()
    {
    
        var oldStoreID= _store.ID;

        var expected = _sRepo.RemoveStoreFromDatabase(oldStoreID);
        
        Assert.True(expected);
        
    }

}