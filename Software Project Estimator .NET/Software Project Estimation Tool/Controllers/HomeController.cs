using Software_Project_Estimation_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Software_Project_Estimation_Tool.Controllers
{
    public class HomeController : Controller
    {


        #region Project Name and Process Model

        

        public static List<SelectListItem> ProcessModelList() {

            List<SelectListItem> item = new List<SelectListItem>

            {

                new SelectListItem{Text="Waterfall Model",Value="Waterfall Model"},
                new SelectListItem{Text="Prototyping",Value="Prototyping"},
                new SelectListItem{Text="Incremental Development",Value="Incremental Development"},
                new SelectListItem{Text="Spiral Model",Value="Spiral Model"},
                new SelectListItem{Text="Agile",Value="Agile"}
             

            };

            return item;

        }


        public ActionResult Index()
        {
            ProjectNameModel model = new ProjectNameModel();
            model.PROCESS_MODEL = ProcessModelList();
            
            return View(model);
        }


        [HttpPost]
        public ActionResult Index(ProjectNameModel model)
        {
            model.PROCESS_MODEL = ProcessModelList();

            String ValueProjectName = model.PROJECT_NAME;
            String ValueProcessModel = model.PROCESS_MODEL_VALUE;

            String Technique;


            if (ValueProjectName != null && ValueProcessModel != null)
            {
                Session["ValueProjectName"] = ValueProjectName;
                Session["ValueProcessModel"] = ValueProcessModel;
                

                if (ValueProcessModel.Equals("Waterfall Model")) {
                    
                    Technique = "COCOMO1";
                    Session["Technique"] = Technique;
                    return RedirectToAction("Size","Home",  new { technique = "COCOMO1" } );
                    //return RedirectToAction("COCOMOI","COCOMOI",new {area="COCOMOI" });
                }


                if (ValueProcessModel.Equals("Prototyping"))
                {
                    Technique = "COCOMO2";
                    Session["Technique"] = Technique;

                    return RedirectToAction("SelectTechnique", "Home");
                    // return RedirectToAction("COCOMOII", "COCOMOII", new { area = "COCOMOII" });

                }


                if (ValueProcessModel.Equals("Incremental Development"))
                {

                    Technique = "SLIM";
                    Session["Technique"] = Technique;
                    return RedirectToAction("SelectTechnique", "Home");
                   // return RedirectToAction("SLIM", "SLIM", new { area = "SLIM" });

                }


                if (ValueProcessModel.Equals("Spiral Model"))
                {

                    Technique = "COCOMO2";
                    Session["Technique"] = Technique;
                    return RedirectToAction("SelectTechnique", "Home");
                    //return RedirectToAction("COCOMOII", "COCOMOII", new { area = "COCOMOII" });

                }


                if (ValueProcessModel.Equals("Agile"))
                {

                    Technique = "SLIM";
                    Session["Technique"] = Technique;
                    return RedirectToAction("SelectTechnique", "Home");
                   // return RedirectToAction("SLIM", "SLIM", new { area = "SLIM" });

                }


            }

            
            return View(model);
        }



        #endregion






        #region Size of the Project

        
        public ActionResult Size(string technique)
        {
            Session["Technique"] = technique;
            return View();
        }


        #endregion

        #region Unadjusted Fuction Points

        public ActionResult UnadjustedFunctionPoints()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnadjustedFunctionPoints(UnadjustedFunctionPointsModel model)
        {


            int SUM_EI = 0;
            int SUM_EO = 0;
            int SUM_EQ = 0;
            int SUM_EIF = 0;
            int SUM_ILF = 0;



            String s_EI_LOW = model.EI_LOW;
            String s_EI_AVERAGE = model.EI_AVERAGE;
            String s_EI_HIGH = model.EI_HIGH;

            String s_EO_LOW = model.EO_LOW;
            String s_EO_AVERAGE = model.EO_AVERAGE;
            String s_EO_HIGH = model.EO_HIGH;

            String s_EQ_LOW = model.EQ_LOW;
            String s_EQ_AVERAGE = model.EQ_AVERAGE;
            String s_EQ_HIGH = model.EQ_HIGH;

            String s_EIF_LOW = model.EIF_LOW;
            String s_EIF_AVERAGE = model.EIF_AVERAGE;
            String s_EIF_HIGH = model.EIF_HIGH;

            String s_ILF_LOW = model.ILF_LOW;
            String s_ILF_AVERAGE = model.ILF_AVERAGE;
            String s_ILF_HIGH = model.ILF_HIGH;



            if (s_EI_LOW != null &&
               s_EI_AVERAGE != null &&
               s_EI_HIGH != null &&
               s_EO_LOW != null &&
               s_EO_AVERAGE != null &&
               s_EO_HIGH != null &&
               s_EQ_LOW != null &&
               s_EQ_AVERAGE != null &&
               s_EQ_HIGH != null &&
               s_EIF_LOW != null &&
               s_EIF_AVERAGE != null &&
               s_EIF_HIGH != null &&
               s_ILF_LOW != null &&
               s_ILF_AVERAGE != null &&
               s_ILF_HIGH != null)
            {


                int EI_LOW = Convert.ToInt32(s_EI_LOW);
                int EI_AVERAGE = Convert.ToInt32(s_EI_AVERAGE);
                int EI_HIGH = Convert.ToInt32(s_EI_HIGH);
                int EO_LOW = Convert.ToInt32(s_EO_LOW);
                int EO_AVERAGE = Convert.ToInt32(s_EO_AVERAGE);
                int EO_HIGH = Convert.ToInt32(s_EO_HIGH);
                int EQ_LOW = Convert.ToInt32(s_EQ_LOW);
                int EQ_AVERAGE = Convert.ToInt32(s_EQ_AVERAGE);
                int EQ_HIGH = Convert.ToInt32(s_EQ_HIGH);
                int EIF_LOW = Convert.ToInt32(s_EIF_LOW);
                int EIF_AVERAGE = Convert.ToInt32(s_EIF_AVERAGE);
                int EIF_HIGH = Convert.ToInt32(s_EIF_HIGH);
                int ILF_LOW = Convert.ToInt32(s_ILF_LOW);
                int ILF_AVERAGE = Convert.ToInt32(s_ILF_AVERAGE);
                int ILF_HIGH = Convert.ToInt32(s_ILF_HIGH);




                SUM_EI = (EI_LOW * 3) + (EI_AVERAGE * 4) + (EI_HIGH * 6);

                SUM_EO = (EO_LOW * 4) + (EO_AVERAGE * 5) + (EO_HIGH * 7);

                SUM_EQ = (EQ_LOW * 3) + (EQ_AVERAGE * 4) + (EQ_HIGH * 6);

                SUM_EIF = (EIF_LOW * 5) + (EIF_AVERAGE * 7) + (EIF_HIGH * 10);

                SUM_ILF = (ILF_LOW * 7) + (ILF_AVERAGE * 10) + (ILF_HIGH * 15);



                int resultUnadjustedFuctionPoints = SUM_EI + SUM_EO + SUM_EQ + SUM_EIF + SUM_ILF;





                #region Sessions for Report

                Session["EI_LOW"] = EI_LOW;
                Session["EI_AVERAGE"] = EI_AVERAGE;
                Session["EI_HIGH"] = EI_HIGH;

                Session["EO_LOW"] = EO_LOW;
                Session["EO_AVERAGE"] = EO_AVERAGE;
                Session["EO_HIGH"] = EO_HIGH;

                Session["EQ_LOW"] = EQ_LOW;
                Session["EQ_AVERAGE"] = EQ_AVERAGE;
                Session["EQ_HIGH"] = EQ_HIGH;


                Session["EIF_LOW"] = EIF_LOW;
                Session["EIF_AVERAGE"] = EIF_AVERAGE;
                Session["EIF_HIGH"] = EIF_HIGH;

                Session["ILF_LOW"] = ILF_LOW;
                Session["ILF_AVERAGE"] = ILF_AVERAGE;
                Session["ILF_HIGH"] = ILF_HIGH;


                Session["SUM_EI "] = SUM_EI;

                Session["SUM_EO "] = SUM_EO;

                Session["SUM_EQ "] = SUM_EQ;

                Session["SUM_EIF"] = SUM_EIF;

                Session["SUM_ILF"] = SUM_ILF;

                Session["resultUnadjustedFuctionPoints"] = resultUnadjustedFuctionPoints;




                #endregion


                return RedirectToAction("ValueAdjustmentFactors", "Home");
            }

            else

            {
                return View();

            }




        }




        #endregion

        #region Value Adjustment Factors


        #region List Value Adjustment Factors
        public static List<SelectListItem> VAFList()
        {
            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "0", Value = "0" },
                new SelectListItem { Text = "1", Value = "1" },
                new SelectListItem { Text = "2", Value = "2" },
                new SelectListItem { Text = "3", Value = "3" },
                new SelectListItem { Text = "4", Value = "4" },
                new SelectListItem { Text = "5", Value = "5" }
            };
            return item;


        }
        #endregion



        #region Calculate Value Adjustment Factors

        public ActionResult ValueAdjustmentFactors()
        {
            ValueAdjustmentFactorsModel valueAdjustmentFactorsModel = new ValueAdjustmentFactorsModel
            {
                FACTOR_DC = VAFList(),
                FACTOR_DDP = VAFList(),
                FACTOR_PER = VAFList(),
                FACTOR_HUC = VAFList(),
                FACTOR_TR = VAFList(),
                FACTOR_ODE = VAFList(),
                FACTOR_EUE = VAFList(),
                FACTOR_OU = VAFList(),
                FACTOR_CP = VAFList(),
                FACTOR_REU = VAFList(),
                FACTOR_IE = VAFList(),
                FACTOR_OE = VAFList(),
                FACTOR_MS = VAFList(),
                FACTOR_FC = VAFList(),

            };

            return View(valueAdjustmentFactorsModel);
        }

        [HttpPost]
        public ActionResult ValueAdjustmentFactors(ValueAdjustmentFactorsModel valueAdjustmentFactorsModel)
        {



            valueAdjustmentFactorsModel.FACTOR_DC = VAFList();
            valueAdjustmentFactorsModel.FACTOR_DDP = VAFList();
            valueAdjustmentFactorsModel.FACTOR_PER = VAFList();
            valueAdjustmentFactorsModel.FACTOR_HUC = VAFList();
            valueAdjustmentFactorsModel.FACTOR_TR = VAFList();
            valueAdjustmentFactorsModel.FACTOR_ODE = VAFList();
            valueAdjustmentFactorsModel.FACTOR_EUE = VAFList();
            valueAdjustmentFactorsModel.FACTOR_OU = VAFList();
            valueAdjustmentFactorsModel.FACTOR_CP = VAFList();
            valueAdjustmentFactorsModel.FACTOR_REU = VAFList();
            valueAdjustmentFactorsModel.FACTOR_IE = VAFList();
            valueAdjustmentFactorsModel.FACTOR_OE = VAFList();
            valueAdjustmentFactorsModel.FACTOR_MS = VAFList();
            valueAdjustmentFactorsModel.FACTOR_FC = VAFList();




            // Values
            int valueFactorDC = valueAdjustmentFactorsModel.FACTOR_DC_VALUE;
            int valueFactorDDP = valueAdjustmentFactorsModel.FACTOR_DDP_VALUE;
            int valueFactorPER = valueAdjustmentFactorsModel.FACTOR_PER_VALUE;
            int valueFactorHUC = valueAdjustmentFactorsModel.FACTOR_HUC_VALUE;
            int valueFactorTR = valueAdjustmentFactorsModel.FACTOR_TR_VALUE;
            int valueFactorODE = valueAdjustmentFactorsModel.FACTOR_ODE_VALUE;
            int valueFactorEUE = valueAdjustmentFactorsModel.FACTOR_EUE_VALUE;
            int valueFactorOU = valueAdjustmentFactorsModel.FACTOR_OU_VALUE;
            int valueFactorCP = valueAdjustmentFactorsModel.FACTOR_CP_VALUE;
            int valueFactorREU = valueAdjustmentFactorsModel.FACTOR_REU_VALUE;
            int valueFactorIE = valueAdjustmentFactorsModel.FACTOR_IE_VALUE;
            int valueFactorOE = valueAdjustmentFactorsModel.FACTOR_OE_VALUE;
            int valueFactorMS = valueAdjustmentFactorsModel.FACTOR_MS_VALUE;
            int valueFactorFC = valueAdjustmentFactorsModel.FACTOR_FC_VALUE;









            // Total degree of influence
            double TDI = valueFactorDC + valueFactorDDP + valueFactorPER + valueFactorHUC + valueFactorTR + valueFactorODE + valueFactorEUE + valueFactorOU + valueFactorCP + valueFactorREU + valueFactorIE + valueFactorOE + valueFactorMS + valueFactorFC;



            double resultValueAdjustmentFactors = (TDI * 0.01) + 0.65;

            #region Sessions for Reports 


            Session["valueFactorDC"] = valueFactorDC;
            Session["valueFactorDDP"] = valueFactorDDP;
            Session["valueFactorPER"] = valueFactorPER;
            Session["valueFactorHUC"] = valueFactorHUC;
            Session["valueFactorTR"] = valueFactorTR;
            Session["valueFactorODE"] = valueFactorODE;
            Session["valueFactorEUE"] = valueFactorEUE;
            Session["valueFactorOU"] = valueFactorOU;
            Session["valueFactorCP"] = valueFactorCP;
            Session["valueFactorREU"] = valueFactorREU;
            Session["valueFactorIE"] = valueFactorIE;
            Session["valueFactorOE"] = valueFactorOE;
            Session["valueFactorMS"] = valueFactorMS;
            Session["valueFactorFC"] = valueFactorFC;

            Session["resultValueAdjustmentFactors"] = resultValueAdjustmentFactors;


            #endregion



            String Technique = Session["Technique"].ToString();

            if (Technique.Equals("COCOMO1"))
            {
                return RedirectToAction("LanguageFactor", "Home");
            }
            if (Technique.Equals("COCOMO2"))
            {
                return RedirectToAction("LanguageFactor", "Home");
            }
            if (Technique.Equals("SLIM"))
            {
                return RedirectToAction("LanguageFactor", "Home");
            }








            //String Stage = Session["Stage"].ToString();




            //if (Stage.Equals("Basic Stage"))
            //{


            //    return RedirectToAction("ResultBasicStage", "COCOMOI");
            //}

            //if (Stage.Equals("Intermediate Stage"))
            //{

            //    return RedirectToAction("CostDrivers", "COCOMOI");

            //}

            //if (Stage.Equals("Advanced Stage"))
            //{

            //    return RedirectToAction("CostDrivers", "COCOMOI");

            //}








            return View(valueAdjustmentFactorsModel);
        }

        #endregion


        #endregion

        #region Languages Factor

        #region List Language Factor

        public static List<SelectListItem> LanguageFactorList()
        {

            List<SelectListItem> item = new List<SelectListItem>
            {
                new SelectListItem { Text = "C", Value = "97" },
                new SelectListItem { Text = "C++", Value = "50" },
                new SelectListItem { Text = ".NET", Value = "57" },
                new SelectListItem { Text = "C#", Value = "54" },
                new SelectListItem { Text = "Java", Value = "53" },
                new SelectListItem { Text = "Java Script", Value = "47" },
                new SelectListItem { Text = "Visual Basic", Value = "42"},
                new SelectListItem { Text = "Perl", Value = "24" },
                new SelectListItem { Text = "Html", Value = "34" },
                new SelectListItem { Text = "Oracal", Value = "37"},
                new SelectListItem { Text = "SQL", Value = "21"}
            };


            return item;
        }






        #endregion

        #region Calculate Language Factor

        public ActionResult LanguageFactor()
        {
            LanguageFactorModel languageFactorModel = new LanguageFactorModel
            {
                LANGUAGE_FACTOR = LanguageFactorList()
            };




            return View(languageFactorModel);
        }


        [HttpPost]
        public ActionResult LanguageFactor(LanguageFactorModel languageFactorModel)
        {

            languageFactorModel.LANGUAGE_FACTOR = LanguageFactorList();

            int valueLanguageFactor = languageFactorModel.LANGUAGE_FACTOR_VALUE;
            var textLanguageFactor = languageFactorModel.LANGUAGE_FACTOR.Find(p => p.Value == languageFactorModel.LANGUAGE_FACTOR_VALUE.ToString());





            if (valueLanguageFactor != 0)
            {
                if (textLanguageFactor != null)
                {

                    textLanguageFactor.Selected = true;



                    #region Session for Report

                    Session["textLanguageFactor"] = textLanguageFactor.Text;
                    Session["valueLanguageFactor"] = valueLanguageFactor;

                    #endregion



                    String Technique = Session["Technique"].ToString();

                    if (Technique.Equals("COCOMO1"))
                    {
                        return RedirectToAction("COCOMOI", "COCOMOI", new { area = "COCOMOI" });
                    }
                    if (Technique.Equals("COCOMO2"))
                    {

                        return RedirectToAction("COCOMOII", "COCOMOII", new { area = "COCOMOII" });
                    }
                    if (Technique.Equals("SLIM"))
                    {
                        return RedirectToAction("SLIM", "SLIM", new { area = "SLIM" });
                    }







                }

                else
                    return View(languageFactorModel);

            }




            return View(languageFactorModel);
        }


        #endregion



        #endregion




        public ActionResult SelectTechnique()
        {
            return View();
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Account()
        {

            try
            {
                // Home is default controller
                Session["controller"] = (Request.UrlReferrer.Segments.Skip(1).Take(1).SingleOrDefault() ?? "Home").Trim('/').ToString();

                // Index is default action 
                Session["action"] = (Request.UrlReferrer.Segments.Skip(2).Take(1).SingleOrDefault() ?? "Index").Trim('/').ToString();
            }
            catch (Exception e)
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult Account(User user)
        {
            try
            {

                using (SPEToolDBEntities dbModel = new SPEToolDBEntities())
                {
                    if (dbModel.Users.Any(x => x.Username == user.Username))
                    {
                        ViewBag.DuplicateMSG = "User already exists.";
                        return View();
                    }
                    dbModel.Users.Add(user);
                    dbModel.SaveChanges();
                }
                ModelState.Clear();
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return RedirectToAction("Index", "Error");
            }

            Session["user"] = user.Username.ToString();
            ViewBag.SucessMSG = "Sucessfully added";
            return RedirectToAction(Session["action"].ToString(), Session["controller"].ToString());
        }




        [HttpPost]
        public ActionResult Login(User u)
        {
            try
            {



                SPEToolDBEntities db = new SPEToolDBEntities();
                var x = db.Users.SqlQuery("Select * From [User] where Username='" + u.Username + "' and password='" + u.Password + "'").ToList();
                if (x.Count > 0)
                {
                    Session["email"] = x[0].Email;
                    Session["org"] = x[0].OrgnizationName;
                    Session["pos"] = x[0].Position;
                    Session["user"] = u.Username.ToString();
                    return RedirectToAction(Session["action"].ToString(), Session["controller"].ToString());
                }
                else
                {
                    TempData["errorMSG"] = "Either user name or password are incorrect. Please try again.";
                }

                return RedirectToAction("Account", "Home");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return RedirectToAction("Index", "Error");
            }
        }


        public ActionResult Logout()
        {
            Session["user"] = null;
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
               return RedirectToAction("Index", "Error");
            }
        }
        public ActionResult UserProfile()
        {
            try
            {
                SPEToolDBEntities db = new SPEToolDBEntities();

                var projectList = db.Projects.SqlQuery("Select * From Project where Username='" + Session["user"] + "'").ToList();
                var p = db.Projects.SqlQuery("Select * From Project where Username='" + Session["user"] + "'").ToList();

                ViewBag.v = p.LongCount();

                /* EstimatorDBEntities1 db1 = new EstimatorDBEntities1();
                 var x = db1.Users.SqlQuery("Select Email From [User] where Username='" + Session["user"].ToString() +"'").ToList();
                 ViewBag.email=x[0]; */
    
                return View(projectList);
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return RedirectToAction("Index", "Error");
            }

        }
        public ActionResult Display(int id)
        {
            try
            {


                SPEToolDBEntities db = new SPEToolDBEntities();

                var projectList = db.Projects.SqlQuery("Select * From Project where ID='" + id + "'").ToList();

                return View(projectList);
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return RedirectToAction("Index", "Error");
            }
        }


        public ActionResult Delete (int id)
        {
            try
            {
                SPEToolDBEntities db = new SPEToolDBEntities();
                var projectList = db.Projects.SqlQuery("Select * From Project where ID='" + id + "'").ToList();

                //           db.Projects.SqlQuery("Delete * From Project where ProjectName='" + name + "'");


                var projects = db.Projects.Where(p => p.ID == id).ToList();
                db.Projects.Remove(projects[0]);
                db.SaveChanges();

                return RedirectToAction("UserProfile");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return RedirectToAction("Index", "Error");
            }
        }





        public ActionResult FAQ()
        {


            return View();
        }

        public ActionResult Cost()
        {
            return View();
        }
        
        public ActionResult Publications()
        {
            return View();
        }

        public ActionResult GetPaper()
        {
            string filePath = "~/Docs/1570441131.pdf";
            return File(filePath, "application/pdf");
        }
        public ActionResult GetAcceptanceLetter()
        {
            string filePath = "~/Docs/066.pdf";
            return File(filePath, "application/pdf");
        }
    }
}