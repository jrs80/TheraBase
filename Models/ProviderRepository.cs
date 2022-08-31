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
            => dbConnection.Query<Provider>("SELECT * FROM providers");

        public Provider GetProvider(int id)
            => dbConnection.QuerySingleOrDefault<Provider>("SELECT * FROM providers WHERE employeeid=@empid", new { empid = id });


        public void AddProvider(Provider provider)
        {  
            dbConnection.Execute("INSERT INTO providers (firstname, lastname, specialties, age, gender, photopath) " +
                                 "VALUES (@firstName,@lastName,@specialties,@age,@gender,@photourl)",
                                  new
                                  {
                                      firstName = provider.FirstName,
                                      lastName = provider.LastName,
                                      age = provider.Age,
                                      gender = provider.Gender == GenderCategories.Male ? "Male"
                                                : provider.Gender == GenderCategories.Female ? "Female"
                                                : "Nonbinary",
                                        /*
                                         * TODO: Make a dictionary for specialty values/display names
                                         * and refer to it here to make this less ugly! 
                                         */
                                      specialties = provider.Specialties == SpecialtyCategories.Child ? "Child"
                                        : provider.Specialties == SpecialtyCategories.Trauma ? "Trauma"
                                        : provider.Specialties == SpecialtyCategories.Drug ? "Drug"
                                        : provider.Specialties == SpecialtyCategories.Dep ? "Dep"
                                        : provider.Specialties == SpecialtyCategories.Pers ? "Pers"
                                        : provider.Specialties == SpecialtyCategories.ADHD ? "ADHD"
                                        : "Other",

                                      photourl =provider.PhotoPath
                                  }) ;
        }
        public void DeleteProvider(int id)
        {
            dbConnection.Execute("DELETE FROM providers WHERE employeeid=@empid",
                                  new { empid = id });
        }
        public void UpdateProvider(Provider provider)
        {
            dbConnection.Execute("UPDATE providers " +
                                 "SET firstname=@firstname, lastname=@lastname, age=@age, gender=@gender, specialties=@specialties, photopath=@path " +
                                 "WHERE employeeid=@empid",
                                 new
                                 {
                                     firstname = provider.FirstName,
                                     lastname = provider.LastName,
                                     age = provider.Age,
                                     gender = provider.Gender == GenderCategories.Male ? "Male"
                                                : provider.Gender == GenderCategories.Female ? "Female"
                                                : "Nonbinary",
                                     
                                     /*
                                      * TODO: Make a dictionary for specialty values/display names
                                      * and refer to it here to make this less ugly! 
                                      */
                                     specialties = provider.Specialties == SpecialtyCategories.Child? "Child"
                                        : provider.Specialties == SpecialtyCategories.Trauma?"Trauma"
                                        : provider.Specialties == SpecialtyCategories.Drug ? "Drug"
                                        : provider.Specialties == SpecialtyCategories.Dep ? "Dep"
                                        : provider.Specialties == SpecialtyCategories.Pers ? "Pers"
                                        : provider.Specialties == SpecialtyCategories.ADHD ? "ADHD"
                                        : "Other",
                                     empid = provider.EmployeeID,
                                     path=provider.PhotoPath
                                 });
        }

    }
}
