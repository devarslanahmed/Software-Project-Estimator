using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Models
{
    public class ProjectNameModel
    {



        [Required(ErrorMessage = "Field Required")]
        public string PROJECT_NAME { get; set; }



        public List<SelectListItem> PROCESS_MODEL { get; set; }
        [Required(ErrorMessage = "Not selected")]
        public String PROCESS_MODEL_VALUE { get; set; }
    }
}