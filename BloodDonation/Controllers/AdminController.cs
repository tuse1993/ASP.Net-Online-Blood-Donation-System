using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonation.Controllers
{
    public class AdminController : Controller
    {
        private AdminRepository repo = new AdminRepository();
        private UserRepository repoUser = new UserRepository();

        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            Admin adm = this.repo.LoginValidation(admin);

            if (adm != null)
            {
                Session["Id"] = adm.Id.ToString();
                Session["username"] = adm.userName.ToString();
                return RedirectToAction("Profile");
            }
            else
                return RedirectToAction("../Admin/Login");
        }
        [HttpGet]
        public ActionResult Profile()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                return View();
            }
            else
            {
                return RedirectToAction("../Admin/Login");
            }

        }
        [HttpGet]
        public ActionResult ViewAllmember()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                // UserRepository us = new UserRepository();

                List<User> Users = this.repoUser.GetAll();

                return View(Users);
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }

        }

        [HttpGet]
        public ActionResult Registration()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                return View();
            }
            else
            {
                return View("Home/Index");//vul korche ovi
            }

        }

        [HttpPost]
        public ActionResult Registration(Admin admin)
        {
            if (ModelState.IsValid)
            {
                this.repo.Insert(admin);
                return RedirectToAction("Profile");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult showAllAdmin()
        {
            if (Session["Id"] != null)
            {
                //int Id = Convert.ToInt32(Session["Id"]);
                //return View(this.repo.Get(Id));
                // UserRepository us = new UserRepository();

                List<Admin> Admins = this.repo.GetAll();

                return View(Admins);
            }
            else
            {
                return RedirectToAction("../Home/Index");
            }

        }


        [HttpGet]
        public ActionResult Search()
        {

            return View();
        }


        List<User> bloodList = new List<User>();
        [HttpGet]
        public ActionResult Active()
        {
            List<User> Users = this.repoUser.GetAll();

            foreach (User u in Users)
            {

                if (u.available == "Yes")
                {
                    bloodList.Add(u);

                }

            }

            ViewBag.Users = bloodList;
            return View();
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {

            return View(this.repo.Get(id));
        }


        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteAdmin(int id)
        {
            this.repo.Delete(id);

            return RedirectToAction("showAllAdmin");
        }

        
               [HttpGet]
        public ActionResult DeleteMember(int id)
        {

            return View(this.repoUser.Get(id));
        }


        [HttpPost, ActionName("DeleteMember")]
        public ActionResult DeleteMemberbyId(int id)
        {
            this.repoUser.Delete(id);

            return RedirectToAction("ViewAllmember");
        }
        public ActionResult Logout()
        {



            Session["Id"] = null;
            Session["userName"] = null;

            return RedirectToAction("../Home/Index");
        }

        [HttpGet]
        public ActionResult UserRegistration()
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
        public ActionResult UserRegistration(User user)
        {
            if (ModelState.IsValid)
            {
                this.repoUser.Insert(user);
                return RedirectToAction("Profile");
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

    }
}