using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Models
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



        public List<SelectListItem> RUSE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String RUSE_VALUE { get; set; }


        public List<SelectListItem> DOCU { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String DOCU_VALUE { get; set; }






        //

        public List<SelectListItem> TIME { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String TIME_VALUE { get; set; }


        public List<SelectListItem> PVOL { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PVOL_VALUE { get; set; }

        

        public List<SelectListItem> STOR { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String STOR_VALUE { get; set; }



            //
        public List<SelectListItem> ACAP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String ACAP_VALUE { get; set; }


        public List<SelectListItem> PCON { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PCON_VALUE { get; set; }



        public List<SelectListItem> PEXP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PEXP_VALUE { get; set; }



        public List<SelectListItem> PCAP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String PCAP_VALUE { get; set; }


        public List<SelectListItem> AEXP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String AEXP_VALUE { get; set; }






        public List<SelectListItem> LTEX { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String LTEX_VALUE { get; set; }





        public List<SelectListItem> TOOL { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String TOOL_VALUE { get; set; }


        public List<SelectListItem> SCED { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String SCED_VALUE { get; set; }



        public List<SelectListItem> SITE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public String SITE_VALUE { get; set; }





    }
}