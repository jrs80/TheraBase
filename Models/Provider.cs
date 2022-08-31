
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TherapistDatabase.Models
{
    public enum GenderCategories {
        [DisplayAttribute(Name = "Male")]
        Male,
        [DisplayAttribute(Name = "Female")]
        Female,
        [DisplayAttribute(Name = "Nonbinary")]
        Nonbinary 
    };

    public enum SpecialtyCategories
    {
        [DisplayAttribute(Name = "Child and Family")]
        Child,  // "Child and Family"
        [DisplayAttribute(Name = "Trauma and PTSD")]
        Trauma, // "Trauma and PTSD"
        [DisplayAttribute(Name = "Substance-Use Disorders")]
        Drug,   // "Substance-Use Disorders"
        [DisplayAttribute(Name = "Depression and Anxiety")]
        Dep,    // "Depression and Anxiety"
        [DisplayAttribute(Name = "ADHD, ADD, and Related")]
        ADHD,
        [DisplayAttribute(Name = "Personality Disorders")]
        Pers,   // "Personality Disorders"
        Other   // "Other"
    };

    public class Provider
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public SpecialtyCategories? Specialties { get; set; }  

        public int Age { get; set; }
        public GenderCategories Gender { get; set; }
        public string PhotoPath { get; set; }
               
        public Provider()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            PhotoPath = "";
        }
    }
}
