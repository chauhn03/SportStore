using System.Web.Mvc;

namespace SportsStore.WebUI.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {

        #region ------------- Fields ---------------

        #endregion

        #region --------------- Contructors ---------------

        #endregion

        #region --------------- Properties ---------------

        #endregion

        #region --------------- Public Methods ---------------
        //
        // GET: /Admin/News/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/News/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/News/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/News/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/News/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/News/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/News/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/News/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region --------------- Private Methods ---------------

        #endregion            
    }
}
