
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TherapistDatabase.Models
{
    public enum GenderCategories { Male, Female, Nonbinary };
    
    
    /*public enum SpecialtyList
    {
        [Display(Name = "Depression & Anxiety")]
        DepressionAndAnxiety,
        [Display(Name = "Trauma & PTSD")]
        TraumaAndPTSD,
        [Display(Name = "Substance-Use Disorders")]
        SubstanceUseDisorders,
        [Display(Name = "Marriage & Family")]
        MarriageAndFamily,
        Other
    };*/
    



    public class Provider
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Specialties { get; set; }
        // public IEnumerable<string> Specialties { get; set; }
        public int Age { get; set; }
        public GenderCategories Gender { get; set; }
        public string PhotoPath { get; set; }
        public Provider()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            Specialties = "Other";
            PhotoPath = "";
            //Specialties = new List<string>();
            //foreach(var spec in SpecialtyListModel.SpecList)
            //    Specialties.Add(spec);
        }
    }
}
