using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Software_Project_Estimation_Tool.Areas.SLIM.Models
{
    public class TimeModel
    {
        [Required(ErrorMessage = "*Required")]
        public int month { get; set; }
    }
}