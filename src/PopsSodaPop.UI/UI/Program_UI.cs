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

                case "2":
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
        var userInputVendorID = int.Parse(Console.ReadLine());

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
        newVendor.Name = Console.ReadLine();

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
        Console.Clear();

        System.Console.WriteLine("==== Employee Detail Menu======\n");
        System.Console.WriteLine("Please enter a Employee ID\n");
        var userInputEmployeeID = int.Parse(Console.ReadLine());

        var employee = _eRepo.GetEmployeeByID(userInputEmployeeID);

        if (employee != null)
        {
            DisplayEmployeeInfo(employee);
        }
        else
        {
            System.Console.WriteLine($"The Employee with the ID: {userInputEmployeeID} doesn't exist.");
        }






        PressAnyKeyToContinue();
    }

    private void DisplayEmployeeInfo(Employee employee)
    {
        System.Console.WriteLine($"EmployeeID: {employee.ID}\n" +
        $"EmployeeName: {employee.FirstName} {employee.LastName}\n" +
        "---------------------------------------------------\n");
    }

    private void ViewAllEmployees()
    {
        Console.Clear();

        List<Employee> employeesInDb = _eRepo.GetAllEmployees();

        if (employeesInDb.Count > 0)
        {
            foreach (Employee employee in employeesInDb)
            {
                DisplayEmployeeInfo(employee);
            }
        }
        else
        {
            System.Console.WriteLine("There are no employees.");
        }

        PressAnyKeyToContinue();
    }

    private void AddEmployeeToDatabase()
    {
        Console.Clear();
        var newEmployee = new Employee();
        System.Console.WriteLine("==== Employee Enlisting Form ====\n");

        System.Console.WriteLine("Please enter employee's first name:");
        newEmployee.FirstName = Console.ReadLine();

        System.Console.WriteLine("Please enter employee's last name:");
        newEmployee.LastName = Console.ReadLine();

        //* here is the point where we utilize the bool return value w/n _eRepo.AddEmployeeToDatabse
        bool isSuccessful = _eRepo.AddEmployeeToDatabase(newEmployee);
        if (isSuccessful)   
        {
            System.Console.WriteLine($"{newEmployee.FirstName} - {newEmployee.LastName} was added to the database!");
        }
        else
        {
            System.Console.WriteLine("Employee failed to be added to the database!");
        }

        PressAnyKeyToContinue();
    }

    private void DeleteStoreData()
    {
        Console.Clear();

        System.Console.WriteLine("=== Store Removal Page ===");
        

        var stores = _sRepo.GetAllStores();
        foreach (Store store in stores)
        {
            DisplayStoreListing(store);
        }

        try
        {
            System.Console.WriteLine("Please select a store by its ID:");
            var userInputSelectedStore= int.Parse(Console.ReadLine());
            bool isSuccessful= _sRepo.RemoveStoreFromDatabase(userInputSelectedStore);
            if(isSuccessful)
            {
                System.Console.WriteLine("Store was successfully deleted.");
            }
            else
            {
                System.Console.WriteLine("store failed to be deleted.");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }



        PressAnyKeyToContinue();
    }

    private void UpdateStoreData()
    {
        Console.Clear();

        var avialStores = _sRepo.GetAllStores();
        foreach (var store in avialStores)
        {
            DisplayStoreListing(store);
        }

        System.Console.WriteLine("Please enter a valid store");
        var userInputStoreID = int.Parse(Console.ReadLine());
        var userSelectedStore = _sRepo.GetStoreByID(userInputStoreID);

        if (userSelectedStore != null)
        {
            var newStore = new Store();

        //* temporary container that holds current employees 
        var currentEmployees = _eRepo.GetAllEmployees();
        var currentVendors = _vRepo.GetAllVendors();
        //* temporary container that holds current vendors -> to make a selection and remove item from list

        System.Console.WriteLine("Please enter a Store Name:");
        newStore.Name=Console.ReadLine();

        bool hasAssignedEmployees = false;
        while (hasAssignedEmployees)
        {
            System.Console.WriteLine("Do you have any employees? y/n");
            var userInputHasEmployees = Console.ReadLine();

            if (userInputHasEmployees == "Y".ToLower())
            {
                // display available employees
                foreach (var employee in currentEmployees)
                {
                    System.Console.WriteLine($"{employee.ID} {employee.FirstName} {employee.LastName}");
                }

                var userInputEmployeeSelection = int.Parse(Console.ReadLine());
                var selectedEmployee = _eRepo.GetEmployeeByID(userInputEmployeeSelection);

                if (selectedEmployee != null)
                {
                    newStore.Employees.Add(selectedEmployee);
                    currentEmployees.Remove(selectedEmployee);

                }
                else
                {
                    System.Console.WriteLine($"Sorry, the employee with the ID: {userInputEmployeeSelection} doesn't exist.");
                }
            }
            else
            {
                hasAssignedEmployees=true;
            }
        }

        bool hasAssignedVendors = false;
        while (!hasAssignedVendors)
        {
            System.Console.WriteLine("Do you have any vendors? y/n");
            var userInputHasVendors = Console.ReadLine();
            if (userInputHasVendors == "Y".ToLower())
            {
                foreach (var vendor in currentVendors)
                {
                    System.Console.WriteLine($"{vendor.ID} {vendor.Name}");
                }
                var userInputVendorSelection = int.Parse(Console.ReadLine());
                var selectedVendor = _vRepo.GetVendorByID(userInputVendorSelection);

                if (selectedVendor != null)
                {
                    newStore.Vendors.Add(selectedVendor);
                    currentVendors.Remove(selectedVendor);
                }

                else
                {
                    System.Console.WriteLine($"Sorry the vendor with the ID: {userInputVendorSelection} doesn't exist.");
                }
            }

                else
                {
                    hasAssignedVendors=true;
                }
        }
        var isSuccessful = _sRepo.UpdateStoreData(userSelectedStore.ID,newStore);
        if (isSuccessful)
        {
            System.Console.WriteLine("SUCCESS!!");
        }
        else
        {
            System.Console.WriteLine("FAILURE!!!");
        }
        }

        else
        {
            System.Console.WriteLine("Sorry the store with the ID: {userInputStoreID doesn't exist.");
        }



        PressAnyKeyToContinue();
    }

    private void ViewStoresByID()
    {
        Console.Clear();

        System.Console.WriteLine("=== Store Details ===");
        System.Console.WriteLine("Please select a store by its ID:");

        var stores = _sRepo.GetAllStores();
        foreach (Store store in stores)
        {
            DisplayStoreListing(store);
        }

        try
        {
            var userInputSelectedStore= int.Parse(Console.ReadLine());
            var selectedStore = _sRepo.GetStoreByID(userInputSelectedStore);
            if (selectedStore !=null)
            {
                DisplayStoreDetails(selectedStore);
            }
            else
            {
                System.Console.WriteLine($"Sorry the store with the ID: {userInputSelectedStore} doesn't exist");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }

        PressAnyKeyToContinue();
    }

    private void DisplayStoreDetails(Store selectedStore)
    {
        Console.Clear();
        System.Console.WriteLine($"StoreID: {selectedStore.ID}\n" +
        $"StoreName: {selectedStore.Name}\n");

        System.Console.WriteLine("--- Employees ---");
        if (selectedStore.Employees.Count >0)
        {
            foreach (var employee in selectedStore.Employees)
        {
            DisplayEmployeeInfo(employee);
        }
        }
        else
        {
            System.Console.WriteLine("There are no employees.");
        }
        System.Console.WriteLine("---------------------------------------------\n");
        System.Console.WriteLine("--- Vendors ---");
        if (selectedStore.Vendors.Count >0)
        {
            foreach (var vendor in selectedStore.Vendors)
        {
            DisplayVendorInfo(vendor);
        }
        }
        else
        {
            System.Console.WriteLine("There are no vendors.");
        }
        

        PressAnyKeyToContinue();
    }

    private void ViewAllStores()
    {
        Console.Clear();

        System.Console.WriteLine("=== Store Listing ===\n");
        var storesInDb = _sRepo.GetAllStores();

        foreach (var store in storesInDb)
        {
            DisplayStoreListing(store);
        }

        PressAnyKeyToContinue();
    }

    private void DisplayStoreListing(Store store)
    {
        System.Console.WriteLine($" StoreID: {store.ID}\n StoreName: {store.Name}\n" +
        "------------------------------------------\n");
    }

    private void AddStoreToDatabase()
    {
        Console.Clear();

        var newStore = new Store();

        //* temporary container that holds current employees 
        var currentEmployees = _eRepo.GetAllEmployees();
        var currentVendors = _vRepo.GetAllVendors();
        //* temporary container that holds current vendors -> to make a selection and remove item from list

        System.Console.WriteLine("Please enter a Store Name:");
        newStore.Name=Console.ReadLine();

        bool hasAssignedEmployees = false;
        while (hasAssignedEmployees)
        {
            System.Console.WriteLine("Do you have any employees? y/n");
            var userInputHasEmployees = Console.ReadLine();

            if (userInputHasEmployees == "Y".ToLower())
            {
                // display available employees
                foreach (var employee in currentEmployees)
                {
                    System.Console.WriteLine($"{employee.ID} {employee.FirstName} {employee.LastName}");
                }

                var userInputEmployeeSelection = int.Parse(Console.ReadLine());
                var selectedEmployee = _eRepo.GetEmployeeByID(userInputEmployeeSelection);

                if (selectedEmployee != null)
                {
                    newStore.Employees.Add(selectedEmployee);
                    currentEmployees.Remove(selectedEmployee);

                }
                else
                {
                    System.Console.WriteLine($"Sorry, the employee with the ID: {userInputEmployeeSelection} doesn't exist.");
                }
            }
            else
            {
                hasAssignedEmployees=true;
            }
        }

        bool hasAssignedVendors = false;
        while (!hasAssignedVendors)
        {
            System.Console.WriteLine("Do you have any vendors? y/n");
            var userInputHasVendors = Console.ReadLine();
            if (userInputHasVendors == "Y".ToLower())
            {
                foreach (var vendor in currentVendors)
                {
                    System.Console.WriteLine($"{vendor.ID} {vendor.Name}");
                }
                var userInputVendorSelection = int.Parse(Console.ReadLine());
                var selectedVendor = _vRepo.GetVendorByID(userInputVendorSelection);

                if (selectedVendor != null)
                {
                    newStore.Vendors.Add(selectedVendor);
                    currentVendors.Remove(selectedVendor);
                }

                else
                {
                    System.Console.WriteLine($"Sorry the vendor with the ID: {userInputVendorSelection} doesn't exist.");
                }
            }

                else
                {
                    hasAssignedVendors=true;
                }
        }

        bool isSuccessful = _sRepo.AddStoreToDatabase(newStore);
        if(isSuccessful)
        {
            System.Console.WriteLine($"Store: {newStore.Name} was added to the database.");
        }
        else
        {
            System.Console.WriteLine("Store failed to be added to the database.");
        }

        PressAnyKeyToContinue();
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
