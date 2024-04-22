﻿using BookStore;
using LinqToDB;
using LinqToDB.DataProvider.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOperations
{
    public class AddressDataAccess
    {
        private readonly string _connectionString;

        public AddressDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Address> GetAddresses() 
        {
            using (var db = PostgreSQLTools.CreateDataConnection(_connectionString))
            {
                var allAddresses = db.GetTable<Address>()
                                 .LoadWith(req=> req.country)
                                 .ToList();
                return allAddresses;
            }
        }
        public void PrintAllAddresses()
        {
            using (var db = PostgreSQLTools.CreateDataConnection(_connectionString))
            {
                var allAddress = db.GetTable<Address>()
                    .LoadWith(req => req.country)
                    .ToList();

                Console.WriteLine("{0,-10} {1,-20} {2,-30} {3, -40}", "Street name", "Street number", "city", "country");
                Console.WriteLine(new string('-', 30));

                foreach (var address in allAddress)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2, -30} {3, -40}", address.streetNumber, address.streetName, address.city, address.country.countryName);
                }
            }
        }

        public Address GetAddressById(int addressId)
        {
            using (var db = PostgreSQLTools.CreateDataConnection(_connectionString))
            {
                return db.GetTable<Address>().FirstOrDefault(a => a.addressId == addressId);
            }
        }
        public void AddAddress(Address addressId)
        {
            using (var db = PostgreSQLTools.CreateDataConnection(_connectionString))
            {
                db.Insert(addressId);
            }
        }

        public void UpdateAddress(Address address)
        {
            using (var db = PostgreSQLTools.CreateDataConnection(_connectionString))
            {
                db.Update(address);
            }
        }

        public void DeleteAddress(int addressId)
        {
            using (var db = PostgreSQLTools.CreateDataConnection(_connectionString))
            {
                db.GetTable<Address>().Delete(a => a.addressId == addressId);
            }
        }
    }
}
