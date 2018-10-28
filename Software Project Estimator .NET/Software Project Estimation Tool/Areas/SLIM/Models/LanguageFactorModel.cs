using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.SLIM.Models
{
    public class LanguageFactorModel
    {

        public List<SelectListItem> LANGUAGE_FACTOR { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int LANGUAGE_FACTOR_VALUE { get; set; }
    }
}