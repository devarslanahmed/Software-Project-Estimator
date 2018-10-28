using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.SLIM.Models
{
    public class ProcessProductivityModel
    {

        public List<SelectListItem> APP_TYPE { get; set; }

        [Required(ErrorMessage = "*Required")]
        public double APP_TYPE_VALUE { get; set; }

    }
}