using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using Newtonsoft.Json;

namespace Schools.Controllers
{
    public class TeacherController : Controller
    {
        private string url = "http://localhost:5055/api/Teacher/";
        private HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<TeacherModel>>(client.GetStringAsync(url).Result);
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherModel TeacherModel)
        {
            try
            {
                var model = client.PostAsJsonAsync(url, TeacherModel).Result;

                if (model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            catch (Exception Ex)
            {
                ViewBag.Msg = Ex.Message;
            }

            return View();

        }


        public IActionResult Delete(string id)
        {
            try
            {
                var model = client.DeleteAsync(url + id).Result;

                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


            }
            catch (Exception Ex)
            {
                ViewBag.Msg = Ex.Message;
            }

            return View();

        }


        public IActionResult Update(string id)
        {

            var model = JsonConvert.DeserializeObject<TeacherModel>(client.GetStringAsync(url + id).Result);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(TeacherModel TeacherModel)
        {
            try
            {
                var model = client.PutAsJsonAsync<TeacherModel>(url + TeacherModel.Teacher_Id, TeacherModel).Result;


                if (ModelState.IsValid && model.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fail");
                    return View();
                }

            }
            catch (Exception ex)
            {

                ViewBag.Msg = ex.Message;
            }
            return View();
        }
    }
}
