using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOI.Models
{
    public class CostDriversModel
    {
        public List<SelectListItem> RELY { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String RELY_VALUE { get; set; }


        public List<SelectListItem> DATA { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String DATA_VALUE { get; set; }


        public List<SelectListItem> CPLX { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String CPLX_VALUE { get; set; }


        public List<SelectListItem> TIME { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String TIME_VALUE { get; set; }


        public List<SelectListItem> STOR { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String STOR_VALUE { get; set; }



        public List<SelectListItem> VIRT { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String VIRT_VALUE { get; set; }



        public List<SelectListItem> TURN { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String TURN_VALUE { get; set; }



        public List<SelectListItem> ACAP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String ACAP_VALUE { get; set; }



        public List<SelectListItem> AEXP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String AEXP_VALUE { get; set; }



        public List<SelectListItem> PCAP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PCAP_VALUE { get; set; }



        public List<SelectListItem> VEXP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String VEXP_VALUE { get; set; }



        public List<SelectListItem> LEXP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String LEXP_VALUE { get; set; }



        public List<SelectListItem> MODP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String MODP_VALUE { get; set; }



        public List<SelectListItem> TOOL { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String TOOL_VALUE { get; set; }


        public List<SelectListItem> SCED { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String SCED_VALUE { get; set; }






    }
}