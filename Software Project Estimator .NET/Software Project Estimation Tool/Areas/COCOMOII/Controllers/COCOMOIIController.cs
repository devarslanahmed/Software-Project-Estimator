using Software_Project_Estimation_Tool.Areas.COCOMOII.Models;
using Software_Project_Estimation_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Areas.COCOMOII.Controllers
{
    public class COCOMOIIController : Controller
    {
        // GET: COCOMOII/COCOMOII

        public ActionResult Index()
        {

            if (Session["Model"].ToString() == "Application Composition Model")
            {
                return RedirectToAction("ResultApplicationCompositionModel", "COCOMOII");
            }
            else if (Session["Model"].ToString() == "Early Design Model")
            {
                return RedirectToAction("ResultEarlyDesignModel", "COCOMOII");
            }
            else if (Session["Model"].ToString() == "Post Architecture Model")
            {
                return RedirectToAction("ResultPostArchitectureModel", "COCOMOII");
            }
            else
            {
                return View();
            }

        }



        #region COCOMOII

        public ActionResult COCOMOII()
        {


            return View();

        }




        #endregion


        #region Select Model
        public ActionResult SelectModel()
        {
            return View();
        }

        #endregion


        #region All Models 


        public ActionResult ApplicationCompositionModel()
        {
            String Model = "Application Composition Model";

            Session["Model"] = Model;

            return View();
        }


        public ActionResult EarlyDesignModel()
        {
            String Model = "Early Design Model";

            Session["Model"] = Model;

            return View();
        }



        public ActionResult PostArchitectureModel()
        {
            String Model = "Post Architecture Model";

            Session["Model"] = Model;

            return View();
        }

        #endregion


        #region Object Points 

        public ActionResult ObjectPoints()
        {

            return View();
        }


        [HttpPost]
        public ActionResult ObjectPoints(ObjectPointsModel objectPointsModel, String Model)
        {

            // Session["Model"] = Model;

            int SCREEN_SIMPLE = Convert.ToInt32(objectPointsModel.SCREEN_SIMPLE);
            int SCREEN_MEDIUM = Convert.ToInt32(objectPointsModel.SCREEN_MEDIUM);
            int SCREEN_DIFFICULT = Convert.ToInt32(objectPointsModel.SCREEN_DIFFICULT);
            int SCREEN_TOTAL = Convert.ToInt32(objectPointsModel.SCREEN_TOTAL);


            int REPORT_SIMPLE = Convert.ToInt32(objectPointsModel.REPORT_SIMPLE);
            int REPORT_MEDIUM = Convert.ToInt32(objectPointsModel.REPORT_MEDIUM);
            int REPORT_DIFFICULT = Convert.ToInt32(objectPointsModel.REPORT_DIFFICULT);
            int REPORT_TOTAL = Convert.ToInt32(objectPointsModel.REPORT_TOTAL);


            int MODULE_3GL = Convert.ToInt32(objectPointsModel.MODULE_3GL);
            double REUSE_PERCENTAGE = Convert.ToDouble(objectPointsModel.REUSE_PERCENTAGE);



            if (SCREEN_TOTAL == SCREEN_SIMPLE + SCREEN_MEDIUM + SCREEN_DIFFICULT &&
                REPORT_TOTAL == REPORT_SIMPLE + REPORT_MEDIUM + REPORT_DIFFICULT)
            {


                double resultScreens;
                double resultReports;
                double resultModule3gl;
                double resultObjectPoints;
                double resultNewObjectPoints;


                resultScreens = (SCREEN_SIMPLE * 1) + (SCREEN_MEDIUM * 2) + (SCREEN_DIFFICULT * 3);
                resultReports = (REPORT_SIMPLE * 2) + (REPORT_MEDIUM * 5) + (REPORT_DIFFICULT * 8);
                resultModule3gl = (MODULE_3GL * 10);

                resultObjectPoints = resultScreens + resultReports + resultModule3gl;

                resultNewObjectPoints = resultObjectPoints * ((100 - REUSE_PERCENTAGE) / 100);



                #region Sessions for Report

                Session["SCREEN_SIMPLE"] = SCREEN_SIMPLE;
                Session["SCREEN_MEDIUM"] = SCREEN_MEDIUM;
                Session["SCREEN_DIFFICULT"] = SCREEN_DIFFICULT;
                Session["SCREEN_TOTAL"] = SCREEN_TOTAL;


                Session["REPORT_SIMPLE"] = REPORT_SIMPLE;
                Session["REPORT_MEDIUM"] = REPORT_MEDIUM;
                Session["REPORT_DIFFICULT"] = REPORT_DIFFICULT;
                Session["REPORT_TOTAL"] = REPORT_TOTAL;


                Session["MODULE_3GL"] = MODULE_3GL;
                Session["REUSE_PERCENTAGE"] = REUSE_PERCENTAGE;


                Session["resultObjectPoints"] = resultObjectPoints;
                Session["resultNewObjectPoints"] = Math.Round(resultNewObjectPoints, 1);

                #endregion


                if (SCREEN_TOTAL != 0/* && REPORT_TOTAL != 0*/)
                {


                    return RedirectToAction("ProductivityRate", "COCOMOII");

                }
                else
                {
                    return View();
                }
            }
            else
            {

                ViewBag.Exeption = "invalid";
                return View();
            }



        }

        #endregion


        #region Productivity Rate

        public static List<SelectListItem> DevExpList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "4" },
                new SelectListItem { Text = "Low", Value = "7" },
                new SelectListItem { Text = "Nominal", Value = "13" },
                new SelectListItem { Text = "High", Value = "25" },
                new SelectListItem { Text = "Very High", Value = "50" }
            };
            return item;
        }





        public ActionResult ProductivityRate()
        {
            ProductivityRateModel productivityRateModel = new ProductivityRateModel
            {
                DEVELOPER_EXPERIENCE = DevExpList()
            };

            return View(productivityRateModel);
        }

        [HttpPost]
        public ActionResult ProductivityRate(ProductivityRateModel productivityRateModel)
        {
            productivityRateModel.DEVELOPER_EXPERIENCE = DevExpList();

            int valueDevExp = productivityRateModel.DEVELOPER_EXPERIENCE_VALUE;
            var textDevExp = productivityRateModel.DEVELOPER_EXPERIENCE.Find(p => p.Value == productivityRateModel.DEVELOPER_EXPERIENCE_VALUE.ToString());


            if (valueDevExp != 0)
            {

                if (textDevExp != null)
                {



                    #region Sessions for Report

                    Session["textDevExp"] = textDevExp.Text;
                    Session["valueDevExp"] = valueDevExp;

                    #endregion


                }


                return RedirectToAction("ResultApplicationCompositionModel", "COCOMOII");
                //return View(productivityRateModel);

            }




            return View(productivityRateModel);
        }


        #endregion

        

        #region Cost Drivers


        #region Lists Cost Drivers PAM


        public static List<SelectListItem> RELYList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "0.75" },
                new SelectListItem { Text = "Low", Value = "0.88" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "2.48" },
                new SelectListItem { Text = "Very High", Value = "1.24" }
            };

            return item;

        }

        public static List<SelectListItem> DATAList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low", Value = "0.93" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "2.03" },
                new SelectListItem { Text = "Very High", Value = "2.03" }
            };
            return item;
        }


        public static List<SelectListItem> CPLXList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "0.75" },
                new SelectListItem { Text = "Low", Value = "0.88" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "2.83" },
                new SelectListItem { Text = "Very High", Value = "1.41" }
            };
            return item;
        }


        public static List<SelectListItem> RUSEList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
               
                new SelectListItem { Text = "Low", Value = "0.91" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "2.19" },
                new SelectListItem { Text = "Very High", Value = "1.10" }
            };
            return item;
        }



        public static List<SelectListItem> DOCUList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "0.89" },
                new SelectListItem { Text = "Low", Value = "0.95" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "3.12" },
                new SelectListItem { Text = "Very High", Value = "1.56" }
                
            };
            return item;
        }



        public static List<SelectListItem> TIMEList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.11" },
                new SelectListItem { Text = "Very High", Value = "1.31" },
                new SelectListItem { Text = "Extra High", Value = "1.67" }
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
                new SelectListItem { Text = "Extra High", Value = "1.57" }
            };
            return item;
        }



        public static List<SelectListItem> PVOLList()
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



        public static List<SelectListItem> ACAPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.50" },
                new SelectListItem { Text = "Low", Value = "1.22" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.83" },
                new SelectListItem { Text = "Very High", Value = "0.67" }
            };
            return item;
        }




        public static List<SelectListItem> PCAPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.37" },
                new SelectListItem { Text = "Low", Value = "1.16" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.87" },
                new SelectListItem { Text = "Very High", Value = "0.74" }
            };
            return item;
        }




        public static List<SelectListItem> PCONList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.24" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.92" },
                new SelectListItem { Text = "Very High", Value = "0.84" }
            };
            return item;
        }





        public static List<SelectListItem> AEXPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.22" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.89" },
                new SelectListItem { Text = "Very High", Value = "0.81" }
            };
            return item;
        }



        public static List<SelectListItem> PEXPList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.25" },
                new SelectListItem { Text = "Low", Value = "1.12" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.88" },
                new SelectListItem { Text = "Very High", Value = "0.81" }
            };
            return item;
        }



        public static List<SelectListItem> LTEXList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.22" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.91" },
                new SelectListItem { Text = "Very High", Value = "0.84" }
            };
            return item;
        }



        public static List<SelectListItem> TOOLList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.24" },
                new SelectListItem { Text = "Low", Value = "1.12" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.86" },
                new SelectListItem { Text = "Very High", Value = "0.72" }
            };
            return item;
        }


        public static List<SelectListItem> SITEList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.25" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.92" },
                new SelectListItem { Text = "Very High", Value = "0.84" },
                new SelectListItem { Text = "Extra High", Value = "0.78" }
            };
            return item;
        }




        public static List<SelectListItem> SCEDList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Very Low", Value = "1.29" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.0" },
                new SelectListItem { Text = "Very High", Value = "1.0" }
            };
            return item;
        }

        #endregion


        #region Calculate Cost Drivers PAM



        public ActionResult CostDrivers()
        {
            CostDriversModel model = new CostDriversModel
            {

                RELY = RELYList(),
                DATA = DATAList(),
                CPLX = CPLXList(),
                RUSE = RUSEList(),
                DOCU = DOCUList(),
                TIME = TIMEList(),
                STOR = STORList(),
                PVOL = PVOLList(),
                ACAP = ACAPList(),
                PCAP = PCAPList(),
                PCON = PCONList(),
                AEXP = AEXPList(),
                PEXP = PEXPList(),
                LTEX = LTEXList(),
                TOOL = TOOLList(),
                SITE = SITEList(),
                SCED = SCEDList()
            };
            return View(model);
        }







        [HttpPost]
        public ActionResult CostDrivers(CostDriversModel model)
        {

                model.RELY = RELYList();
                model.DATA = DATAList();
                model.CPLX = CPLXList();
                model.RUSE = RUSEList();
                model.DOCU = DOCUList();
                model.TIME = TIMEList();
                model.STOR = STORList();
                model.PVOL = PVOLList();
                model.ACAP = ACAPList();
                model.PCAP = PCAPList();
                model.PCON = PCONList();
                model.AEXP = AEXPList();
                model.PEXP = PEXPList();
                model.LTEX = LTEXList();
                model.TOOL = TOOLList();
                model.SITE = SITEList();
                model.SCED = SCEDList();


           String valueRELY = model.RELY_VALUE;
           String valueDATA = model.DATA_VALUE;
           String valueCPLX = model.CPLX_VALUE;
           String valueRUSE = model.RUSE_VALUE;
           String valueDOCU = model.DOCU_VALUE;
           String valueTIME = model.TIME_VALUE;
           String valueSTOR = model.STOR_VALUE;
           String valuePVOL = model.PVOL_VALUE;
           String valueACAP = model.ACAP_VALUE;
           String valuePCAP = model.PCAP_VALUE;
           String valuePCON = model.PCON_VALUE;
           String valueAEXP = model.AEXP_VALUE;
           String valuePEXP = model.PEXP_VALUE;
           String valueLTEX = model.LTEX_VALUE;
           String valueTOOL = model.TOOL_VALUE;
           String valueSITE = model.SITE_VALUE;
           String valueSCED = model.SCED_VALUE;




         


            Session["valueRELY"] = valueRELY;
            Session["valueDATA"] = valueDATA;
            Session["valueCPLX"] = valueCPLX;
            Session["valueRUSE"] = valueRUSE;
            Session["valueDOCU"] = valueDOCU;
            Session["valueTIME"] = valueTIME;
            Session["valueSTOR"] = valueSTOR;
            Session["valuePVOL"] = valuePVOL;
            Session["valueACAP"] = valueACAP;
            Session["valuePCAP"] = valuePCAP;
            Session["valuePCON"] = valuePCON;
            Session["valueAEXP"] = valueAEXP;
            Session["valuePEXP"] = valuePEXP;
            Session["valueLTEX"] = valueLTEX;
            Session["valueTOOL"] = valueTOOL;
            Session["valueSITE"] = valueSITE;
            Session["valueSCED"] = valueSCED;


            if(valueRELY != null &&
               valueDATA != null &&
               valueCPLX != null &&
               valueRUSE != null &&
               valueDOCU != null &&
               valueTIME != null &&
               valueSTOR != null &&
               valuePVOL != null &&
               valueACAP != null &&
               valuePCAP != null &&
               valuePCON != null &&
               valueAEXP != null &&
               valuePEXP != null &&
               valueLTEX != null &&
               valueTOOL != null &&
               valueSITE != null &&
               valueSCED != null)

            {

                double fvalueRELY = Convert.ToDouble(valueRELY);
                double fvalueDATA = Convert.ToDouble(valueDATA);
                double fvalueCPLX = Convert.ToDouble(valueCPLX);
                double fvalueRUSE = Convert.ToDouble(valueRUSE);
                double fvalueDOCU = Convert.ToDouble(valueDOCU);
                double fvalueTIME = Convert.ToDouble(valueTIME);
                double fvalueSTOR = Convert.ToDouble(valueSTOR);
                double fvaluePVOL = Convert.ToDouble(valuePVOL);
                double fvalueACAP = Convert.ToDouble(valueACAP);
                double fvaluePCAP = Convert.ToDouble(valuePCAP);
                double fvaluePCON = Convert.ToDouble(valuePCON);
                double fvalueAEXP = Convert.ToDouble(valueAEXP);
                double fvaluePEXP = Convert.ToDouble(valuePEXP);
                double fvalueLTEX = Convert.ToDouble(valueLTEX);
                double fvalueTOOL = Convert.ToDouble(valueTOOL);
                double fvalueSITE = Convert.ToDouble(valueSITE);
                double fvalueSCED = Convert.ToDouble(valueSCED);


                double resultCostDrivers = fvalueRELY *
                                           fvalueDATA *
                                           fvalueCPLX *
                                           fvalueRUSE *
                                           fvalueDOCU *
                                           fvalueTIME *
                                           fvalueSTOR *
                                           fvaluePVOL *
                                           fvalueACAP *
                                           fvaluePCAP *
                                           fvaluePCON *
                                           fvalueAEXP *
                                           fvaluePEXP *
                                           fvalueLTEX *
                                           fvalueTOOL *
                                           fvalueSITE *
                                           fvalueSCED;

                Session["resultEffortAdjustmentFactor"] = Math.Round(resultCostDrivers, 1);




                //Texts
                var textRELY = model.RELY.Find(m => m.Value == model.RELY_VALUE.ToString());
                if (textRELY != null)
                {
                    textRELY.Selected = true;
                    Session["textRELY"] = textRELY.Text;
                }



                var textDATA = model.DATA.Find(m => m.Value == model.DATA_VALUE.ToString());
                if (textDATA != null)
                {
                    textDATA.Selected = true;
                    Session["textDATA"] = textDATA.Text;
                }


                var textCPLX = model.CPLX.Find(m => m.Value == model.CPLX_VALUE.ToString());
                if (textCPLX != null)
                {
                    textCPLX.Selected = true;
                    Session["textCPLX"] = textCPLX.Text;
                }

                var textRUSE = model.RUSE.Find(m => m.Value == model.RUSE_VALUE.ToString());
                if (textRUSE != null)
                {
                    textRUSE.Selected = true;
                    Session["textRUSE"] = textRUSE.Text;
                }

                var textDOCU = model.DOCU.Find(m => m.Value == model.DOCU_VALUE.ToString());
                if (textDOCU != null)
                {
                    textDOCU.Selected = true;
                    Session["textDOCU"] = textDOCU.Text;
                }


                var textTIME = model.TIME.Find(m => m.Value == model.TIME_VALUE.ToString());
                if (textTIME != null)
                {
                    textTIME.Selected = true;
                    Session["textTIME"] = textTIME.Text;
                }



                var textSTOR = model.STOR.Find(m => m.Value == model.STOR_VALUE.ToString());
                if (textSTOR != null)
                {
                    textSTOR.Selected = true;
                    Session["textSTOR"] = textSTOR.Text;
                }


                var textPVOL = model.PVOL.Find(m => m.Value == model.PVOL_VALUE.ToString());
                if (textPVOL != null)
                {
                    textPVOL.Selected = true;
                    Session["textPVOL"] = textPVOL.Text;
                }


                var textACAP = model.ACAP.Find(m => m.Value == model.ACAP_VALUE.ToString());
                if (textACAP != null)
                {
                    textACAP.Selected = true;
                    Session["textACAP"] = textACAP.Text;
                }


                var textPCAP = model.PCAP.Find(m => m.Value == model.PCAP_VALUE.ToString());
                if (textPCAP != null)
                {
                    textPCAP.Selected = true;
                    Session["textPCAP"] = textPCAP.Text;
                }



                var textPCON = model.PCON.Find(m => m.Value == model.PCON_VALUE.ToString());
                if (textPCON != null)
                {
                    textPCON.Selected = true;
                    Session["textPCON"] = textPCON.Text;
                }



                var textAEXP = model.AEXP.Find(m => m.Value == model.AEXP_VALUE.ToString());
                if (textAEXP != null)
                {
                    textAEXP.Selected = true;
                    Session["textAEXP"] = textAEXP.Text;
                }



                var textPEXP = model.PEXP.Find(m => m.Value == model.PEXP_VALUE.ToString());
                if (textPEXP != null)
                {
                    textPEXP.Selected = true;
                    Session["textPEXP"] = textPEXP.Text;
                }


                var textLTEX = model.LTEX.Find(m => m.Value == model.LTEX_VALUE.ToString());
                if (textLTEX != null)
                {
                    textLTEX.Selected = true;
                    Session["textLTEX"] = textLTEX.Text;
                }



                var textTOOL = model.TOOL.Find(m => m.Value == model.TOOL_VALUE.ToString());
                if (textTOOL != null)
                {
                    textTOOL.Selected = true;
                    Session["textTOOL"] = textTOOL.Text;
                }



                var textSITE = model.SITE.Find(m => m.Value == model.SITE_VALUE.ToString());
                if (textSITE != null)
                {
                    textSITE.Selected = true;
                    Session["textSITE"] = textSITE.Text;
                }




                var textSCED = model.SCED.Find(m => m.Value == model.SCED_VALUE.ToString());
                if (textSCED != null)
                {
                    textSCED.Selected = true;
                    Session["textSCED"] = textSCED.Text;
                }



                //#region Sessions for Report

                //Session["textRELY"] = textRELY.Text;
                //Session["textDATA"] = textDATA.Text;
                //Session["textCPLX"] = textCPLX.Text;
                //Session["textTIME"] = textTIME.Text;
                //Session["textSTOR"] = textSTOR.Text;
                //Session["textVIRT"] = textVIRT.Text;
                //Session["textTURN"] = textTURN.Text;
                //Session["textACAP"] = textACAP.Text;
                //Session["textAEXP"] = textAEXP.Text;
                //Session["textPCAP"] = textPCAP.Text;
                //Session["textVEXP"] = textVEXP.Text;
                //Session["textLEXP"] = textLEXP.Text;
                //Session["textMODP"] = textMODP.Text;
                //Session["textTOOL"] = textTOOL.Text;
                //Session["textSCED"] = textSCED.Text;



                //#endregion



                    return RedirectToAction("ScaleComponent", "COCOMOII");

                


            }


            return View(model);
        }



        #endregion



        #region Lists Cost Drivers EDM



        public static List<SelectListItem> RCPXList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Extra Low", Value = "0.73" },
                new SelectListItem { Text = "Very Low", Value = "0.81" },
                new SelectListItem { Text = "Low", Value = "0.98" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.30" },
                new SelectListItem { Text = "Very High", Value = "1.74" },
                new SelectListItem { Text = "Extra High", Value = "2.38"}
            };

            return item;

        }

        public static List<SelectListItem> RUSE2List()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low", Value = "0.95" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.07" },
                new SelectListItem { Text = "Very High", Value = "1.15" },
                new SelectListItem { Text = "Extra High", Value = "1.24" }
            };
            return item;
        }


        public static List<SelectListItem> PDIFList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {

                new SelectListItem { Text = "Low", Value = "0.87" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.29" },
                new SelectListItem { Text = "Very High", Value = "1.81" },
                new SelectListItem { Text = "Extra High", Value = "2.61" }
            };
            return item;
        }


        public static List<SelectListItem> PERSList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Extra Low", Value = "2.12" },
                new SelectListItem { Text = "Very Low", Value = "1.62" },
                new SelectListItem { Text = "Low", Value = "1.26" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.83" },
                new SelectListItem { Text = "Very High", Value = "0.63" },
                new SelectListItem { Text = "Extra High", Value = "0.50"}
            };
            return item;
        }


        public static List<SelectListItem> PREXList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "Extra Low", Value = "1.59" },
                new SelectListItem { Text = "Very Low", Value = "1.33" },
                new SelectListItem { Text = "Low", Value = "1.12" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.87" },
                new SelectListItem { Text = "Very High", Value = "0.71" },
                new SelectListItem { Text = "Extra High", Value = "0.62"}
            };
            return item;
        }


        public static List<SelectListItem> FCILList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
               new SelectListItem { Text = "Extra Low", Value = "1.43" },
                new SelectListItem { Text = "Very Low", Value = "1.30" },
                new SelectListItem { Text = "Low", Value = "1.10" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "0.87" },
                new SelectListItem { Text = "Very High", Value = "0.73" },
                new SelectListItem { Text = "Extra High", Value = "0.62"}
            };
            return item;
        }


        public static List<SelectListItem> SCED2List()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {

                new SelectListItem { Text = "Very Low", Value = "1.43" },
                new SelectListItem { Text = "Low", Value = "1.14" },
                new SelectListItem { Text = "Nominal", Value = "1.0" },
                new SelectListItem { Text = "High", Value = "1.0" },
                new SelectListItem { Text = "Very High", Value = "1.0" }

            };
            return item;
        }




        #endregion

        #region Calculate Cost Drivers EDM

        public ActionResult CostDriversEDM()
        {

            CostDriversEDMModel model = new CostDriversEDMModel
            {

                RCPX = RCPXList(),
                RUSE = RUSE2List(),
                PDIF = PDIFList(),
                PERS = PERSList(),
                PREX = PREXList(),
                FCIL = FCILList(),
                SCED = SCED2List()
            };




            return View(model);
        }


        [HttpPost]
        public ActionResult CostDriversEDM(CostDriversEDMModel model)
        {

            model.RCPX = RCPXList();
            model.RUSE = RUSE2List();
            model.PDIF = PDIFList();
            model.PERS = PERSList();
            model.PREX = PREXList();
            model.FCIL = FCILList();
            model.SCED = SCED2List();


            String valueRCPX = model.RCPX_VALUE;
            String valueRUSE = model.RUSE_VALUE;
            String valuePDIF = model.PDIF_VALUE;
            String valuePERS = model.PERS_VALUE;
            String valuePREX = model.PREX_VALUE;
            String valueFCIL = model.FCIL_VALUE;
            String valueSCED = model.SCED_VALUE;



            Session["valueRCPX"] = valueRCPX;
            Session["valueRUSE"] = valueRUSE;
            Session["valuePDIF"] = valuePDIF;
            Session["valuePERS"] = valuePERS;
            Session["valuePREX"] = valuePREX;
            Session["valueFCIL"] = valueFCIL;
            Session["valueSCED"] = valueSCED;


            if (valueRCPX != null &&
                valueRUSE != null &&
                valuePDIF != null &&
                valuePERS != null &&
                valuePREX != null &&
                valueFCIL != null &&
                valueSCED != null)
            {



                double fvalueRCPX = Convert.ToDouble(valueRCPX);
                double fvalueRUSE = Convert.ToDouble(valueRUSE);
                double fvaluePDIF = Convert.ToDouble(valuePDIF);
                double fvaluePERS = Convert.ToDouble(valuePERS);
                double fvaluePREX = Convert.ToDouble(valuePREX);
                double fvalueFCIL = Convert.ToDouble(valueFCIL);
                double fvalueSCED = Convert.ToDouble(valueSCED);



                double resultCostDrivers = fvalueRCPX * fvalueRUSE * fvaluePDIF * fvaluePERS * fvaluePREX * fvalueFCIL * fvalueSCED;
                Session["resultEffortAdjustmentFactor"] = Math.Round(resultCostDrivers, 1);




                //Texts
                var textRCPX = model.RCPX.Find(m => m.Value == model.RCPX_VALUE.ToString());
                if (textRCPX != null)
                {
                    textRCPX.Selected = true;
                    Session["textRCPX"] = textRCPX.Text;
                }


                var textRUSE = model.RUSE.Find(m => m.Value == model.RUSE_VALUE.ToString());
                if (textRUSE != null)
                {
                    textRUSE.Selected = true;
                    Session["textRUSE"] = textRUSE.Text;
                }


                var textPDIF = model.PDIF.Find(m => m.Value == model.PDIF_VALUE.ToString());
                if (textPDIF != null)
                {
                    textPDIF.Selected = true;
                    Session["textPDIF"] = textPDIF.Text;
                }


                var textPERS = model.PERS.Find(m => m.Value == model.PERS_VALUE.ToString());
                if (textPERS != null)
                {
                    textPERS.Selected = true;
                    Session["textPERS"] = textPERS.Text;
                }


                var textPREX = model.PREX.Find(m => m.Value == model.PREX_VALUE.ToString());
                if (textPREX != null)
                {
                    textPREX.Selected = true;
                    Session["textPREX"] = textPREX.Text;
                }


                var textFCIL = model.FCIL.Find(m => m.Value == model.FCIL_VALUE.ToString());
                if (textFCIL != null)
                {
                    textFCIL.Selected = true;
                    Session["textFCIL"] = textFCIL.Text;
                }


                var textSCED = model.SCED.Find(m => m.Value == model.SCED_VALUE.ToString());
                if (textSCED != null)
                {
                    textSCED.Selected = true;
                    Session["textSCED"] = textSCED.Text;
                }


                //#region Sessions for report


                //Session["textRCPX"] = textRCPX;
                //Session["textRUSE"] = textRUSE;
                //Session["textPDIF"] = textPDIF;
                //Session["textPERS"] = textPERS;
                //Session["textPREX"] = textPREX;
                //Session["textFCIL"] = textFCIL;
                //Session["textSCED"] = textSCED;


                //#endregion



                return RedirectToAction("ScaleComponent", "COCOMOII");
               

            }

            return View(model);
        }




        #endregion


        #endregion


        #region Scale Component


        #region Lists Scale Components



        public static List<SelectListItem> PRECList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                   new SelectListItem { Text = "Very Low", Value = "6.20" },
                   new SelectListItem { Text = "Low", Value = "4.96" },
                   new SelectListItem { Text = "Nominal", Value = "3.72" },
                   new SelectListItem { Text = "High", Value = "2.48" },
                   new SelectListItem { Text = "Very High", Value = "1.24" }
                   //new SelectListItem { Text = "Extra High", Value = "0" }
            };
            return item;
        }

        public static List<SelectListItem> FLEXList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                   new SelectListItem { Text = "Very Low", Value = "5.07" },
                   new SelectListItem { Text = "Low", Value = "4.05" },
                   new SelectListItem { Text = "Nominal", Value = "3.04" },
                   new SelectListItem { Text = "High", Value = "2.03" },
                   new SelectListItem { Text = "Very High", Value = "1.01" }
                   //new SelectListItem { Text = "Extra High", Value = "0" }
            };
            return item;
        }

        public static List<SelectListItem> RESLList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                   new SelectListItem { Text = "Very Low", Value = "7.07" },
                   new SelectListItem { Text = "Low", Value = "5.65" },
                   new SelectListItem { Text = "Nominal", Value = "4.24" },
                   new SelectListItem { Text = "High", Value = "2.83" },
                   new SelectListItem { Text = "Very High", Value = "1.41" }
                   //new SelectListItem { Text = "Extra High", Value = "0" }
            };
            return item;
        }


        public static List<SelectListItem> TEAMList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                   new SelectListItem { Text = "Very Low", Value = "5.48" },
                   new SelectListItem { Text = "Low", Value = "4.38" },
                   new SelectListItem { Text = "Nominal", Value = "3.29" },
                   new SelectListItem { Text = "High", Value = "2.19" },
                   new SelectListItem { Text = "Very High", Value = "1.10" }
                   //new SelectListItem { Text = "Extra High", Value = "0" }
            };
            return item;
        }


        public static List<SelectListItem> PMATList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                   new SelectListItem { Text = "Very Low", Value = "7.80" },
                   new SelectListItem { Text = "Low", Value = "6.24" },
                   new SelectListItem { Text = "Nominal", Value = "4.68" },
                   new SelectListItem { Text = "High", Value = "3.12" },
                   new SelectListItem { Text = "Very High", Value = "1.56" }
                   //new SelectListItem { Text = "Extra High", Value = "0" }
            };
            return item;
        }


        #endregion



        public ActionResult ScaleComponent()
        {

            ScaleComponentModel scaleComponentModel = new ScaleComponentModel
            {
                PREC = PRECList(),
                FLEX = FLEXList(),
                RESL = RESLList(),
                TEAM = TEAMList(),
                PMAT = PMATList()

            };

            return View(scaleComponentModel);
        }


        [HttpPost]
        public ActionResult ScaleComponent(ScaleComponentModel scaleComponentModel)
        {

            scaleComponentModel.PREC = PRECList();
            scaleComponentModel.FLEX = FLEXList();
            scaleComponentModel.RESL = RESLList();
            scaleComponentModel.TEAM = TEAMList();
            scaleComponentModel.PMAT = PMATList();

            double valuePREC = scaleComponentModel.PREC_VALUE;
            double valueFLEX = scaleComponentModel.FLEX_VALUE;
            double valueRESL = scaleComponentModel.RESL_VALUE;
            double valueTEAM = scaleComponentModel.TEAM_VALUE;
            double valuePMAT = scaleComponentModel.PMAT_VALUE;

            String textPREC;
            String textFLEX;
            String textRESL;
            String textTEAM;
            String textPMAT;




            if (valuePREC != 0 && valueFLEX != 0 && valueRESL != 0 && valueTEAM != 0 && valuePMAT != 0)
            {


                #region Texts


                //textPREC
                if (valuePREC == 6.20)
                {

                    textPREC = "Very Low";
                    Session["textPREC"] = textPREC;
                }

                if (valuePREC == 4.96)
                {

                    textPREC = "Low";
                    Session["textPREC"] = textPREC;

                }
                if (valuePREC == 3.72)
                {

                    textPREC = "Nominal";
                    Session["textPREC"] = textPREC;

                }
                if (valuePREC == 2.48)
                {

                    textPREC = "High";
                    Session["textPREC"] = textPREC;

                }
                if (valuePREC == 1.24)
                {

                    textPREC = "Very High";
                    Session["textPREC"] = textPREC;

                }


                //textFLEX

                if (valueFLEX == 5.07)
                {

                    textFLEX = "Very Low";
                    Session["textFLEX"] = textFLEX;
                }
                if (valueFLEX == 4.05)
                {

                    textFLEX = "Low";
                    Session["textFLEX"] = textFLEX;
                }
                if (valueFLEX == 3.04)
                {

                    textFLEX = "Nominal";
                    Session["textFLEX"] = textFLEX;
                }
                if (valueFLEX == 2.03)
                {

                    textFLEX = "High";
                    Session["textFLEX"] = textFLEX;
                }
                if (valueFLEX == 1.01)
                {

                    textFLEX = "Very High";
                    Session["textFLEX"] = textFLEX;
                }



                //textRESL
                if (valueRESL == 7.07)
                {

                    textRESL = "Very Low";
                    Session["textRESL"] = textRESL;
                }
                if (valueRESL == 5.65)
                {

                    textRESL = "Low";
                    Session["textRESL"] = textRESL;
                }
                if (valueRESL == 4.24)
                {

                    textRESL = "Nominal";
                    Session["textRESL"] = textRESL;
                }
                if (valueRESL == 2.83)
                {

                    textRESL = "High";
                    Session["textRESL"] = textRESL;
                }
                if (valueRESL == 1.41)
                {

                    textRESL = "Very High";
                    Session["textRESL"] = textRESL;
                }


                //textTEAM

                if (valueTEAM == 5.48)
                {

                    textTEAM = "Very Low";
                    Session["textTEAM"] = textTEAM;

                }
                if (valueTEAM == 4.38)
                {

                    textTEAM = "Low";
                    Session["textTEAM"] = textTEAM;

                }
                if (valueTEAM == 3.29)
                {

                    textTEAM = "Nominal";
                    Session["textTEAM"] = textTEAM;

                }
                if (valueTEAM == 2.19)
                {

                    textTEAM = "High";
                    Session["textTEAM"] = textTEAM;

                }
                if (valueTEAM == 1.10)
                {

                    textTEAM = "Very High";
                    Session["textTEAM"] = textTEAM;

                }

                //textPMAT
                if (valuePMAT == 7.80)
                {

                    textPMAT = "Very Low";
                    Session["textPMAT"] = textPMAT;

                }
                if (valuePMAT == 6.24)
                {

                    textPMAT = "Low";
                    Session["textPMAT"] = textPMAT;

                }
                if (valuePMAT == 4.68)
                {

                    textPMAT = "Nominal";
                    Session["textPMAT"] = textPMAT;

                }
                if (valuePMAT == 3.12)
                {

                    textPMAT = "High";
                    Session["textPMAT"] = textPMAT;

                }
                if (valuePMAT == 1.56)
                {

                    textPMAT = "Very High";
                    Session["textPMAT"] = textPMAT;

                }
                #endregion

                double resultScaleFactor = valuePREC + valueFLEX + valueRESL + valueTEAM + valuePMAT;
                double resultScaleComponent = 0.91 + 0.01 * resultScaleFactor;

                Session["resultScaleComponent"] = resultScaleComponent;



                //return View(scaleComponentModel);
                String Model = Session["Model"].ToString();

                if (Model.Equals("Early Design Model"))
                {
                    return RedirectToAction("ResultEarlyDesignModel", "COCOMOII");
                }
                else if (Model.Equals("Post Architecture Model"))
                {
                    return RedirectToAction("ResultPostArchitectureModel", "COCOMOII");
                }


            }






            return View(scaleComponentModel);
        }


        
        #endregion


        #region Results

        public ActionResult ResultApplicationCompositionModel()
        {

            double resultNewObjectPoints = Convert.ToDouble(Session["resultNewObjectPoints"]);
            int resultProductivityRate = Convert.ToInt32(Session["valueDevExp"]);
            //  double resultScaleComponent = Convert.ToDouble(Session["resultScaleComponent"]);


            double resultEffort = resultNewObjectPoints / resultProductivityRate;


            Session["resultEffort"] = Math.Floor(resultEffort);




            return View();
        }

        public ActionResult SaveResultApplicationCompositionModel()
        {
            Project p = new Project();

            p.Username = Session["user"].ToString();
            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();

            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<b>Project Name: </b> "+ Session["valueProjectName"] + "<br> <b>Process Model: </b>" + Session["valueProcessModel"] + "" +
                "<br><b>Model selected: </b>" + Session["Model"] + 
                "<br/> <hr/>" +
                "<b>Object Points: </b> <table>" +
                " <tr> <td>Object Type</td> <td>Total Screens/Reports</td> <td>Simple</td> <td>Medium</td> <td>Difficult</td> </tr>" +
                " <tr> <td>Screens</td> <td> " + Session["SCREEN_TOTAL"] + " </td> <td> " + Session["SCREEN_SIMPLE"] + "" +
                "</td> <td> " + Session["SCREEN_MEDIUM"] + " </td> <td> " + Session["SCREEN_DIFFICULT"] + " </td> </tr> <tr> <td>" +
                "Reports</td> <td> " + Session["REPORT_TOTAL"] + "</td> <td> " + Session["REPORT_SIMPLE"] + "</td> <td> " + Session["REPORT_MEDIUM"] + "" +
                " </td> <td> " + Session["REPORT_DIFFICULT"] + " </td> </tr> <tr> <td>3GL Modules</td> <td> " +
                "" + Session["MODULE_3GL"] + " </td> </tr> <tr> <td>Reuse Percentage</td> <td> " + Session["REUSE_PERCENTAGE"] + "" +
                "</td> </tr> <tr> <th>Object Points</th> <td>" + Session["resultObjectPoints"] + "</td> </tr> <tr> <th>New Object Points: </th> " +
                "<td>" + Session["resultNewObjectPoints"] + "</td> </tr> </table> " +
                "<br/> <hr/>" +
                "<b>Productivity Rate:</b>" +
                " <table> <tr> <td>Developer's Experience:  </td> <td>" + Session["textDevExp"] + "" +
                "</td> </tr> </table> <hr/> "+
                " <b>Final Estimations: </b> <table> <tr> <td>New Object Point: " +
                "" + Session["resultNewObjectPoints"] + " </td> </tr> <tr> <td>Productivity Rate:" + Session["valueDevExp"] + "" +
                "</td> </tr> <tr> <td>Effort:" + Session["resultEffort"] + "(Person-Months)</td> </tr> </table>";

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


            return RedirectToAction("ResultApplicationCompositionModel");
        }


        public ActionResult ResultEarlyDesignModel()
        {




            int resultUnadjustedFuctionPoints = Convert.ToInt32(Session["resultUnadjustedFuctionPoints"]);
            double resultValueAdjustmentFactors = Convert.ToDouble(Session["resultValueAdjustmentFactors"]);
            int valueLanguageFactor = Convert.ToInt32(Session["valueLanguageFactor"]);
            double resultScaleComponent = Convert.ToDouble(Session["resultScaleComponent"]);
            double resultEffortAdjustmentFactor = Convert.ToDouble(Session["resultEffortAdjustmentFactor"]);


            //Calculate Function Points
            double resultFunctionPoints = Math.Ceiling(resultUnadjustedFuctionPoints * resultValueAdjustmentFactors);


            //Calculate Size
            double resultSize = Math.Ceiling((resultFunctionPoints * valueLanguageFactor) / 1000);



            //Calculate Effort                
            double resultEffort = Math.Floor(2.45 * Math.Pow(resultSize, resultScaleComponent) * resultEffortAdjustmentFactor);



            //Development Time
            double resultDevelopmentTime = 3 * Math.Pow(resultEffort, (0.33 + 0.2 * (resultScaleComponent - 1.01)));
            Session["resultDevelopmentTime"] = Math.Round(resultDevelopmentTime, 0);

            //staffing
            double staff = Math.Ceiling(resultEffort / resultDevelopmentTime);



            #region Sessions for Report
            Session["resultFunctionPoints"] = resultFunctionPoints;
            Session["resultSize"] = Math.Ceiling(resultSize);
            Session["resultEffort"] = Math.Ceiling(resultEffort);
            Session["staff"] = staff;


            #endregion




            return View();
        }



        public ActionResult SaveResultEarlyDesignModel()
        {
            Project p = new Project();

            p.Username = Session["user"].ToString();
            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();
            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<b>Project Name: </b> " + Session["valueProjectName"] + "<br> <b>Process Model: </b>" + Session["valueProcessModel"] + "" +
                "<br><b>Model selected: </b>" + Session["Model"] +
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
                "<b>Value Adjustment Factors:</b>" +
                " <table> <tr> <td>Data Communication</td> <td>Distributed Data Processing</td> <td>Performance</td> </tr> <tr>" +
                " <td>" + Session["valueFactorDC"].ToString() + "</td> <td>" + Session["valueFactorDDP"].ToString() + "</td> <td>" + Session["valueFactorPER"].ToString() + "</td> </tr> <tr> " +
                "<td>Heavly Used Configuration</td> <td>Transaction Rate</td> <td>Online Data Entry</td> </tr> <tr> <td>" + Session["valueFactorHUC"].ToString() + "</td> " +
                "<td>" + Session["valueFactorTR"].ToString() + "</td> <td>" + Session["valueFactorODE"].ToString() + "</td> </tr> <tr> <td>End User Efficiency</td> <td>Online Updates" +
                "</td> <td>Complex Processing</td> </tr> <tr> <td>" + Session["valueFactorEUE"].ToString() + "</td> <td>" + Session["valueFactorOU"].ToString() + "</td> " +
                "<td>" + Session["valueFactorCP"].ToString() + "</td> </tr> <tr> <td>Resuabilty</td> <td>Installation Ease</td> <td>Operational Ease</td> </tr> <tr> <td>" + Session["valueFactorREU"].ToString() + "</td>" +
                " <td>" + Session["valueFactorIE"].ToString() + "</td> <td>" + Session["valueFactorOE"].ToString() + "</td> </tr> <tr> <td>Multiple Sites</td> <td>Facilitate Change</td> </tr> <tr>" +
                " <td>" + Session["valueFactorMS"].ToString() + "</td> <td>" + Session["valueFactorFC"].ToString() + "</td> </tr> <tr> <th>Total:</th> " +
                "<td>" + Session["resultValueAdjustmentFactors"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b> Effort Adjustment Factor:</b> "+
                "<table> <tr> <td>Product Reliability and Complexity (RCPX) </td> <td>" + Session["textRCPX"] + "</td> </tr> <tr> <td>Required Reuse (RUSE) " +
                "</td> <td>" + Session["textRUSE"] + "</td> </tr> <tr> <td> Platform Difficulty (PDIF) </td> <td>" + Session["textPDIF"] + "</td> </tr> <tr> <td>" +
                "Personnel Capability (PERS) </td> <td>" + Session["textPERS"] + "</td> </tr> <tr> <td> " +
                " Personnel Experience (PREX) </td> <td>" + Session["textPREX"] + "</td> </tr> <tr> <td>Facilities (FCIL) </td> <td>" + Session["textFCIL"] + "" +
                "</td> </tr> <tr> <td>Schedule (SCED) </td> <td>"+Session["textSCED"]+"</td> </tr> <tr> <td> <b>Total: </b></td> <td>" + Session["resultEffortAdjustmentFactor"] + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                "<b>Scale Components:" +
                "</b> <table> <tr> <td>Scale Factors:</td> <td>Weight</td> </tr> <tr> <td>Precedentedness</td> <td> " + Session["textPREC"] + "</td>" +
                " </tr> <tr> <td>Development/Flexibility</td> <td> " + Session["textFLEX"] + " </td> </tr> <tr> <td>Architecture/Risk Resolution" +
                "</td> <td> " + Session["textRESL"] + " </td> </tr> <tr> <td>Team Cohesion</td> <td> " + Session["textTEAM"] + "</td> </tr> <tr> " +
                "<td> Process Maturity</td> <td> " + Session["textPMAT"] + " </td> </tr> <tr> <th>Total: </th> <td>" + Session["resultScaleComponent"]+
                "</td> </tr> </table> " +
                "<br/> <hr/>" +
                "<b>Final Estimations: </b> <table> <tr> <td>Size: " + Session["resultSize"] + "(KLOC) </td> </tr> <tr>" +
                " <td>Effort:" + Session["resultEffort"] + " (Person-Month) </td> </tr> <tr> <td>Staff: " +
                "" + Session["staff"] + "(Persons)</td> </tr> <tr> <td>Development Time: " + Session["resultDevelopmentTime"] + "(Months)" +
                "</td> </tr> </table> ";

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


            return RedirectToAction("ResultEarlyDesignModel");
        }




        public ActionResult ResultPostArchitectureModel()
        {



            int resultUnadjustedFuctionPoints = Convert.ToInt32(Session["resultUnadjustedFuctionPoints"]);
            double resultValueAdjustmentFactors = Convert.ToDouble(Session["resultValueAdjustmentFactors"]);
            int valueLanguageFactor = Convert.ToInt32(Session["valueLanguageFactor"]);
            double resultScaleComponent = Convert.ToDouble(Session["resultScaleComponent"]);
            double resultEffortAdjustmentFactor = Convert.ToDouble(Session["resultEffortAdjustmentFactor"]);


            //Calculate Function Points
            double resultFunctionPoints = Math.Ceiling(resultUnadjustedFuctionPoints * resultValueAdjustmentFactors);



            //Calculate Size
            double resultSize = Math.Ceiling((resultFunctionPoints * valueLanguageFactor) / 1000);


            //Calculate Effort                
            double resultEffort = Math.Floor(2.45 * Math.Pow(resultSize, resultScaleComponent) * resultEffortAdjustmentFactor);

            //Development Time
            double resultDevelopmentTime = 3 * Math.Pow(resultEffort, (0.33 + 0.2 * (resultScaleComponent - 1.01)));
            Session["resultDevelopmentTime"] = Math.Round(resultDevelopmentTime, 0);

            double staff = Math.Round(resultEffort / resultDevelopmentTime, 0);

            double resultEffortManagement = (10 * resultEffort) / 100;
            double resultEffortRequirements = (12 * resultEffort) / 100;
            double resultEffortDesign = (22 * resultEffort) / 100;
            double resultEffortImplementation = (32 * resultEffort) / 100;
            double resultEffortDeployment = (24 * resultEffort) / 100;



            #region Sessions for Report
            Session["resultFunctionPoints"] = resultFunctionPoints;
            Session["resultSize"] = resultSize;
            Session["resultEffort"] = resultEffort;
            Session["staff"] = staff;

            Session["resultEffortManagement"] = resultEffortManagement;
            Session["resultEffortRequirements"] = resultEffortRequirements;
            Session["resultEffortDesign"] = resultEffortDesign;
            Session["resultEffortImplementation"] = resultEffortImplementation;
            Session["resultEffortDeployment"] = resultEffortDeployment;


            #endregion


            return View();
        }



        public ActionResult SaveResultPostArchitectureModel()
        {
            Project p = new Project();



            p.Username = Session["user"].ToString();
            p.ProjectName = Session["valueProjectName"].ToString();
            p.Technique = Session["Technique"].ToString();
            p.ProjectCalculations = "<b> Selected Technique: </b> " + Session["Technique"].ToString() + " <br> " +
                "<b>Project Name: </b> " + Session["valueProjectName"] + "<br> <b>Process Model: </b>" + Session["valueProcessModel"] + "" +
                "<br><b>Model selected: </b>" + Session["Model"] +
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
                "<b>Value Adjustment Factors:</b>" +
                " <table> <tr> <td>Data Communication</td> <td>Distributed Data Processing</td> <td>Performance</td> </tr> <tr>" +
                " <td>" + Session["valueFactorDC"].ToString() + "</td> <td>" + Session["valueFactorDDP"].ToString() + "</td> <td>" + Session["valueFactorPER"].ToString() + "</td> </tr> <tr> " +
                "<td>Heavly Used Configuration</td> <td>Transaction Rate</td> <td>Online Data Entry</td> </tr> <tr> <td>" + Session["valueFactorHUC"].ToString() + "</td> " +
                "<td>" + Session["valueFactorTR"].ToString() + "</td> <td>" + Session["valueFactorODE"].ToString() + "</td> </tr> <tr> <td>End User Efficiency</td> <td>Online Updates" +
                "</td> <td>Complex Processing</td> </tr> <tr> <td>" + Session["valueFactorEUE"].ToString() + "</td> <td>" + Session["valueFactorOU"].ToString() + "</td> " +
                "<td>" + Session["valueFactorCP"].ToString() + "</td> </tr> <tr> <td>Resuabilty</td> <td>Installation Ease</td> <td>Operational Ease</td> </tr> <tr> <td>" + Session["valueFactorREU"].ToString() + "</td>" +
                " <td>" + Session["valueFactorIE"].ToString() + "</td> <td>" + Session["valueFactorOE"].ToString() + "</td> </tr> <tr> <td>Multiple Sites</td> <td>Facilitate Change</td> </tr> <tr>" +
                " <td>" + Session["valueFactorMS"].ToString() + "</td> <td>" + Session["valueFactorFC"].ToString() + "</td> </tr> <tr> <th>Total:</th> " +
                "<td>" + Session["resultValueAdjustmentFactors"].ToString() + "</td> </tr> </table>" +
                "<br/> <hr/>" +
                " <b> Effort Adjustment Factor:</b>" +
               "<table> <tr> <td><b>PRODUCT ATTRIBUTES</b></td> </tr> <tr> <td>Required Software Reliability (RELY) </td> <td>"+Session["textRELY"]+"</td> </tr> <tr> " +
               "<td> Database Size (DATA) </td> <td>"+Session["textDATA"]+"</td> </tr> <tr> <td> Product Complexity (CPLX) </td>" +
               " <td>"+Session["textCPLX"]+"</td> </tr> <tr> <td>Documentation (DOCU) </td> <td>"+Session["textDOCU"]+"</td> </tr> <tr> " +
               "<td>Required Reusability (RUSE) </td> <td>"+Session["textRUSE"]+"</td> </tr> <tr> <td colspan='2'><b>COMPUTER ATTRIBUTES</b></td> </tr> <tr>" +
               " <td> 1. Execution Time Constraint(TIME) </td> <td>"+Session["textTIME"]+"</td> </tr> <tr> <td>Platform Volatility (PVOL) </td> " +
               "<td>"+Session["textPVOL"]+"</td> </tr> <tr> <td> Main Storage Constraint (STOR) </td> <td>"+Session["textSTOR"]+"</td> " +
               "</tr> <tr> <td colspan='2'><b>PERSONNEL ATTRIBUTES</b></td> </tr> <tr> <td> Analyst Capability (ACAP): </td> " +
                "<td>"+Session["textACAP"]+"</td> </tr> <tr> <td> Personnel Continuity (PCON): </td> <td>"+Session["textPCON"]+"</td>" +
                " </tr> <tr> <td> Programmer Experience (PEXP): </td> <td>"+Session["textPEXP"]+"</td> </tr> <tr> <td> " +
                "Programmer Capability (PCAP): </td> <td>"+Session["textPCAP"]+"</td> </tr> <tr> <td> " +
                "Analyst Experience (AEXP): </td> <td>"+Session["textAEXP"]+"</td> </tr> <tr> <td> " +
                "Language & Tool Experience (LTEX): </td> <td>"+Session["textLTEX"]+"</td> </tr> <tr> <td colspan='2'><b>PROJECT ATTRIBUTES</b>" +
                "</td> </tr> <tr> <td> 1. Use of Software Tools (TOOL): </td> <td>"+Session["textTOOL"]+"</td> </tr> <tr> <td> 2. Required Development Schedule (SCED): " +
                "</td> <td>"+Session["textSCED"]+"</td> </tr> <tr> <td> 3. Site Location & Communications Technology b/w sites (SITE): </td> <td>" +
                ""+Session["textSITE"]+"</td> </tr>" +
                "<tr> <td>Total</td> <td>" + Session["resultEffortAdjustmentFactor"].ToString() + "</td> " +
                "</tr> </table>" +
                 "<br/> <hr/>" +
                "<b>Scale Components:" +
                "</b> <table> <tr> <td>Scale Factors:</td> <td>Weight</td> </tr> <tr> <td>Precedentedness</td> <td> " + Session["textPREC"] + "</td>" +
                " </tr> <tr> <td>Development/Flexibility</td> <td> " + Session["textFLEX"] + " </td> </tr> <tr> <td>Architecture/Risk Resolution" +
                "</td> <td> " + Session["textRESL"] + " </td> </tr> <tr> <td>Team Cohesion</td> <td> " + Session["textTEAM"] + "</td> </tr> <tr> " +
                "<td> Process Maturity</td> <td> " + Session["textPMAT"] + " </td> </tr> <tr> <th>Total: </th> <td>" + Session["resultScaleComponent"] +
                "</td> </tr> </table> " +
                "<br/> <hr/>" +
                "<b>Final Estimations: </b> <table > <tr> " +
                "<td>Size:" + Session["resultSize"] + "(KLOC)</td> </tr> <tr> <td>Effort: " + Session["resultEffort"] + "(Person-Month)" +
                "</td> </tr> <tr> <td>Effort at Management phase:</td> <td>" + Session["resultEffortManagement"] + "</td> </tr> <tr> " +
                "<td>Effort at Requirements phase:</td> <td>" + Session["resultEffortRequirements"] + "</td> </tr> <tr> <td>Effort at Design phase:" +
                "</td> <td>" + Session["resultEffortDesign"] + "</td> </tr> <tr> <td>Effort at Implementation phase: </td> <td>" +
                "" + Session["resultEffortImplementation"] + "</td> </tr> <tr> <td>Effort at Deployment phase: </td> <td>" +
                "" + Session["resultEffortDeployment"] + "</td> </tr> <tr> <td>Staff" +
                "" + Session["staff"] + "(Persons) </td> </tr> <tr> <td>Development Time" +
                "" + Session["resultDevelopmentTime"] + "(Months)</td> </tr> </table>";

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
           


            return RedirectToAction("ResultPostArchitectureModel");
        }



        #endregion


    }
}