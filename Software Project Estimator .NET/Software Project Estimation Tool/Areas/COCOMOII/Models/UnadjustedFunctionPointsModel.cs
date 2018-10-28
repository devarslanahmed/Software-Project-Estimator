using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Models
{
    public class UnadjustedFunctionPointsModel
    {


        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EI_LOW { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EI_AVERAGE { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EI_HIGH { get; set; }


        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EO_LOW { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EO_AVERAGE { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EO_HIGH { get; set; }


        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EQ_LOW { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EQ_AVERAGE { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EQ_HIGH { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EIF_LOW { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EIF_AVERAGE { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String EIF_HIGH { get; set; }


        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String ILF_LOW { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String ILF_AVERAGE { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "*Whole No.")]
        public String ILF_HIGH { get; set; }


    }
}