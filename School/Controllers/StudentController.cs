using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;
using Newtonsoft.Json;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        private string url = "http://localhost:5055/api/Student/";
        private HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(client.GetStringAsync(url).Result);
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentModel StudentModel)
        {
            try
            {
                var model = client.PostAsJsonAsync(url, StudentModel).Result;

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

            var model = JsonConvert.DeserializeObject<StudentModel>(client.GetStringAsync(url + id).Result);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(StudentModel StudentModel)
        {
            try
            {
                var model = client.PutAsJsonAsync<StudentModel>(url + StudentModel.Student_Id, StudentModel).Result;


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
