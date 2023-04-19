using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using Newtonsoft.Json;

namespace School.Controllers
{
    public class SubjectController : Controller
    {
        private string url = "http://localhost:5055/api/Subject/";
        private HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<SubjectModels>>(client.GetStringAsync(url).Result);
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubjectModels SubjectModels)
        {
            try
            {
                var model = client.PostAsJsonAsync(url, SubjectModels).Result;

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

            var model = JsonConvert.DeserializeObject<SubjectModels>(client.GetStringAsync(url + id).Result);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(SubjectModels SubjectModels)
        {
            try
            {
                var model = client.PutAsJsonAsync<SubjectModels>(url + SubjectModels.Subject_Id, SubjectModels).Result;


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
