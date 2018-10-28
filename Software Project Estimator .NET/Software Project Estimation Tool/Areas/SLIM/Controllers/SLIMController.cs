using Software_Project_Estimation_Tool.Areas.SLIM.Models;
using Software_Project_Estimation_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.SLIM.Controllers
{
    public class SLIMController : Controller
    {
        // GET: SLIM/SLIM

        public ActionResult Index()
        {
            return RedirectToAction("TotalEffort");
        }

        public ActionResult SLIM()
        {
            return View();
        }


        #region Process Productivity

        

        public static List<SelectListItem> AppTypeList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Microcode", Value = "987" },
                new SelectListItem { Text = "Firmware (ROM)", Value = "1597" },
                new SelectListItem { Text = "Real-time embedded", Value = "1974" },
                new SelectListItem { Text = "Radar Systems", Value = "3194" },
                new SelectListItem { Text = "Command and Control", Value = "4181" },
                new SelectListItem { Text = "Process Control", Value = "5186" },
                new SelectListItem { Text = "Telecommunications", Value = "8362" },
                new SelectListItem { Text = "System Software", Value = "13530" },
                new SelectListItem { Text = "Business Systems", Value = "28657" }
            };
            return item;
        }



        public ActionResult ProcessProductivity() {

            ProcessProductivityModel model = new ProcessProductivityModel() {

                APP_TYPE = AppTypeList()

            };


            return View(model);
        }

        [HttpPost]
        public ActionResult ProcessProductivity(ProcessProductivityModel model)
        {

            model.APP_TYPE = AppTypeList();
            double valueApplicationType= model.APP_TYPE_VALUE;

            var textApplicationType = model.APP_TYPE.Find(p => p.Value == model.APP_TYPE_VALUE.ToString());

            if (textApplicationType !=null) {

                textApplicationType.Selected = true;




                Session["valueApplicationType"] = valueApplicationType;
                Session["textApplicationType"] = textApplicationType.Text;


                return RedirectToAction("Time", "SLIM");

            }
           

            else
            return View(model);
        }


        #endregion
        


        #region time
        public ActionResult Time()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Time(TimeModel t)
        {
            if (t.month!=0)
            {

                Session["DevelopmentTime"] = t.month;

                return RedirectToAction("TotalEffort", "SLIM");

            }

            return View();
        }





        #endregion

        #region Total Effort


        public ActionResult TotalEffort() {

            //in years
            double resultDevelopmentTime =( Convert.ToDouble(Session["DevelopmentTime"]))/12;

            int resultUnadjustedFuctionPoints = Convert.ToInt32(Session["resultUnadjustedFuctionPoints"]);
            double resultValueAdjustmentFactors = Convert.ToDouble(Session["resultValueAdjustmentFactors"]);
            int valueLanguageFactor = Convert.ToInt32(Session["valueLanguageFactor"]);


            double valueApplicationType = Convert.ToDouble(Session["valueApplicationType"]);


            //Calculate Function Points
            double resultFunctionPoints = Math.Ceiling(resultUnadjustedFuctionPoints * resultValueAdjustmentFactors);



            //Calculate Size in sloc
           
            double resultSize = Math.Ceiling(resultFunctionPoints * valueLanguageFactor);


            //Calculate B (Total Effort)


            double resultB = Math.Ceiling( Math.Pow(resultSize/(valueApplicationType*(Math.Pow(resultDevelopmentTime,1.33))),3));

          
            //Calculate Effort (At Delivery Time)
            double resultEffort = 0.3935 * resultB;



            //Process Productivity
            double resultProcessProductivity = valueApplicationType;


            //Manpower Acceleration
            double resultManpowerAcceleration = resultB / Math.Pow(resultDevelopmentTime, 3);

            #region Sessions for Report


            Session["resultDevelopmentTime"] = resultDevelopmentTime;
            Session["resultSize"] =Math.Round(resultSize,0);
            Session["resultB"] = resultB;
            Session["resultEffort"] =Math.Ceiling( resultEffort);
            Session["resultProcessProductivity"] = resultProcessProductivity;

            Session["resultManpowerAcceleration"] = Math.Ceiling(resultManpowerAcceleration);





            #endregion


            

            return View();
        }

        public ActionResult SaveTotalEffort()
        {
            Project p = new Project();

            p.Username = Session["user"].ToString();
            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();
            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<table> <tr> <td>Project Name: </td> <td>" +
                "" + Session["valueProjectName"] + "</td> </tr> <tr> <td>Process Model: </td> <td>" + Session["valueProcessModel"] + "</td> </tr> " +
                "</table>" +
                 "<br/> <hr/>" +
                "<b>Process Productivity: </b> " +
                "<table > <tr> <td>Application Type: </td> <td>" + Session["textApplicationType"] + "</td> </tr> " +
                "<tr> <td>Productivity Parameter: </td> <td>"+Session["valueApplicationType"]+"</td> </tr>" +
                "</table>" +
                 "<br/> <hr/>" +
                "  <b> Unadjusted Function Points: </b> " +
                " <br>" +
                "<table> <tr> <th>Elements</th> <th colspan='3'>Complexity Weighting Factors</th> </tr> <tr> <td><h4><i></i></h4></td>" +
                " <td><i>Low</i></td> <td><i>Average</i></td> <td><i>High</i></td> </tr> <tr> <td><p>External Inputs (EI)</p></td> <td>" +
                 Session["EI_LOW"].ToString() + " </td> <td> " + Session["EI_AVERAGE"].ToString() + " </td> <td>" + Session["EI_HIGH"].ToString() + " </td> </tr> " +
                "<tr> <td><p>External Outputs (EO)</p></td> <td>" + Session["EO_LOW"].ToString() + " </td> <td> " + Session["EO_AVERAGE"].ToString() + " </td> " +
                "<td> " + Session["EO_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Inquiries (EQ)</p></td> <td>" + Session["EQ_LOW"].ToString() + " </td>" +
                " <td> " + Session["EQ_AVERAGE"].ToString() + " </td> <td>" + Session["EQ_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Interface files (EIF)</p></td>" +
                " <td> " + Session["EIF_LOW"].ToString() + "</td> <td> " + Session["EIF_AVERAGE"].ToString() + " </td> <td>" + Session["EIF_HIGH"].ToString() + " </td> </tr> <tr> <td>" +
                "<p>Internal Logical files (ILF)</p></td> <td> " + Session["ILF_LOW"].ToString() + " </td> <td>" + Session["ILF_AVERAGE"].ToString() + " </td> " +
                "<td>" + Session["ILF_HIGH"].ToString() + " </td> </tr> <tr> <th>Total: </th> <td>" + Session["resultUnadjustedFuctionPoints"].ToString() + "</td> </tr> </table>" +
                 "<br/> <hr/>" +
                 "<b>Language Factor: </b> <table> <tr> <td>Selected Language: </td> <td>" + Session["textLanguageFactor"] + "" +
                "</td> </tr> </table>" +
                  "<br/> <hr/>" +
                "<b>Value Adjustment Factors: </b> " +
                "<table> <tr> <td>Data Communication</td> <td>Distributed Data Processing</td> <td>Performance</td> </tr> <tr>" +
                " <td>" + Session["valueFactorDC"].ToString() + "</td> <td>" + Session["valueFactorDDP"].ToString() + "</td> <td>" + Session["valueFactorPER"].ToString() + "</td> </tr> <tr> " +
                "<td>Heavly Used Configuration</td> <td>Transaction Rate</td> <td>Online Data Entry</td> </tr> <tr> <td>" + Session["valueFactorHUC"].ToString() + "</td> " +
                "<td>" + Session["valueFactorTR"].ToString() + "</td> <td>" + Session["valueFactorODE"].ToString() + "</td> </tr> <tr> <td>End User Efficiency</td> <td>Online Updates" +
                "</td> <td>Complex Processing</td> </tr> <tr> <td>" + Session["valueFactorEUE"].ToString() + "</td> <td>" + Session["valueFactorOU"].ToString() + "</td> " +
                "<td>" + Session["valueFactorCP"].ToString() + "</td> </tr> <tr> <td>Resuabilty</td> <td>Installation Ease</td> <td>Operational Ease</td> </tr> <tr> <td>" + Session["valueFactorREU"].ToString() + "</td>" +
                " <td>" + Session["valueFactorIE"].ToString() + "</td> <td>" + Session["valueFactorOE"].ToString() + "</td> </tr> <tr> <td>Multiple Sites</td> <td>Facilitate Change</td> </tr> <tr>" +
                " <td>" + Session["valueFactorMS"].ToString() + "</td> <td>" + Session["valueFactorFC"].ToString() + "</td> </tr> <tr> <th>Total:</th> " +
                "<td>" + Session["resultValueAdjustmentFactors"].ToString() + "</td> </tr> </table>" +
                 "<br/> <hr/>" +
                "<b>Final Estimations: </b> <table> <tr> <td>Size: " + Session["resultSize"] + "(LOC)" +
                "</td> </tr> <tr> <td>Time:" + Session["resultDevelopmentTime"] +"(years)</td> </tr> <tr> <td>Process Productivity: " +
                "" + Session["resultProcessProductivity"] + "</td> </tr> <tr> <td>Total Effort: " +
                "" + Session["resultB"] + "(Person-year) </td> </tr> <tr> <td>Effort at delivery time: " + Session["resultEffort"] + "(Persons-years)</td> " +
                "</tr> <tr> <td>Manpower Acceleration:" + Session["resultManpowerAcceleration"] + "</td> </tr> </table>";

            try
            {
                using (SPEToolDBEntities db = new SPEToolDBEntities())
                {
                    db.Projects.Add(p);
                    db.SaveChanges();

                    TempData["SuccessMSG"] = "Saved";
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return RedirectToAction("Index", "Error");
            }

            ViewBag.MSG = "Saved";


            return RedirectToAction("TotalEffort");
        }



        #endregion





    }
}