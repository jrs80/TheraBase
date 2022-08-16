using System.Collections.Generic;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace TherapistDatabase.Models
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly IDbConnection dbConnection;
        public ProviderRepository(IDbConnection conn)
        {
            dbConnection = conn;
        }
        public IEnumerable<Provider> GetAllProviders()
            =>dbConnection.Query<Provider>("SELECT * FROM providers");

        public Provider GetProvider(int id)
             => dbConnection.QuerySingleOrDefault<Provider>("SELECT * FROM providers WHERE employeeid=@empid", new { empid = id });


        public void AddProvider(Provider newProv)
        {
            dbConnection.Execute("INSERT INTO providers (employeeid, lastname, firstname, specialties, age, gender) " +
                                 "VALUES (@empID,@firstName,@lastName,@specialties,@age,@gender)",
                                  new
                                  {
                                      empID = newProv.EmployeeID,
                                      firstName = newProv.FirstName,
                                      lastName = newProv.LastName,
                                      specialties = newProv.Specialties,
                                      age = newProv.Age,
                                      gender = newProv.Gender
                                  });
        }
        public void DeleteProvider(int id)
        {
            dbConnection.Execute("DELETE FROM providers WHERE employeeid=@empid",
                                  new { empid = id });
        }
        public void UpdateProvider(Provider provider)
        {
            dbConnection.Execute ("UPDATE providers " +
                                 "SET firstname=@firstname, lastname=@lastname, age=@age, gender=@gender, specialties=@specialties " +
                                 "WHERE employeeid=@empid",
                                 new
                                 {
                                     firstname = provider.FirstName,
                                     lastname = provider.LastName,
                                     age = provider.Age,
                                     gender = provider.Gender,
                                     specialties = provider.Specialties,
                                     empid = provider.EmployeeID
                                     //availability = provToUpdate.Availability
                                 }) ;
        }
    }
}
