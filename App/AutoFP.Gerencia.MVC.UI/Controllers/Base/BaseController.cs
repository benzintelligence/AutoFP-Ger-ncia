using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;

namespace AutoFP.Gerencia.MVC.UI.Controllers.Base
{
    // [Authorize]
    public class BaseController : Controller
    {
        protected JsonResult JsonResponse(object obj, IEnumerable<string> messages, int statusCode)
        {
            return Json(new { statuscode = statusCode, messages = messages, data = obj }, JsonRequestBehavior.AllowGet);
        }

        protected void AddErrors(ValidationAppResult validationApp)
        {
            foreach (var error in validationApp.Errors)
                ModelState.AddModelError("", error);
        }

        protected void AddErrors(ValidationResult validationApp)
        {
            foreach (var error in validationApp.Errors)
                ModelState.AddModelError("", error);
        }

        protected string AddErrorsDelete(ValidationAppResult validationApp)
        {
            var errors = string.Empty;

            foreach (var error in validationApp.Errors)
                errors += error + Environment.NewLine;

            return errors;
        }
    }
}