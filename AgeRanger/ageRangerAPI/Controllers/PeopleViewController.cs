using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgeRangerAPI.Models;

namespace AgeRangerAPI.Controllers
{
    public class PeopleViewController : Controller
    {
        private AgeRangerAPIContext db = new AgeRangerAPIContext();

        private List<PersonAgeGroup> getPeopleAgeGroup(string SearchFirstName, string SearchLastName)
        {
            var query =
                (from people in db.People
                 from agegroups in db.AgeGroups
                 where people.Age >= (agegroups.MinAge ?? people.Age - 1)
                 where people.Age < (agegroups.MaxAge ?? people.Age + 1)
                 select new PersonAgeGroup
                 {
                     Person = people,
                     AgeGroup = agegroups
                 });
                        
            if (!String.IsNullOrEmpty(SearchFirstName))
            {
                query = query.Where(s => s.Person.FirstName.ToLower().Contains(SearchFirstName.ToLower()));
            }

            if (!String.IsNullOrEmpty(SearchLastName))
            {
                query = query.Where(s => s.Person.LastName.ToLower().Contains(SearchLastName.ToLower()));
            }
            return query.ToList<PersonAgeGroup>();
        }
        // GET: PeopleView
        public ActionResult Index(string SearchFirstName, string SearchLastName)
        {
            PeopleViewModel peopleModel = new PeopleViewModel();



            peopleModel.PeopleAgeGroup = getPeopleAgeGroup(SearchFirstName, SearchLastName);
            peopleModel.SelectedPerson = null;
            peopleModel.DisplayMode = null;
            return View(peopleModel);
        }

        // GET: PeopleView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleViewModel model = new PeopleViewModel();
            model.PeopleAgeGroup = getPeopleAgeGroup(null, null);
            model.SelectedPerson = db.People.Find(id);

            if (model.SelectedPerson == null)
            {
                return HttpNotFound();
            }
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }

        // GET: PeopleView/Create
        public ActionResult Create()
        {
            PeopleViewModel model = new PeopleViewModel();
            model.PeopleAgeGroup = getPeopleAgeGroup(null, null);
            model.SelectedPerson = null;
            model.DisplayMode = "WriteOnly";
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Cancel(string id)
        {
            PeopleViewModel model = new PeopleViewModel();
            model.PeopleAgeGroup = getPeopleAgeGroup(null, null);
            model.SelectedPerson = db.People.Find(id);
            model.DisplayMode = "ReadOnly";
            return View("Index", model);
        }

        // POST: PeopleView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Age")] Person person)
        {
            PeopleViewModel model = new PeopleViewModel();
            if (ModelState.IsValid)
            {

                db.People.Add(person);
                db.SaveChanges();

                model.PeopleAgeGroup = getPeopleAgeGroup(null, null);

                model.SelectedPerson = db.People.Find(person.Id);
                model.DisplayMode = "ReadOnly";
                return View("Index", model);

            }

            //model.PeopleAgeGroup = db.People.ToList();
            return View("Index", model);
        }

        // GET: PeopleView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeopleViewModel model = new PeopleViewModel();
            model.PeopleAgeGroup = getPeopleAgeGroup(null, null);
            model.SelectedPerson = db.People.Find(id);
            if (model.SelectedPerson == null)
            {
                return HttpNotFound();
            }
            model.DisplayMode = "ReadWrite";
            return View("Index", model);
        }

        // POST: PeopleView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Age")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: PeopleView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: PeopleView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
