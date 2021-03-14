using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNDP_Project1.Models;
using UNDP_Project1.Models.Wrappers;

namespace UNDP_Project1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UNDPEntities _context = new UNDPEntities();
        public ActionResult Index()
        {
            var model = new Team();
            return View(model);
        }

        public PartialViewResult AddUserPartialView(TeamMember model)
        {
            ViewBag.Genders = StaticData.Genders;
            model.Gender = "Male";
            return PartialView(model);
        }

        [HttpGet]
        public JsonResult AddNewTeamMember(TeamMember model)
        {
            bool success = true;
            var error = new List<string>();

            if (string.IsNullOrEmpty(model.Name))
            {
                success = false;
                error.Add("Name is empty !");
            }

            if (!model.DateOfBirth.HasValue)
            {
                success = false;
                error.Add("Date of Birth is invalid !");
            }

            if (model.ContactNo == 0)
            {
                success = false;
                error.Add("ContactNo is invalid !");
            }

            List<TeamMember> teamMembers = TempData["TeamMembers"] as List<TeamMember>;
            if (teamMembers == null)
            {
                teamMembers = new List<TeamMember>();
            }

            if (success)
            {
                teamMembers.Add(model);
                TempData["TeamMembers"] = teamMembers;
            }

            var result = RenderViewToString("UserAdded", teamMembers);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTeam(Team model)
        {
            bool success = true;
            List<string> errors = new List<string>();

            if (string.IsNullOrEmpty(model.TeamName))
            {
                success = false;
                errors.Add("Team Name is empty");
            }

            if (string.IsNullOrEmpty(model.TeamDescription))
            {
                success = false;
                errors.Add("Team Description is empty");
            }

            if (success)
            {
                _context.Teams.Add(model);
                _context.SaveChanges();

                List<TeamMember> teamMembers = TempData["TeamMembers"] as List<TeamMember>;

                foreach (var member in teamMembers)
                {
                    member.TeamID = model.ID;
                    _context.TeamMembers.Add(member);
                }

                _context.SaveChanges();

            }

            TempData["AddTeamSuccess"] = success;
            TempData["AddTeamErrors"] = errors;

            return RedirectToAction("Index");
        }

    }
}