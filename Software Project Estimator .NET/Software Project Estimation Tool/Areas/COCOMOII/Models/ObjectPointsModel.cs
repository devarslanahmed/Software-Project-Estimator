using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Models
{
    public class ObjectPointsModel
    {



        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? SCREEN_SIMPLE { get; set; }
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? SCREEN_MEDIUM { get; set; }
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? SCREEN_DIFFICULT { get; set; }


        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int SCREEN_TOTAL { get; set; }


        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? REPORT_SIMPLE { get; set; }
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? REPORT_MEDIUM { get; set; }
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? REPORT_DIFFICULT { get; set; }


        [Required(ErrorMessage = "*Required")]
        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int REPORT_TOTAL { get; set; }



        [RegularExpression("([0-9][0-9]*)", ErrorMessage = "Enter Whole Number")]
        public int? MODULE_3GL { get; set; }


        [Required(ErrorMessage = "*Required")]
        public double REUSE_PERCENTAGE { get; set; }





    }
}