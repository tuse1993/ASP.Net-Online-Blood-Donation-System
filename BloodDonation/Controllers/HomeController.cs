using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private UserRepository repo = new UserRepository();
        public ActionResult Index()
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

        /*[HttpGet]
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
        }*/

        List<User> bloodList = new List<User>();

        [HttpPost,ActionName("Index")]
        public ActionResult Search(User user)
        {
                List<User> Users = this.repo.GetAll();
                int c = 0;
                foreach (User u in Users)
                {

                    if (u.bloodGroup == user.bloodGroup && u.division == user.division)
                    {
                        c++;

                    }

                }
                ViewBag.C = c;
            return View("Search");

          
           // ViewBag.Users = bloodList;
            
        }
    }
}