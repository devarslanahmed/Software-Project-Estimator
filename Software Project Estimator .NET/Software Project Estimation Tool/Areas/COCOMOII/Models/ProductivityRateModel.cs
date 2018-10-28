using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Models
{
    public class ProductivityRateModel
    {


        public List<SelectListItem> DEVELOPER_EXPERIENCE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int DEVELOPER_EXPERIENCE_VALUE { get; set; }

    }
}