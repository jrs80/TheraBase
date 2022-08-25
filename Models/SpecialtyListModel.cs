using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace TherapistDatabase.Models
{
    public static class SpecialtyListModel
    {

        public static List<SelectListItem> Specs { get; } = new List<SelectListItem> {
           new SelectListItem { Value = "DepressionAndAnxiety", Text = "Depression & Anxiety" },
           new SelectListItem { Value = "TraumaAndPTSD", Text = "Trauma and PTSD" },
           new SelectListItem { Value = "SubstanceUseDisorders", Text = "Substance-Use Disorders"    },
           new SelectListItem { Value = "MarriageAndFamily", Text = "Marriage & Family" },
           new SelectListItem { Value = "Other", Text = "Other"}
       };


        public static List<string> SpecList { get; } = new List<string>
            {
       
           "Depression & Anxiety",
           "Trauma and PTSD",
                "Substance-Use Disorders",
                "Marriage & Family",
                "Other"
             };

    }
}
