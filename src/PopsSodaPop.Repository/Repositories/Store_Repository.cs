using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Store_Repository
    {
        //* we need a collection type, we want to use a list : List<T>, which will hold all of the stores that we have
        //* can add, remove, give you back a store, or give user all stores

        //* 'fake database'
        private readonly List<Store> _storeDatabase = new List<Store>();

        //*implement ID counter
        private int _count = 0;

        //* CREATE (ADD)
        public bool AddStoreToDatabase(Store store)
        {
            //* check if store variable has valid data
            if (store != null)      
            {
                //* increment counter
                _count++;

                //* assign _count to store.ID
                store.ID=_count;

                //* add store to database
                _storeDatabase.Add(store);

                //* return true for UI purposes
                return true;
            }

            else
            {
                return false;
            }

        }

        //* READ (give user all stores)
        public List<Store> GetAllStores()
        {
            return _storeDatabase;
        }

        //* READ (give you a store)
        public Store GetStoreByID(int id)
        {
            foreach (Store store in _storeDatabase)
            {
                if (store.ID==id)  
                {
                    return store;
                }
            }
            return null;
        }

        //* UPDATE (complete clearing of data- NOT THE ID)
        public bool UpdateStoreData(int storeID, Store newStoreData)
        {
            //* find the old store data (existing data in _storeDatabase)
            var oldStoreData = GetStoreByID(storeID);

            //* check if oldStoreData exists
            if (oldStoreData != null) //* null = nothing
            {
                //* write over everything except old store data.ID
                oldStoreData.Name = newStoreData.Name;
                oldStoreData.Employees = newStoreData.Employees;
                oldStoreData.Vendors = newStoreData.Vendors;
                return true;
            }
            else
            {
                return false;
            }

        }

        //* DELETE (remove store from _storeDatabase)
        public bool RemoveStoreFromDatabase(int id)
        {
            var store = GetStoreByID(id);
            if (store != null)
            {
                _storeDatabase.Remove(store);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
