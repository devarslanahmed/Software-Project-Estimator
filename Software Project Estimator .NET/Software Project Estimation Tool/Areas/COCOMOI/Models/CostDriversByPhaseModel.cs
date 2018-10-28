using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOI.Models
{
    public class CostDriversByPhaseModel
    {


        //RDP

        public List<SelectListItem> RELY_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String RELY_RPD_VALUE { get; set; }


        public List<SelectListItem> DATA_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String DATA_RPD_VALUE { get; set; }

        public List<SelectListItem> CPLX_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String CPLX_RPD_VALUE { get; set; }

        public List<SelectListItem> TIME_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TIME_RPD_VALUE { get; set; }

        public List<SelectListItem> STOR_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String STOR_RPD_VALUE { get; set; }

        public List<SelectListItem> VIRT_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VIRT_RPD_VALUE { get; set; }

        public List<SelectListItem> TURN_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TURN_RPD_VALUE { get; set; }

        public List<SelectListItem> ACAP_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String ACAP_RPD_VALUE { get; set; }

        public List<SelectListItem> AEXP_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String AEXP_RPD_VALUE { get; set; }

        public List<SelectListItem> PCAP_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String PCAP_RPD_VALUE { get; set; }

        public List<SelectListItem> VEXP_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VEXP_RPD_VALUE { get; set; }

        public List<SelectListItem> LEXP_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String LEXP_RPD_VALUE { get; set; }

        public List<SelectListItem> MODP_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String MODP_RPD_VALUE { get; set; }

        public List<SelectListItem> TOOL_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TOOL_RPD_VALUE { get; set; }

        public List<SelectListItem> SCED_RPD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String SCED_RPD_VALUE { get; set; }


        //DD

        public List<SelectListItem> RELY_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String RELY_DD_VALUE { get; set; }


        public List<SelectListItem> DATA_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String DATA_DD_VALUE { get; set; }

        public List<SelectListItem> CPLX_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String CPLX_DD_VALUE { get; set; }

        public List<SelectListItem> TIME_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TIME_DD_VALUE { get; set; }

        public List<SelectListItem> STOR_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String STOR_DD_VALUE { get; set; }

        public List<SelectListItem> VIRT_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VIRT_DD_VALUE { get; set; }

        public List<SelectListItem> TURN_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TURN_DD_VALUE { get; set; }

        public List<SelectListItem> ACAP_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String ACAP_DD_VALUE { get; set; }

        public List<SelectListItem> AEXP_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String AEXP_DD_VALUE { get; set; }

        public List<SelectListItem> PCAP_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String PCAP_DD_VALUE { get; set; }

        public List<SelectListItem> VEXP_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VEXP_DD_VALUE { get; set; }

        public List<SelectListItem> LEXP_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String LEXP_DD_VALUE { get; set; }

        public List<SelectListItem> MODP_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String MODP_DD_VALUE { get; set; }

        public List<SelectListItem> TOOL_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TOOL_DD_VALUE { get; set; }

        public List<SelectListItem> SCED_DD { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String SCED_DD_VALUE { get; set; }


        // CUT


        public List<SelectListItem> RELY_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String RELY_CUT_VALUE { get; set; }


        public List<SelectListItem> DATA_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String DATA_CUT_VALUE { get; set; }

        public List<SelectListItem> CPLX_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String CPLX_CUT_VALUE { get; set; }

        public List<SelectListItem> TIME_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TIME_CUT_VALUE { get; set; }

        public List<SelectListItem> STOR_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String STOR_CUT_VALUE { get; set; }

        public List<SelectListItem> VIRT_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VIRT_CUT_VALUE { get; set; }

        public List<SelectListItem> TURN_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TURN_CUT_VALUE { get; set; }

        public List<SelectListItem> ACAP_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String ACAP_CUT_VALUE { get; set; }

        public List<SelectListItem> AEXP_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String AEXP_CUT_VALUE { get; set; }

        public List<SelectListItem> PCAP_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String PCAP_CUT_VALUE { get; set; }

        public List<SelectListItem> VEXP_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VEXP_CUT_VALUE { get; set; }

        public List<SelectListItem> LEXP_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String LEXP_CUT_VALUE { get; set; }

        public List<SelectListItem> MODP_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String MODP_CUT_VALUE { get; set; }

        public List<SelectListItem> TOOL_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TOOL_CUT_VALUE { get; set; }

        public List<SelectListItem> SCED_CUT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String SCED_CUT_VALUE { get; set; }



        // IT



        public List<SelectListItem> RELY_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String RELY_IT_VALUE { get; set; }


        public List<SelectListItem> DATA_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String DATA_IT_VALUE { get; set; }

        public List<SelectListItem> CPLX_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String CPLX_IT_VALUE { get; set; }

        public List<SelectListItem> TIME_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TIME_IT_VALUE { get; set; }

        public List<SelectListItem> STOR_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String STOR_IT_VALUE { get; set; }

        public List<SelectListItem> VIRT_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VIRT_IT_VALUE { get; set; }

        public List<SelectListItem> TURN_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TURN_IT_VALUE { get; set; }

        public List<SelectListItem> ACAP_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String ACAP_IT_VALUE { get; set; }

        public List<SelectListItem> AEXP_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String AEXP_IT_VALUE { get; set; }

        public List<SelectListItem> PCAP_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String PCAP_IT_VALUE { get; set; }

        public List<SelectListItem> VEXP_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String VEXP_IT_VALUE { get; set; }

        public List<SelectListItem> LEXP_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String LEXP_IT_VALUE { get; set; }

        public List<SelectListItem> MODP_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String MODP_IT_VALUE { get; set; }

        public List<SelectListItem> TOOL_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String TOOL_IT_VALUE { get; set; }

        public List<SelectListItem> SCED_IT { get; set; }

        [Required(ErrorMessage = "*Required")]
        public String SCED_IT_VALUE { get; set; }


    }
}