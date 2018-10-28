using Software_Project_Estimation_Tool.Areas.COCOMOI.Models;
using Software_Project_Estimation_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOI.Controllers
{
    public class COCOMOIController : Controller
    {
        // GET: COCOMOI/COCOMOI

        public ActionResult Index()
        {

            if (@Session["Stage"].ToString() == "Basic Stage")
            {
                return RedirectToAction("ResultBasicStage", "COCOMOI");
            }
            else if (@Session["Stage"].ToString() == "Intermediate Stage")
            {
                return RedirectToAction("ResultIntermediateStage", "COCOMOI");
            }
            else if (@Session["Stage"].ToString() == "Advanced Stage")
            {
                return RedirectToAction("ResultAdvancedStage", "COCOMOI");
            }
            else
            {
                return View();
            }

        }


        #region COCOMOI

        public ActionResult COCOMOI()
        {


            return View();
        }


        #endregion

      

        #region Select Stage

        public ActionResult SelectStage()
        {


            return View();
        }


        #endregion

        #region Select Mode

        public ActionResult SelectMode(String Stage)
        {
            Session["Stage"] = Stage;

            return View();
        }


        #endregion
        

        #region Cost Drivers


        #region Lists Cost Drivers


        public static List<SelectListItem> RELYList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "0.75" },
                new SelectListItem { Text = "Low", Value = "0.88" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.15" },
                new SelectListItem { Text = "Very High", Value = "1.40" }
            };

            return item;

        }

        public static List<SelectListItem> DATAList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low", Value = "0.94" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.08" },
                new SelectListItem { Text = "Very High", Value = "1.16" }
            };
            return item;
        }


        public static List<SelectListItem> CPLXList()
        {

            List<SelectListItem> item = new List<SelectListItem>();

            item.Add(new SelectListItem { Text = "Very Low", Value = "0.70" });
            item.Add(new SelectListItem { Text = "Low", Value = "0.85" });
            item.Add(new SelectListItem { Text = "Nominal", Value = "1.0" });
            item.Add(new SelectListItem { Text = "High", Value = "1.15" });
            item.Add(new SelectListItem { Text = "Very High", Value = "1.30" });
            item.Add(new SelectListItem { Text = "Extra High", Value = "1.65" });
            return item;
        }


        public static List<SelectListItem> TIMEList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.11" },
                new SelectListItem { Text = "Very High", Value = "1.30" },
                new SelectListItem { Text = "Extra High", Value = "1.66" }
            };
            return item;
        }


        public static List<SelectListItem> STORList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.06" },
                new SelectListItem { Text = "Very High", Value = "1.21" },
                new SelectListItem { Text = "Extra High", Value = "1.56" }
            };
            return item;
        }


        public static List<SelectListItem> VIRTList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low", Value = "0.87" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.15" },
                new SelectListItem { Text = "Very High", Value = "1.30" }
            };
            return item;
        }


        public static List<SelectListItem> TURNList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low", Value = "0.87" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.07" },
                new SelectListItem { Text = "Very High", Value = "1.15" }
            };
            return item;
        }


        public static List<SelectListItem> ACAPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.46" },
                new SelectListItem { Text = "Low", Value = "1.19" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.86" },
                new SelectListItem { Text = "Very High", Value = "0.71" }
            };
            return item;
        }


        public static List<SelectListItem> AEXPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.29" },
                new SelectListItem { Text = "Low", Value = "1.13" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.91" },
                new SelectListItem { Text = "Very High", Value = "0.82" }
            };
            return item;
        }


        public static List<SelectListItem> PCAPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.42" },
                new SelectListItem { Text = "Low", Value = "1.17" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.86" },
                new SelectListItem { Text = "Very High", Value = "0.70" }
            };
            return item;
        }


        public static List<SelectListItem> VEXPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.21" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.90" }
            };
            return item;
        }


        public static List<SelectListItem> LEXPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.14" },
                new SelectListItem { Text = "Low", Value = "1.07" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.95" }
            };
            return item;
        }


        public static List<SelectListItem> MODPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.24" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.91" },
                new SelectListItem { Text = "Very High", Value = "0.82" }
            };
            return item;
        }


        public static List<SelectListItem> TOOLList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.24" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.91" },
                new SelectListItem { Text = "Very High", Value = "0.83" }
            };
            return item;
        }


        public static List<SelectListItem> SCEDList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.23" },
                new SelectListItem { Text = "Low", Value = "1.08" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.04" },
                new SelectListItem { Text = "Very High", Value = "1.10" }
            };
            return item;
        }

        #endregion


        #region Calculate Cost Drivers



        public ActionResult CostDrivers(String Mode, double? a, double? b, double? c, double? d)
        {


            Session["Mode"] = Mode;
            Session["a"] = a;
            Session["b"] = b;
            Session["c"] = c;
            Session["d"] = d;


            CostDriversModel costDriversModel = new CostDriversModel
            {

                RELY = RELYList(),
                DATA = DATAList(),
                CPLX = CPLXList(),
                TIME = TIMEList(),
                STOR = STORList(),
                VIRT = VIRTList(),
                TURN = TURNList(),
                ACAP = ACAPList(),
                AEXP = AEXPList(),
                PCAP = PCAPList(),
                VEXP = VEXPList(),
                LEXP = LEXPList(),
                MODP = MODPList(),
                TOOL = TOOLList(),
                SCED = SCEDList()
            };
            return View(costDriversModel);
        }



        [HttpPost]

        public ActionResult CostDrivers(CostDriversModel costDriversModel)
        {

            costDriversModel.RELY = RELYList();
            costDriversModel.DATA = DATAList();
            costDriversModel.CPLX = CPLXList();
            costDriversModel.TIME = TIMEList();
            costDriversModel.STOR = STORList();
            costDriversModel.VIRT = VIRTList();
            costDriversModel.TURN = TURNList();
            costDriversModel.ACAP = ACAPList();
            costDriversModel.AEXP = AEXPList();
            costDriversModel.PCAP = PCAPList();
            costDriversModel.VEXP = VEXPList();
            costDriversModel.LEXP = LEXPList();
            costDriversModel.MODP = MODPList();
            costDriversModel.TOOL = TOOLList();
            costDriversModel.SCED = SCEDList();


            String valueRELY = costDriversModel.RELY_VALUE;
            String valueDATA = costDriversModel.DATA_VALUE;
            String valueCPLX = costDriversModel.CPLX_VALUE;
            String valueTIME = costDriversModel.TIME_VALUE;
            String valueSTOR = costDriversModel.STOR_VALUE;
            String valueVIRT = costDriversModel.VIRT_VALUE;
            String valueTURN = costDriversModel.TURN_VALUE;
            String valueACAP = costDriversModel.ACAP_VALUE;
            String valueAEXP = costDriversModel.AEXP_VALUE;
            String valuePCAP = costDriversModel.PCAP_VALUE;
            String valueVEXP = costDriversModel.VEXP_VALUE;
            String valueLEXP = costDriversModel.LEXP_VALUE;
            String valueMODP = costDriversModel.MODP_VALUE;
            String valueTOOL = costDriversModel.TOOL_VALUE;
            String valueSCED = costDriversModel.SCED_VALUE;


         

            if(valueRELY != null &&
               valueDATA != null &&
               valueCPLX != null &&
               valueTIME != null &&
               valueSTOR != null &&
               valueVIRT != null &&
               valueTURN != null &&
               valueACAP != null &&
               valueAEXP != null &&
               valuePCAP != null &&
               valueVEXP != null &&
               valueLEXP != null &&
               valueMODP != null &&
               valueTOOL != null &&
               valueSCED != null)
            {

                double fvalueRELY = Convert.ToDouble(valueRELY);
                double fvalueDATA = Convert.ToDouble(valueDATA);
                double fvalueCPLX = Convert.ToDouble(valueCPLX);
                double fvalueTIME = Convert.ToDouble(valueTIME);
                double fvalueSTOR = Convert.ToDouble(valueSTOR);
                double fvalueVIRT = Convert.ToDouble(valueVIRT);
                double fvalueTURN = Convert.ToDouble(valueTURN);
                double fvalueACAP = Convert.ToDouble(valueACAP);
                double fvalueAEXP = Convert.ToDouble(valueAEXP);
                double fvaluePCAP = Convert.ToDouble(valuePCAP);
                double fvalueVEXP = Convert.ToDouble(valueVEXP);
                double fvalueLEXP = Convert.ToDouble(valueLEXP);
                double fvalueMODP = Convert.ToDouble(valueMODP);
                double fvalueTOOL = Convert.ToDouble(valueTOOL);
                double fvalueSCED = Convert.ToDouble(valueSCED);


                double resultCostDrivers = fvalueRELY * fvalueDATA * fvalueCPLX * fvalueTIME * fvalueSTOR * fvalueVIRT * fvalueTURN * fvalueACAP * fvalueAEXP * fvaluePCAP * fvalueVEXP * fvalueLEXP * fvalueMODP * fvalueTOOL * fvalueSCED;

                Session["resultEffortAdjustmentFactor"] = Math.Round(resultCostDrivers, 2);




                //Texts
                var textRELY = costDriversModel.RELY.Find(m => m.Value == costDriversModel.RELY_VALUE.ToString());
                if (textRELY != null)
                {
                    textRELY.Selected = true;
                    Session["textRELY"] = textRELY.Text;
                }



                var textDATA = costDriversModel.DATA.Find(m => m.Value == costDriversModel.DATA_VALUE.ToString());
                if (textDATA != null)
                {
                    textDATA.Selected = true;
                    Session["textDATA"] = textDATA.Text;
                }


                var textCPLX = costDriversModel.CPLX.Find(m => m.Value == costDriversModel.CPLX_VALUE.ToString());
                if (textCPLX != null)
                {
                    textCPLX.Selected = true;
                    Session["textCPLX"] = textCPLX.Text;
                }

                var textMODP = costDriversModel.MODP.Find(m => m.Value == costDriversModel.MODP_VALUE.ToString());
                if (textMODP != null)
                {
                    textMODP.Selected = true;
                    Session["textMODP"] = textMODP.Text;
                }



                var textTOOL = costDriversModel.TOOL.Find(m => m.Value == costDriversModel.TOOL_VALUE.ToString());
                if (textTOOL != null)
                {
                    textTOOL.Selected = true;
                    Session["textTOOL"] = textTOOL.Text;
                }

                var textSCED = costDriversModel.SCED.Find(m => m.Value == costDriversModel.SCED_VALUE.ToString());
                if (textSCED != null)
                {
                    textSCED.Selected = true;
                    Session["textSCED"] = textSCED.Text;
                }

                var textACAP = costDriversModel.ACAP.Find(m => m.Value == costDriversModel.ACAP_VALUE.ToString());
                if (textACAP != null)
                {
                    textACAP.Selected = true;
                    Session["textACAP"] = textACAP.Text;
                }


                var textAEXP = costDriversModel.AEXP.Find(m => m.Value == costDriversModel.AEXP_VALUE.ToString());
                if (textAEXP != null)
                {
                    textAEXP.Selected = true;
                    Session["textAEXP"] = textAEXP.Text;
                }


                var textPCAP = costDriversModel.PCAP.Find(m => m.Value == costDriversModel.PCAP_VALUE.ToString());
                if (textPCAP != null)
                {
                    textPCAP.Selected = true;
                    Session["textPCAP"] = textPCAP.Text;
                }

                var textVEXP = costDriversModel.VEXP.Find(m => m.Value == costDriversModel.VEXP_VALUE.ToString());
                if (textVEXP != null)
                {
                    textVEXP.Selected = true;
                    Session["textVEXP"] = textVEXP.Text;
                }

                var textLEXP = costDriversModel.LEXP.Find(m => m.Value == costDriversModel.LEXP_VALUE.ToString());
                if (textLEXP != null)
                {
                    textLEXP.Selected = true;
                    Session["textLEXP"] = textLEXP.Text;
                }



                var textTIME = costDriversModel.TIME.Find(m => m.Value == costDriversModel.TIME_VALUE.ToString());
                if (textTIME != null)
                {
                    textTIME.Selected = true;
                    Session["textTIME"] = textTIME.Text;
                }


                var textSTOR = costDriversModel.STOR.Find(m => m.Value == costDriversModel.STOR_VALUE.ToString());
                if (textSTOR != null)
                {
                    textSTOR.Selected = true;
                    Session["textSTOR"] = textSTOR.Text;
                }

                var textVIRT = costDriversModel.VIRT.Find(m => m.Value == costDriversModel.VIRT_VALUE.ToString());
                if (textVIRT != null)
                {
                    textVIRT.Selected = true;
                    Session["textVIRT"] = textVIRT.Text;
                }



                var textTURN = costDriversModel.TURN.Find(m => m.Value == costDriversModel.TURN_VALUE.ToString());
                if (textTURN != null)
                {
                    textTURN.Selected = true;
                    Session["textTURN"] = textTURN.Text;
                }



                



                #region Sessions for Report

                Session["textRELY"] = textRELY.Text;
                Session["textDATA"] = textDATA.Text;
                Session["textCPLX"] = textCPLX.Text;
                Session["textTIME"] = textTIME.Text;
                Session["textSTOR"] = textSTOR.Text;
                Session["textVIRT"] = textVIRT.Text;
                Session["textTURN"] = textTURN.Text;
                Session["textACAP"] = textACAP.Text;
                Session["textAEXP"] = textAEXP.Text;
                Session["textPCAP"] = textPCAP.Text;
                Session["textVEXP"] = textVEXP.Text;
                Session["textLEXP"] = textLEXP.Text;
                Session["textMODP"] = textMODP.Text;
                Session["textTOOL"] = textTOOL.Text;
                Session["textSCED"] = textSCED.Text;



                #endregion



                String Stage = Session["Stage"].ToString();

                if (Stage.Equals("Basic Stage"))
                {


                    //  return RedirectToAction("ResultBasicStage", "COCOMOI");
                }

                if (Stage.Equals("Intermediate Stage"))
                {

                    return RedirectToAction("ResultIntermediateStage", "COCOMOI");

                }

                if (Stage.Equals("Advanced Stage"))
                {

                    return RedirectToAction("ResultAdvancedStage", "COCOMOI");

                }



            }


            return View(costDriversModel);
        }




        #endregion

        #endregion

        #region PreBasic
             public ActionResult XBasicStage(String Mode, double? a, double? b, double? c, double? d)
                    {

                        Session["Mode"] = Mode;
                        Session["a"] = a;
                        Session["b"] = b;
                        Session["c"] = c;
                        Session["d"] = d;



                        return RedirectToAction("ResultBasicStage");

                    }

        #endregion
       

        #region Result of all Stages

            public ActionResult ResultBasicStage()
        {


            double A = Convert.ToDouble(Session["a"]);
            double B = Convert.ToDouble(Session["b"]);
            double C = Convert.ToDouble(Session["c"]);
            double D = Convert.ToDouble(Session["d"]);


            int resultUnadjustedFuctionPoints = Convert.ToInt32(Session["resultUnadjustedFuctionPoints"]);
            double resultValueAdjustmentFactors = Convert.ToDouble(Session["resultValueAdjustmentFactors"]);
            int valueLanguageFactor = Convert.ToInt32(Session["valueLanguageFactor"]);


            //Calculate Function Points
            double resultFunctionPoints = Math.Ceiling(resultUnadjustedFuctionPoints * resultValueAdjustmentFactors);


            //Calculate Size
            double resultSize = Math.Ceiling((resultFunctionPoints * valueLanguageFactor) / 1000);


            //Calculate Effort
            double resultEffort = A * Math.Pow(resultSize, B);
            
            #region Sessions for Report


            Session["resultSize"] = Math.Round(resultSize,0);
            Session["resultEffort"] = Math.Round(resultEffort,1);
            Session["resultFunctionPoints"] = resultFunctionPoints;

            #endregion


            return View();
        }


        public ActionResult SaveResultBasicStage()
        {
            Project p = new Project();


            p.Username = Session["user"].ToString();

          

            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();

            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<b>Selected Process Model: </b>" + Session["valueProcessModel"].ToString() + "<br>" +
                "<b>Selected Mode: </b>" + Session["Mode"].ToString() + "<br>" +
                "<b>Selected Stage: </b>" + Session["Stage"] + "<br>" +
                "<br/> <hr/>" +
                "<b>Unadjusted Function Points: </b>" +
                " <br>" +
                "<table> <tr> <th>Elements</th> <th colspan='3'>Complexity Weighting Factors</th> </tr> <tr>" +
                " <td><i>Low</i></td> <td><i>Average</i></td> <td><i>High</i></td> </tr> <tr> <td><p>External Inputs (EI)</p></td> " +
                "<td>" + Session["EI_LOW"].ToString() + " </td> <td> " + Session["EI_AVERAGE"].ToString() + " </td> <td>" + Session["EI_HIGH"].ToString() + " </td> </tr> " +
                "<tr> <td><p>External Outputs (EO)</p></td> <td>" + Session["EO_LOW"].ToString() + " </td> <td> " + Session["EO_AVERAGE"].ToString() + " </td> " +
                "<td>" + Session["EO_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Inquiries (EQ)</p></td> <td>" + Session["EQ_LOW"].ToString() + " </td>" +
                " <td>" + Session["EQ_AVERAGE"].ToString() + " </td> <td>" + Session["EQ_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Interface files (EIF)</p></td>" +
                " <td>" + Session["EIF_LOW"].ToString() + "</td> <td> " + Session["EIF_AVERAGE"].ToString() + " </td> <td>" + Session["EIF_HIGH"].ToString() + " </td> </tr> <tr> <td>" +
                "<p>Internal Logical files (ILF)</p></td> <td> " + Session["ILF_LOW"].ToString() + " </td> <td>" + Session["ILF_AVERAGE"].ToString() + " </td> " +
                "<td>" + Session["ILF_HIGH"].ToString() + " </td> </tr> <tr> <td><b>Total</b></td> <td>" + Session["resultUnadjustedFuctionPoints"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Language Factor: </b> <table> <tr> <td>Selected Language</td> <td>" + Session["textLanguageFactor"] +
                "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Value Adjustment Factors:</b> <table> <tr> <td>Data Communication</td> <td>Distributed Data Processing</td> <td>Performance</td> </tr> <tr>" +
                " <td>" + Session["valueFactorDC"].ToString() + "</td> <td>" + Session["valueFactorDDP"].ToString() + "</td> <td>" + Session["valueFactorPER"].ToString() + "</td> </tr> <tr> " +
                "<td>Heavly Used Configuration</td> <td>Transaction Rate</td> <td>Online Data Entry</td> </tr> <tr> <td>" + Session["valueFactorHUC"].ToString() + "</td> " +
                "<td>" + Session["valueFactorTR"].ToString() + "</td> <td>" + Session["valueFactorODE"].ToString() + "</td> </tr> <tr> <td>End User Efficiency</td> <td>Online Updates" +
                "</td> <td>Complex Processing</td> </tr> <tr> <td>" + Session["valueFactorEUE"].ToString() + "</td> <td>" + Session["valueFactorOU"].ToString() + "</td> " +
                "<td>" + Session["valueFactorCP"].ToString() + "</td> </tr> <tr> <td>Resuabilty</td> <td>Installation Ease</td> <td>Operational Ease</td> </tr> <tr> <td>" + Session["valueFactorREU"].ToString() + "</td>" +
                " <td>" + Session["valueFactorIE"].ToString() + "</td> <td>" + Session["valueFactorOE"].ToString() + "</td> </tr> <tr> <td>Multiple Sites</td> <td>Facilitate Change</td> </tr> <tr>" +
                " <td>" + Session["valueFactorMS"].ToString() + "</td> <td>" + Session["valueFactorFC"].ToString() + "</td> </tr> <tr> <td>Total</td> " +
                "<td>" + Session["resultValueAdjustmentFactors"].ToString() + "</td> </tr> </table>" +
               "<br/> <hr/>" +
               "<b>Language Factor: </b> <table> <tr> <td>Selected Language</td> <td>" + Session["textLanguageFactor"] + "" +
                "</td> </tr> </table>" +
                  "<br/> <hr/>" +
                "<b>Final Estimations:</b> <br>" +
                "<table > <tr> <td>Size: " + Session["resultSize"].ToString() + " (KLOC) </td> </tr> <tr> <td>Total Effort: " +
                "" + Session["resultEffort"].ToString() + " (Person-Months)</td> </tr> </table>";

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


            return RedirectToAction("ResultBasicStage");
        }




        public ActionResult ResultIntermediateStage()
        {


            double a = Convert.ToDouble(Session["a"]);
            double b = Convert.ToDouble(Session["b"]);
            double c = Convert.ToDouble(Session["c"]);
            double d = Convert.ToDouble(Session["d"]);



            int resultUnadjustedFuctionPoints = Convert.ToInt32(Session["resultUnadjustedFuctionPoints"]);
            double resultValueAdjustmentFactors = Convert.ToDouble(Session["resultValueAdjustmentFactors"]);
           

            double resultEffortAdjustmentFactor = Convert.ToDouble(Session["resultEffortAdjustmentFactor"]);



            int valueLanguageFactor = Convert.ToInt32(Session["valueLanguageFactor"]);


            //Calculate Function Points
            double resultFunctionPoints = Math.Ceiling(resultUnadjustedFuctionPoints * resultValueAdjustmentFactors);


            //Calculate Size
            double resultSize = Math.Ceiling((resultFunctionPoints * valueLanguageFactor) / 1000);

           
            //Calculate Effort      
            double resultEffort = a * Math.Pow(resultSize, b) * resultEffortAdjustmentFactor;

            //Calculate Development Time
            double resultDevelopmentTime = c * Math.Pow(resultEffort, d);

            //Staffing
            double p = resultEffort / resultDevelopmentTime;



            #region Sessions for Report

            Session["resultFunctionPoints"] = resultFunctionPoints;
            Session["resultSize"] =Math.Round(resultSize,0);
            Session["resultEffort"] = Math.Round(resultEffort,1);
            Session["resultDevelopmentTime"] = Math.Round(resultDevelopmentTime,0);
            Session["staff"] = Math.Round(p, 0);

            #endregion












            return View();
        }



        public ActionResult SaveResultIntermediateStage()
        {
            Project p = new Project();

            p.Username = Session["user"].ToString();
            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();

            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<b>Selected Process Model: </b>" + Session["valueProcessModel"].ToString() + "<br>" +
                "<b>Selected Mode: </b>" + Session["Mode"].ToString() + "<br>" +
                "<b>Selected Stage: </b>" + Session["Stage"] + "<br>" +
                "<br/> <hr/>" +
                "<b>Unadjusted Function Points: </b>" +
                " <br>" +
                "<table> <tr> <th>Elements</th> <th colspan='3'>Complexity Weighting Factors</th> </tr> <tr> <td><h4><i></i></h4></td>" +
                " <td><i>Low</i></td> <td><i>Average</i></td> <td><i>High</i></td> </tr> <tr> <td><p>External Inputs (EI)</p></td> <td>" +
                 Session["EI_LOW"].ToString() + " </td> <td> " + Session["EI_AVERAGE"].ToString() + " </td> <td>" + Session["EI_HIGH"].ToString() + " </td> </tr> " +
                "<tr> <td><p>External Outputs (EO)</p></td> <td>" + Session["EO_LOW"].ToString() + " </td> <td> " + Session["EO_AVERAGE"].ToString() + " </td> " +
                "<td> " + Session["EO_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Inquiries (EQ)</p></td> <td>" + Session["EQ_LOW"].ToString() + " </td>" +
                " <td> " + Session["EQ_AVERAGE"].ToString() + " </td> <td>" + Session["EQ_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Interface files (EIF)</p></td>" +
                " <td> " + Session["EIF_LOW"].ToString() + "</td> <td> " + Session["EIF_AVERAGE"].ToString() + " </td> <td>" + Session["EIF_HIGH"].ToString() + " </td> </tr> <tr> <td>" +
                "<p>Internal Logical files (ILF)</p></td> <td> " + Session["ILF_LOW"].ToString() + " </td> <td>" + Session["ILF_AVERAGE"].ToString() + " </td> " +
                "<td>" + Session["ILF_HIGH"].ToString() + " </td> </tr> <tr> <th>Total:</th> <td>" + Session["resultUnadjustedFuctionPoints"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Language Factor: </b> <table> <tr> <td>Selected Language</td> <td>" + Session["textLanguageFactor"] + "" +
                "</td> </tr> </table>" +
                  "<br/> <hr/>" +
                "<b>Value Adjustment Factors:</b> <table> <tr> <td>Data Communication</td> <td>Distributed Data Processing</td> <td>Performance</td> </tr> <tr>" +
                " <td>" + Session["valueFactorDC"].ToString() + "</td> <td>" + Session["valueFactorDDP"].ToString() + "</td> <td>" + Session["valueFactorPER"].ToString() + "</td> </tr> <tr> " +
                "<td>Heavly Used Configuration</td> <td>Transaction Rate</td> <td>Online Data Entry</td> </tr> <tr> <td>" + Session["valueFactorHUC"].ToString() + "</td> " +
                "<td>" + Session["valueFactorTR"].ToString() + "</td> <td>" + Session["valueFactorODE"].ToString() + "</td> </tr> <tr> <td>End User Efficiency</td> <td>Online Updates" +
                "</td> <td>Complex Processing</td> </tr> <tr> <td>" + Session["valueFactorEUE"].ToString() + "</td> <td>" + Session["valueFactorOU"].ToString() + "</td> " +
                "<td>" + Session["valueFactorCP"].ToString() + "</td> </tr> <tr> <td>Resuabilty</td> <td>Installation Ease</td> <td>Operational Ease</td> </tr> <tr> <td>" + Session["valueFactorREU"].ToString() + "</td>" +
                " <td>" + Session["valueFactorIE"].ToString() + "</td> <td>" + Session["valueFactorOE"].ToString() + "</td> </tr> <tr> <td>Multiple Sites</td> <td>Facilitate Change</td> </tr> <tr>" +
                " <td>" + Session["valueFactorMS"].ToString() + "</td> <td>" + Session["valueFactorFC"].ToString() + "</td> </tr> <tr> <th>Total:</th> " +
                "<td>" + Session["resultValueAdjustmentFactors"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Effort Adjustment Factor</b> <table > <tr> <td colspan='3'>PRODUCT ATTRIBUTES</td> </tr> <tr> <td> Reliability (RELY) <br /><br />" + Session["textRELY"].ToString() + "" +
                " </td> <td> Data (DATA) <br /><br /> " + Session["textDATA"].ToString() + " </td> <td> Product Complexity (CPLX) <br /><br />" + Session["textCPLX"].ToString() + " </td> </tr> <tr> <td colspan='3'>PLATFORM ATTRIBUTES</td>" +
                " </tr> <tr> <td> Execution time and Constraint (TIME) <br /><br />" + Session["textTIME"].ToString() + " </td> <td> Main Storage Constraint (STOR) <br /><br /> " + Session["textSTOR"].ToString() + " </td> <td> Virtual Machine Volatility (VIRT) <br />" +
                "<br />" + Session["textVIRT"].ToString() + " </td> <td> Computer Turnaround Time (TURN) <br /><br /> " + Session["textTURN"].ToString() + " </td> </tr> <tr> <td colspan='3'>PERSONAL ATTRIBUTES</td> </tr> <tr> <td>" +
                " Analyst Capability (ACAP) <br /><br /> " + Session["textACAP"].ToString() + " </td> <td> Application Experience (AEXP) <br /><br /> " + Session["textAEXP"].ToString() + " </td> <td> Programmer Capability (PCAP) <br /><br /> " + Session["textPCAP"].ToString() + "" +
                " </td> <td> Virtual Machine Experience (VEXP) <br /><br /> " + Session["textVEXP"].ToString() + " </td> <td> Language Experience (LEXP) <br /><br /> " + Session["textLEXP"].ToString() + " </td> </tr> <tr> <td colspan='5'>PROJECT ATTRIBUTES</td> </tr> <tr> <td>" +
                " Modern Programming Practices (MODP) <br /><br /> " + Session["textMODP"].ToString() + " </td> <td> Software Tools (TOOL)" +
                " <br /><br /> " + Session["textTOOL"].ToString() + " </td> <td colspan='4'> Development Schedule (SCED) <br /><br />" +
                " " + Session["textSCED"].ToString() + " </td> </tr> <tr> <th>Total:</th> <td>" + Session["resultEffortAdjustmentFactor"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Final Estimations:</b> <br>" +
                "<table > <tr> <td>Size: " + Session["resultSize"].ToString() + " (KLOC)</td> </tr> <tr> <td>Total Effort:  " +
                "" + Session["resultEffort"].ToString() + "(Person-Months)</td> </tr>" +
                "<tr> <td>Development Time: " + Session["resultDevelopmentTime"] + "(Months)</td> </tr>" +
                "<tr> <td>Staff: " + Session["staff"] + "(Persons)</td> </tr>" +
                " </table>";

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


            return RedirectToAction("ResultIntermediateStage");
        }




        public ActionResult ResultAdvancedStage()
        {
            

            double a = Convert.ToDouble(Session["a"]);
            double b = Convert.ToDouble(Session["b"]);
            double c = Convert.ToDouble(Session["c"]);
            double d = Convert.ToDouble(Session["d"]);



            int resultUnadjustedFuctionPoints = Convert.ToInt32(Session["resultUnadjustedFuctionPoints"]);
            double resultValueAdjustmentFactors = Convert.ToDouble(Session["resultValueAdjustmentFactors"]);


            double resultEffortAdjustmentFactor = Convert.ToDouble(Session["resultEffortAdjustmentFactor"]);



            int valueLanguageFactor = Convert.ToInt32(Session["valueLanguageFactor"]);


            //Calculate Function Points
            double resultFunctionPoints = Math.Ceiling(resultUnadjustedFuctionPoints * resultValueAdjustmentFactors);


            //Calculate Size
            double resultSize = Math.Ceiling((resultFunctionPoints * valueLanguageFactor) / 1000);





            //Calculate Effort      
            double resultEffort = a * Math.Pow(resultSize, b) * resultEffortAdjustmentFactor;

            //Calculate Development Time
            double resultDevelopmentTime = c * Math.Pow(resultEffort, d);

            //Staffing
            double p = resultEffort / resultDevelopmentTime;



            //Calculate Effort for RPD
            double resultEffortRPD = resultEffort*0.16;

            //Calculate Effort for DD
            double resultEffortDD = resultEffort*0.26;

            //Calculate Effort for CUT
            double resultEffortCUT = resultEffort*0.42;

            //Calculate Effort for IT
            double resultEffortIT = resultEffort*0.16;




            //Calculate Development Time for RPD
            double resultDevelopmentTimeRPD = resultDevelopmentTime*0.19;

            //Calculate Development Time for DD
            double resultDevelopmentTimeDD = resultDevelopmentTime *0.24;

            //Calculate Development Time for CUT
            double resultDevelopmentTimeCUT = resultDevelopmentTime *0.39;

            //Calculate Development Time for IT
            double resultDevelopmentTimeIT = resultDevelopmentTime *0.18;

            /*

            //Calculate Total Effort
            double resultTotalEffort = resultEffortRPD + resultEffortDD + resultEffortCUT + resultEffortIT;

            //Calculate Total Development Time
            double resultTotalDevelopmentTime = resultDevelopmentTimeRPD + resultDevelopmentTimeDD + resultDevelopmentTimeCUT + resultDevelopmentTimeIT;

            //Staffing
            double p = resultTotalEffort / resultTotalDevelopmentTime;

    */

            #region Sessions for Report


            Session["resultEffortRPD"] =Math.Round( resultEffortRPD, 1);
            Session["resultEffortDD"] = Math.Round( resultEffortDD, 1);
            Session["resultEffortCUT"] =Math.Round( resultEffortCUT, 1);
            Session["resultEffortIT"] = Math.Round( resultEffortIT,1);

            Session["resultDevelopmentTimeRPD"] = Math.Round(resultDevelopmentTimeRPD, 0);
            Session["resultDevelopmentTimeDD"] =  Math.Round(resultDevelopmentTimeDD, 0);
            Session["resultDevelopmentTimeCUT"] = Math.Round(resultDevelopmentTimeCUT, 0);
            Session["resultDevelopmentTimeIT"] = Math.Round(resultDevelopmentTimeIT, 0);

            Session["resultFunctionPoints"] = resultFunctionPoints;
            Session["resultSize"] = Math.Round(resultSize,0);
            Session["resultEffort"] = Math.Round(resultEffort, 1);
            Session["resultDevelopmentTime"] = Math.Round(resultDevelopmentTime,1);
            Session["staff"] = Math.Round(p, 0);

            #endregion












            return View();
        }



        public ActionResult SaveResultAdvancedStage()
        {
            Project p = new Project();

            p.Username = Session["user"].ToString();
            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();

            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<b>Selected Model: </b>" + Session["valueProcessModel"].ToString() + "<br>" +
                "<b>Selected Process Model: </b>" + Session["valueProcessModel"].ToString() + "<br>" +
                "<b>Selected Mode: </b>" + Session["Mode"].ToString() + "<br>" +
                "<b>Selected Stage: </b>" + Session["Stage"] + "<br>" +
                "<br/> <hr/>" +
                "<b>Unadjusted Function Points: </b>" +
                " <br>" +
                "<table> <tr> <th>Elements</th> <th colspan='3'>Complexity Weighting Factors</th> </tr> <tr> <td><h4><i></i></h4></td>" +
                " <td><i>Low</i></td> <td><i>Average</i></td> <td><i>High</i></td> </tr> <tr> <td><p>External Inputs (EI)</p></td> <td>" +
                 Session["EI_LOW"].ToString() + " </td> <td> " + Session["EI_AVERAGE"].ToString() + " </td> <td>" + Session["EI_HIGH"].ToString() + " </td> </tr> " +
                "<tr> <td><p>External Outputs (EO)</p></td> <td>" + Session["EO_LOW"].ToString() + " </td> <td> " + Session["EO_AVERAGE"].ToString() + " </td> " +
                "<td> " + Session["EO_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Inquiries (EQ)</p></td> <td>" + Session["EQ_LOW"].ToString() + " </td>" +
                " <td> " + Session["EQ_AVERAGE"].ToString() + " </td> <td>" + Session["EQ_HIGH"].ToString() + " </td> </tr> <tr> <td><p>External Interface files (EIF)</p></td>" +
                " <td> " + Session["EIF_LOW"].ToString() + "</td> <td> " + Session["EIF_AVERAGE"].ToString() + " </td> <td>" + Session["EIF_HIGH"].ToString() + " </td> </tr> <tr> <td>" +
                "<p>Internal Logical files (ILF)</p></td> <td> " + Session["ILF_LOW"].ToString() + " </td> <td>" + Session["ILF_AVERAGE"].ToString() + " </td> " +
                "<td>" + Session["ILF_HIGH"].ToString() + " </td> </tr> <tr> <td>Total</td> <td>" + Session["resultUnadjustedFuctionPoints"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Language Factor: </b> <table> <tr> <td>Selected Language</td> <td>" + Session["textLanguageFactor"] + "" +
                "</td> </tr> </table>" +
                  "<br/> <hr/>" +
                "<b>Value Adjustment Factors: </b> <table> <tr> <td>Data Communication</td> <td>Distributed Data Processing</td> <td>Performance</td> </tr> <tr>" +
                " <td>" + Session["valueFactorDC"].ToString() + "</td> <td>" + Session["valueFactorDDP"].ToString() + "</td> <td>" + Session["valueFactorPER"].ToString() + "</td> </tr> <tr> " +
                "<td>Heavly Used Configuration</td> <td>Transaction Rate</td> <td>Online Data Entry</td> </tr> <tr> <td>" + Session["valueFactorHUC"].ToString() + "</td> " +
                "<td>" + Session["valueFactorTR"].ToString() + "</td> <td>" + Session["valueFactorODE"].ToString() + "</td> </tr> <tr> <td>End User Efficiency</td> <td>Online Updates" +
                "</td> <td>Complex Processing</td> </tr> <tr> <td>" + Session["valueFactorEUE"].ToString() + "</td> <td>" + Session["valueFactorOU"].ToString() + "</td> " +
                "<td>" + Session["valueFactorCP"].ToString() + "</td> </tr> <tr> <td>Resuabilty</td> <td>Installation Ease</td> <td>Operational Ease</td> </tr> <tr> <td>" + Session["valueFactorREU"].ToString() + "</td>" +
                " <td>" + Session["valueFactorIE"].ToString() + "</td> <td>" + Session["valueFactorOE"].ToString() + "</td> </tr> <tr> <td>Multiple Sites</td> <td>Facilitate Change</td> </tr> <tr>" +
                " <td>" + Session["valueFactorMS"].ToString() + "</td> <td>" + Session["valueFactorFC"].ToString() + "</td> </tr> <tr> <th>Total:</th> " +
                "<td>" + Session["resultValueAdjustmentFactors"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                 "<b>Effort Adjustment Factors</b> <table > <tr> <td colspan='3'>PRODUCT ATTRIBUTES</td> </tr> <tr> <td> Reliability (RELY) <br /><br />" + Session["textRELY"].ToString() + "" +
                " </td> <td> Data (DATA) <br /><br /> " + Session["textDATA"].ToString() + " </td> <td> Product Complexity (CPLX) <br /><br />" + Session["textCPLX"].ToString() + " </td> </tr> <tr> <td colspan='3'>PLATFORM ATTRIBUTES</td>" +
                " </tr> <tr> <td> Execution time and Constraint (TIME) <br /><br />" + Session["textTIME"].ToString() + " </td> <td> Main Storage Constraint (STOR) <br /><br /> " + Session["textSTOR"].ToString() + " </td> <td> Virtual Machine Volatility (VIRT) <br />" +
                "<br />" + Session["textVIRT"].ToString() + " </td> <td> Computer Turnaround Time (TURN) <br /><br /> " + Session["textTURN"].ToString() + " </td> </tr> <tr> <td colspan='3'>PERSONAL ATTRIBUTES</td> </tr> <tr> <td>" +
                " Analyst Capability (ACAP) <br /><br /> " + Session["textACAP"].ToString() + " </td> <td> Application Experience (AEXP) <br /><br /> " + Session["textAEXP"].ToString() + " </td> <td> Programmer Capability (PCAP) <br /><br /> " + Session["textPCAP"].ToString() + "" +
                " </td> <td> Virtual Machine Experience (VEXP) <br /><br /> " + Session["textVEXP"].ToString() + " </td> <td> Language Experience (LEXP) <br /><br /> " + Session["textLEXP"].ToString() + " </td> </tr> <tr> <td colspan='5'>PROJECT ATTRIBUTES</td> </tr> <tr> <td>" +
                " Modern Programming Practices (MODP) <br /><br /> " + Session["textMODP"].ToString() + " </td> <td> Software Tools (TOOL)" +
                " <br /><br /> " + Session["textTOOL"].ToString() + " </td> <td colspan='4'> Development Schedule (SCED) <br /><br />" +
                " " + Session["textSCED"].ToString() + " </td> </tr> <tr> <th>Total:</th> <td>" + Session["resultEffortAdjustmentFactor"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Final Estimations: </b> " +
                "<table> <tr> <td>Size (KLOC)</td> <td>" + Session["resultSize"] + "</td> </tr> <tr> <td> Total Effort (Person-Months) " +
                "" + Session["resultEffort"] + "<table> <tr> <td>Effort RPD</td> <td>" + Session["resultEffortRPD"] + "</tr> <tr> <td>Effort DD</td>" +
                " <td>" + Session["resultEffortDD"] + "</tr> <tr> <td>Effort CUT</td> <td>" + Session["resultEffortCUT"] + " </tr> <tr> <td>" +
                "Effort IT</td> <td>" + Session["resultEffortIT"] + " </tr> </table> </td> <td> Total Development Time (Months) " +
                "" + Session["resultDevelopmentTime"] + " <table  > <tr> <td  >Development Time RPD</td> <td>" + Session["resultDevelopmentTimeRPD"] + "" +
                " </tr> <tr> <td>Development Time DD</td> <td>" + Session["resultDevelopmentTimeDD"] + "</tr> <tr> <td>Development Time CUT</td> " +
                "<td>" + Session["resultDevelopmentTimeCUT"] + "</tr> <tr> <td  >Development Time IT</td> <td>" + Session["resultDevelopmentTimeIT"] + "" +
                "<tr> <td>Staff: " + Session["staff"] + "(Persons)</td> </tr>" +
                " </tr> </table> </td> </tr> </table>";

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


            return RedirectToAction("ResultAdvancedStage");
        }


      
        #endregion





    }
}