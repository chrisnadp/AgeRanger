using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgeRangerAPI.Models;

namespace AgeRangerAPI.Controllers
{
    public class AgeGroupsController : ApiController
    {
        private AgeRangerAPIContext db = new AgeRangerAPIContext();

        // GET: api/AgeGroups
        public IQueryable<AgeGroup> GetAgeGroups()
        {
            return db.AgeGroups;
        }

        // GET: api/AgeGroups/5
        [ResponseType(typeof(AgeGroup))]
        public IHttpActionResult GetAgeGroup(int id)
        {
            AgeGroup ageGroup = db.AgeGroups.Find(id);
            if (ageGroup == null)
            {
                return NotFound();
            }

            return Ok(ageGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgeGroupExists(int id)
        {
            return db.AgeGroups.Count(e => e.Id == id) > 0;
        }
    }
}