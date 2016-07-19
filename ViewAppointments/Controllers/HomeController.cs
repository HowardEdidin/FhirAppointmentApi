using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using ViewAppointments.Models;
using System.Media;

namespace ViewAppointments.Controllers
{
    public class HomeController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDbRepository<AppointmentRequest>.GetItemsAsync(response => response.HasAttachment);
            return View(items);
        }

        // ReSharper disable once ConsiderUsingAsyncSuffix
        public async Task<ActionResult> GridViewPartialView()
        {
            var items = await DocumentDbRepository<AppointmentRequest>.GetItemsAsync(response => response.HasAttachment);
            return View(items);
        }

        [ValidateInput(false)]
        public JsonResult PlayVoiceFile(
            [ModelBinder(typeof (DevExpressEditorsBinder))] string id)
        {
            var response = "";
            if (!ModelState.IsValid)
            {
                return Json(ModelState.IsValid);
            }
            try
            {
                Debug.WriteLine(id);
                using (var player = new SoundPlayer($"https://fhir.blob.core.windows.net/attachments/{id}.wav"))
                {
                    player.PlaySync();
                }
                response = "Ta Da!";
            }

            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return Json(response);
        }
    }
}