using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.SLIM.Models
{
    public class ValueAdjustmentFactorsModel
    {


        public List<SelectListItem> FACTOR_DC { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_DC_VALUE { get; set; }

        public List<SelectListItem> FACTOR_DDP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_DDP_VALUE { get; set; }

        public List<SelectListItem> FACTOR_PER { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_PER_VALUE { get; set; }

        public List<SelectListItem> FACTOR_HUC { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_HUC_VALUE { get; set; }

        public List<SelectListItem> FACTOR_TR { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_TR_VALUE { get; set; }

        public List<SelectListItem> FACTOR_ODE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_ODE_VALUE { get; set; }

        public List<SelectListItem> FACTOR_EUE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_EUE_VALUE { get; set; }

        public List<SelectListItem> FACTOR_OU { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_OU_VALUE { get; set; }

        public List<SelectListItem> FACTOR_CP { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_CP_VALUE { get; set; }

        public List<SelectListItem> FACTOR_REU { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_REU_VALUE { get; set; }

        public List<SelectListItem> FACTOR_IE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_IE_VALUE { get; set; }

        public List<SelectListItem> FACTOR_OE { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_OE_VALUE { get; set; }

        public List<SelectListItem> FACTOR_MS { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_MS_VALUE { get; set; }

        public List<SelectListItem> FACTOR_FC { get; set; }
        [Required(ErrorMessage = "*Required")]
        public int FACTOR_FC_VALUE { get; set; }

    }
}