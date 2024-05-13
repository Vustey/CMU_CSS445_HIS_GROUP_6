using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DashboardPremium.Models;

namespace DashboardPremium.Controllers
{
    public class BENEFIT_PLANSController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: BENEFIT_PLANS
        public ActionResult Index()
        {
            return View(db.BENEFIT_PLANS.ToList());
        }

        // GET: BENEFIT_PLANS/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENEFIT_PLANS bENEFIT_PLANS = db.BENEFIT_PLANS.Find(id);
            if (bENEFIT_PLANS == null)
            {
                return HttpNotFound();
            }
            return View(bENEFIT_PLANS);
        }

        // GET: BENEFIT_PLANS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BENEFIT_PLANS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BENEFIT_PLANS_ID,PLAN_NAME,DEDUCTABLE,PERCENTAGE_COPAY")] BENEFIT_PLANS bENEFIT_PLANS)
        {
            if (ModelState.IsValid)
            {
                db.BENEFIT_PLANS.Add(bENEFIT_PLANS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bENEFIT_PLANS);
        }

        // GET: BENEFIT_PLANS/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENEFIT_PLANS bENEFIT_PLANS = db.BENEFIT_PLANS.Find(id);
            if (bENEFIT_PLANS == null)
            {
                return HttpNotFound();
            }
            return View(bENEFIT_PLANS);
        }

        // POST: BENEFIT_PLANS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BENEFIT_PLANS_ID,PLAN_NAME,DEDUCTABLE,PERCENTAGE_COPAY")] BENEFIT_PLANS bENEFIT_PLANS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bENEFIT_PLANS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bENEFIT_PLANS);
        }

        // GET: BENEFIT_PLANS/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENEFIT_PLANS bENEFIT_PLANS = db.BENEFIT_PLANS.Find(id);
            if (bENEFIT_PLANS == null)
            {
                return HttpNotFound();
            }
            return View(bENEFIT_PLANS);
        }

        // POST: BENEFIT_PLANS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            BENEFIT_PLANS bENEFIT_PLANS = db.BENEFIT_PLANS.Find(id);
            db.BENEFIT_PLANS.Remove(bENEFIT_PLANS);
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
