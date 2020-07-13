using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AfricanMagic.Models;

namespace AfricanMagic.Controllers
{
    public class InventoryController : Controller
    {
        private Context db = new Context();

        public async Task<ActionResult> Index()
        {
            return View(await db.Inventories.ToListAsync());
        }


        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }


        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemID,ItemName,ItemDescription,Category,Colour,Size,ItemPrice,ItemImage")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ItemID,ItemName,ItemDescription,Category,Colour,Size,ItemPrice,ItemImage")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            db.Inventories.Remove(inventory);
            await db.SaveChangesAsync();
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
