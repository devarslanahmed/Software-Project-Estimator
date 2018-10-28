using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Models
{
    public class CostDriversEDMModel
    {

        public List<SelectListItem> RCPX { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String RCPX_VALUE { get; set; }


        public List<SelectListItem> RUSE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String RUSE_VALUE { get; set; }


        public List<SelectListItem> PDIF { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PDIF_VALUE { get; set; }


        public List<SelectListItem> PERS { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PERS_VALUE { get; set; }


        public List<SelectListItem> PREX { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PREX_VALUE { get; set; }


        public List<SelectListItem> FCIL { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String FCIL_VALUE { get; set; }


        public List<SelectListItem> SCED { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String SCED_VALUE { get; set; }



    }
}