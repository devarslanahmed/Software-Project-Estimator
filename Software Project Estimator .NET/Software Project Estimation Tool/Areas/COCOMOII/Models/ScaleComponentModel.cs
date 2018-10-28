using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Models
{
    public class ScaleComponentModel
    {


        public List<SelectListItem> PREC { get; set; }
        [Required(ErrorMessage = "*Required")]
        public double PREC_VALUE { get; set; }

        public List<SelectListItem> FLEX { get; set; }
        [Required(ErrorMessage = "*Required")]
        public double FLEX_VALUE { get; set; }

        public List<SelectListItem> RESL { get; set; }
        [Required(ErrorMessage = "*Required")]
        public double RESL_VALUE { get; set; }

        public List<SelectListItem> TEAM { get; set; }
        [Required(ErrorMessage = "*Required")]
        public double TEAM_VALUE { get; set; }

        public List<SelectListItem> PMAT { get; set; }
        [Required(ErrorMessage = "*Required")]
        public double PMAT_VALUE { get; set; }


    }
}