using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    //* CONNECTION TO ALL REPOS

    private readonly Store_Repository _sRepo = new Store_Repository();
    private readonly Employee_Repository _eRepo = new Employee_Repository();
    private readonly Vendor_Repository _vRepo = new Vendor_Repository();

    public void Run()
    {
        //* SEED DATA
        SeedData();

        //* RUN APPLICATION
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("==== Welcome to Pop's Soda Pop ===");
            System.Console.WriteLine("Please make a selection: \n" +
            "1. Add Store to Database\n" +
            "2. View All Stores\n" +
            "3. View Store By ID\n" +
            "4. Update Store Data\n" +
            "5. Delete Store Data\n" +
            "------------------------------------------\n" +
            "=== Employee Database ===\n" +
            "6. Add Employee to Database\n" +
            "7. View All Employees\n" +
            "8. View Employee by ID\n" +
            "------------------------------------------\n" +
            "=== Vendor Database ===\n" +
            "9. Add Vendor to Database\n" +
            "10. View All Vendors\n" +
            "11. View Vendor by ID\n" +
            "------------------------------------------\n" +
            "50. Close Application \n");

            //* userInput
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                AddStoreToDatabase();
                break;

                case "2" :
                ViewAllStores();
                break;

                case "3":
                ViewStoresByID();
                break;

                case "4":
                UpdateStoreData();
                break;

                case "5":
                DeleteStoreData();
                break;

                case "6":
                AddEmployeeToDatabase();
                break;

                case "7":
                ViewAllEmployees();
                break;

                case "8":
                ViewEmployeeByID();
                break;

                case "9":
                AddVendorToDatabase();
                break;

                case "10":
                ViewAllVendors();
                break;

                case "11":
                ViewVendorByID();
                break;
                case "50":
                isRunning = CloseApplication();

                break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks!");
        PressAnyKeyToContinue();
        return false;

    }

    private void ViewVendorByID()
    {
        Console.Clear();
        System.Console.WriteLine("==== Vendor Detail Menu======\n");
        System.Console.WriteLine("Please enter a Vendor ID\n");
        var userInputVendorID= int.Parse(Console.ReadLine());

        var vendor = _vRepo.GetVendorByID(userInputVendorID);

        if (vendor != null)
        {
            DisplayVendorInfo(vendor);
        }
        else
        {
            System.Console.WriteLine($"The Vendor with the ID: {userInputVendorID} doesn't exist.");
        }

        PressAnyKeyToContinue();
    }

    private void DisplayVendorInfo(Vendor vendor)
    {
        DisplayVendorData(vendor);
    }

    private void AddVendorToDatabase()
    {
        Console.Clear();
        var newVendor = new Vendor();
        System.Console.WriteLine("======= Vendor Enlist Form =====\n");
        System.Console.WriteLine("Please enter Vendor Name:");
        newVendor.Name=Console.ReadLine();

        bool isSuccessful = _vRepo.AddVendorToDatabase(newVendor);
        if (isSuccessful)
        {
            System.Console.WriteLine($"{newVendor.Name} was added to database!");
        }

        else
        {
            System.Console.WriteLine("Failed to add vendor to database!");
        }

        PressAnyKeyToContinue();

    }

    private void ViewAllVendors()
    {
        // makes everything clean
        Console.Clear();
        //* grab all vendors from vendor repo and store them in 'vendors'
        var vendors = _vRepo.GetAllVendors();

        //* loop through all of the vendors to get the data
        foreach (var vendor in vendors)
        {
            //* display data w/ helper method
            DisplayVendorData(vendor);
        }

        PressAnyKeyToContinue();

    }

    private void DisplayVendorData(Vendor vendor)
    {
        System.Console.WriteLine($"VendorID: {vendor.ID}\n" + 
        $"VendorName: {vendor.Name}\n" +
        "------------------------------------------\n"
        );
    }

    private void ViewEmployeeByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllEmployees()
    {
        throw new NotImplementedException();
    }

    private void AddEmployeeToDatabase()
    {
        throw new NotImplementedException();
    }

    private void DeleteStoreData()
    {
        throw new NotImplementedException();
    }

    private void UpdateStoreData()
    {
        throw new NotImplementedException();
    }

    private void ViewStoresByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllStores()
    {
        throw new NotImplementedException();
    }

    private void AddStoreToDatabase()
    {
        throw new NotImplementedException();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key to Continue!");
        Console.ReadKey();
    }

    private void SeedData()
    {
        var jim = new Employee("Jim", "Dandy");
        var beth = new Employee("Beth", "Dandy");
        var greg = new Employee("Gred", "Gooding");
        var magoo = new Employee("Mr.", "Magoo");

        //* ADD TO DATABASE
        _eRepo.AddEmployeeToDatabase(jim);
        _eRepo.AddEmployeeToDatabase(beth);
        _eRepo.AddEmployeeToDatabase(greg);
        _eRepo.AddEmployeeToDatabase(magoo);

        //* CREATE VENDORS

        var pepsi = new Vendor("Pepsi Cola");
        var jenny = new Vendor("Jenny Cola");

        _vRepo.AddVendorToDatabase(pepsi);
        _vRepo.AddVendorToDatabase(jenny);

        //* CREATE STORES
        var storeA = new Store("Pops Soda Shack", new List<Employee> { jim, beth }, new List<Vendor> { pepsi, jenny });

        var storeB = new Store("Mammas Sodas!!");

        _sRepo.AddStoreToDatabase(storeA);
        _sRepo.AddStoreToDatabase(storeB);
    }
}
