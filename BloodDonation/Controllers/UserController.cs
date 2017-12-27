using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonation.Controllers
{
   
    public class UserController : Controller
    {
        // GET: User
        private UserRepository repo = new UserRepository();

        [HttpGet]
        public ActionResult Registration()
        {
             List<SelectListItem> genderItem = new List<SelectListItem>();
             SelectListItem i1 = new SelectListItem() { Text = "Male", Value = "Male", Selected = true };
             SelectListItem i2 = new SelectListItem() { Text = "Female", Value = "Female", Selected = false };

             genderItem.Add(i1);
             genderItem.Add(i2);

             ViewBag.GenderDrop = genderItem;

           
             List<SelectListItem> BloodItem = new List<SelectListItem>();
             SelectListItem i3 = new SelectListItem() { Text = "A+", Value = "A+", Selected = true };
             SelectListItem i4 = new SelectListItem() { Text = "B+", Value = "B+", Selected = false };
             SelectListItem i5 = new SelectListItem() { Text = "AB+", Value = "AB+", Selected = false };
             SelectListItem i6 = new SelectListItem() { Text = "A-", Value = "A-", Selected = false };
             SelectListItem i7 = new SelectListItem() { Text = "B-", Value = "B-", Selected = false };
             SelectListItem i8 = new SelectListItem() { Text = "AB-", Value = "AB-", Selected = false };
             SelectListItem i9 = new SelectListItem() { Text = "O+", Value = "O+", Selected = false };
             SelectListItem i10 = new SelectListItem() { Text = "O-", Value = "O-", Selected = false };

             BloodItem.Add(i3);
             BloodItem.Add(i4);
             BloodItem.Add(i5);
             BloodItem.Add(i6);
             BloodItem.Add(i7);
             BloodItem.Add(i8);
             BloodItem.Add(i9);
             BloodItem.Add(i10);

             ViewBag.BloodGroupDrop = BloodItem;
           
             //Division...............................................................................................

             List<SelectListItem> DivisionItem = new List<SelectListItem>();
             SelectListItem i11 = new SelectListItem() { Text = "Dhaka", Value = "Dhaka", Selected = true };
             SelectListItem i12 = new SelectListItem() { Text = "Khulna", Value = "Khulna", Selected = false };
             SelectListItem i13 = new SelectListItem() { Text = "Barisal", Value = "Barisal", Selected = false };
             SelectListItem i14 = new SelectListItem() { Text = "Chittagong", Value = "Chittagong", Selected = false };
             SelectListItem i15 = new SelectListItem() { Text = "Mymensingh", Value = "Mymensingh", Selected = false };
             SelectListItem i16 = new SelectListItem() { Text = "Rajshahi", Value = "Rajshahi", Selected = false };
             SelectListItem i17 = new SelectListItem() { Text = "Rangpur", Value = "Rangpur", Selected = false };
             SelectListItem i18 = new SelectListItem() { Text = "Sylhet", Value = "Sylhet", Selected = false };

             DivisionItem.Add(i11);
             DivisionItem.Add(i12);
             DivisionItem.Add(i13);
             DivisionItem.Add(i14);
             DivisionItem.Add(i15);
             DivisionItem.Add(i16);
             DivisionItem.Add(i17);
             DivisionItem.Add(i18);

             ViewBag.DivisionDrop = DivisionItem;

             //Availability.......................................................................................
             List<SelectListItem> AvailItem = new List<SelectListItem>();
             SelectListItem i19 = new SelectListItem() { Text = "Yes", Value = "Yes", Selected = true };
             SelectListItem i20 = new SelectListItem() { Text = "No", Value = "No", Selected = false };

             AvailItem.Add(i19);
             AvailItem.Add(i20);

             ViewBag.AvailDrop = AvailItem;
             
            return View();           
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                this.repo.Insert(user);
                return RedirectToAction("Login");
            }
            else
            {
                List<SelectListItem> genderItem = new List<SelectListItem>();
                SelectListItem i1 = new SelectListItem() { Text = "Male", Value = "Male", Selected = false };
                SelectListItem i2 = new SelectListItem() { Text = "Female", Value = "Female", Selected = false };

                genderItem.Add(i1);
                genderItem.Add(i2);

                ViewBag.GenderDrop = genderItem;


                List<SelectListItem> BloodItem = new List<SelectListItem>();
                SelectListItem i3 = new SelectListItem() { Text = "A+", Value = "A+", Selected = true };
                SelectListItem i4 = new SelectListItem() { Text = "B+", Value = "B+", Selected = false };
                SelectListItem i5 = new SelectListItem() { Text = "AB+", Value = "AB+", Selected = false };
                SelectListItem i6 = new SelectListItem() { Text = "A-", Value = "A-", Selected = false };
                SelectListItem i7 = new SelectListItem() { Text = "B-", Value = "B-", Selected = false };
                SelectListItem i8 = new SelectListItem() { Text = "AB-", Value = "AB-", Selected = false };
                SelectListItem i9 = new SelectListItem() { Text = "O+", Value = "O+", Selected = false };
                SelectListItem i10 = new SelectListItem() { Text = "O-", Value = "O-", Selected = false };

                BloodItem.Add(i3);
                BloodItem.Add(i4);
                BloodItem.Add(i5);
                BloodItem.Add(i6);
                BloodItem.Add(i7);
                BloodItem.Add(i8);
                BloodItem.Add(i9);
                BloodItem.Add(i10);

                ViewBag.BloodGroupDrop = BloodItem;

                //Division...............................................................................................

                List<SelectListItem> DivisionItem = new List<SelectListItem>();
                SelectListItem i11 = new SelectListItem() { Text = "Dhaka", Value = "Dhaka", Selected = true };
                SelectListItem i12 = new SelectListItem() { Text = "Khulna", Value = "Khulna", Selected = false };
                SelectListItem i13 = new SelectListItem() { Text = "Barisal", Value = "Barisal", Selected = false };
                SelectListItem i14 = new SelectListItem() { Text = "Chittagong", Value = "Chittagong", Selected = false };
                SelectListItem i15 = new SelectListItem() { Text = "Mymensingh", Value = "Mymensingh", Selected = false };
                SelectListItem i16 = new SelectListItem() { Text = "Rajshahi", Value = "Rajshahi", Selected = false };
                SelectListItem i17 = new SelectListItem() { Text = "Rangpur", Value = "Rangpur", Selected = false };
                SelectListItem i18 = new SelectListItem() { Text = "Sylhet", Value = "Sylhet", Selected = false };

                DivisionItem.Add(i11);
                DivisionItem.Add(i12);
                DivisionItem.Add(i13);
                DivisionItem.Add(i14);
                DivisionItem.Add(i15);
                DivisionItem.Add(i16);
                DivisionItem.Add(i17);
                DivisionItem.Add(i18);

                ViewBag.DivisionDrop = DivisionItem;

                //Availability.......................................................................................
                List<SelectListItem> AvailItem = new List<SelectListItem>();
                SelectListItem i19 = new SelectListItem() { Text = "Yes", Value = "Yes", Selected = true };
                SelectListItem i20 = new SelectListItem() { Text = "No", Value = "No", Selected = false };

                AvailItem.Add(i19);
                AvailItem.Add(i20);

                ViewBag.AvailDrop = AvailItem;

                return View();
            }
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {

           User usr = this.repo.LoginValidation(user);

            if(usr!=null)
            {
                Session["Id"] = usr.Id.ToString();
                Session["userName"] = usr.userName.ToString();
                return RedirectToAction("Profile");
            }
           else
            {
                //ModelState.AddModelError("", "Username or password is wrong.");
                return RedirectToAction("../Home/Index");
            }
            
        }
        [HttpGet]
        public ActionResult Profile()
        {
            if(Session["Id"] != null)
            {
                int Id = Convert.ToInt32(Session["Id"]);
                return View(this.repo.Get(Id));
            }
            else
            {
                return RedirectToAction("Registration");
            }
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            User user = this.repo.Get(id);

            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                this.repo.Update(user);
                return RedirectToAction("Profile");
            }
            else
            {
                return View(user);
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            List<SelectListItem> BloodItem = new List<SelectListItem>();
            SelectListItem i3 = new SelectListItem() { Text = "A+", Value = "A+", Selected = true };
            SelectListItem i4 = new SelectListItem() { Text = "B+", Value = "B+", Selected = false };
            SelectListItem i5 = new SelectListItem() { Text = "AB+", Value = "AB+", Selected = false };
            SelectListItem i6 = new SelectListItem() { Text = "A-", Value = "A-", Selected = false };
            SelectListItem i7 = new SelectListItem() { Text = "B-", Value = "B-", Selected = false };
            SelectListItem i8 = new SelectListItem() { Text = "AB-", Value = "AB-", Selected = false };
            SelectListItem i9 = new SelectListItem() { Text = "O+", Value = "O+", Selected = false };
            SelectListItem i10 = new SelectListItem() { Text = "O-", Value = "O-", Selected = false };

            BloodItem.Add(i3);
            BloodItem.Add(i4);
            BloodItem.Add(i5);
            BloodItem.Add(i6);
            BloodItem.Add(i7);
            BloodItem.Add(i8);
            BloodItem.Add(i9);
            BloodItem.Add(i10);

            ViewBag.BloodGroupDrop = BloodItem;

            //Division...............................................................................................

            List<SelectListItem> DivisionItem = new List<SelectListItem>();
            SelectListItem i11 = new SelectListItem() { Text = "Dhaka", Value = "Dhaka", Selected = true };
            SelectListItem i12 = new SelectListItem() { Text = "Khulna", Value = "Khulna", Selected = false };
            SelectListItem i13 = new SelectListItem() { Text = "Barisal", Value = "Barisal", Selected = false };
            SelectListItem i14 = new SelectListItem() { Text = "Chittagong", Value = "Chittagong", Selected = false };
            SelectListItem i15 = new SelectListItem() { Text = "Mymensingh", Value = "Mymensingh", Selected = false };
            SelectListItem i16 = new SelectListItem() { Text = "Rajshahi", Value = "Rajshahi", Selected = false };
            SelectListItem i17 = new SelectListItem() { Text = "Rangpur", Value = "Rangpur", Selected = false };
            SelectListItem i18 = new SelectListItem() { Text = "Sylhet", Value = "Sylhet", Selected = false };

            DivisionItem.Add(i11);
            DivisionItem.Add(i12);
            DivisionItem.Add(i13);
            DivisionItem.Add(i14);
            DivisionItem.Add(i15);
            DivisionItem.Add(i16);
            DivisionItem.Add(i17);
            DivisionItem.Add(i18);

            ViewBag.DivisionDrop = DivisionItem;

            return View();
        }
        List<User> bloodList = new List<User>();
        [HttpPost]
        public ActionResult Search(User user)
        {
            List<User> Users = this.repo.GetAll();

            foreach (User u in Users)
            {

                if (u.bloodGroup == user.bloodGroup)
                {
                    bloodList.Add(u);

                }

            }

            ViewBag.Users = bloodList;
            return View("BloodDonerList");
        }
        /*
                [HttpPost]
                public ActionResult BloodDonerList(User user)
                {



                    List<User> Users =  this.repo.GetAll();

                    foreach(User u in Users)
                    {

                      if( u.bloodGroup == user.bloodGroup)
                      {
                     bloodList.Add(u);

                     }
                        List<User> donner = bloodList;

                        return View(donner);
                    }

                    return RedirectToAction("Profile");

                }
                */

        public ActionResult Logout()
        {

            

                Session["Id"] = null;
                Session["userName"] = null;
           
                return RedirectToAction("../Home/Index");
            }

        }
    }
