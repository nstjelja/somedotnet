using Apsis.TenPinBowling.Simulator.Domain.Entity;
using Apsis.TenPinBowling.Simulator.Domain.Service;
using Apsis.TenPinBowling.Simulator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apsis.TenPinBowling.Simulator.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculateScore(ScoreCard scoreCard) 
        {
           

            if (scoreCard == null)
            {
                return Json(new ScoringResponseDTO()
                {
                    IsError = true,
                    Messages = new List<string>() { 
                        "Invalid request"
                    }
                });
            }

            if (!ModelState.IsValid) {
                var messages = new List<string>();

                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        messages.Add(error.ErrorMessage);
                    }
                }

                return Json(new ScoringResponseDTO()
                {
                    IsError = true,
                    Messages = messages
                });
            }

            var scoreService = new ScoringService();
            scoreService.Score(scoreCard);


            return Json(new ScoringResponseDTO()
            {
                IsError = false,
                Messages = new List<string>() { 
                        "Score calculated succesfully"
                    },
                Score = scoreCard.Score
            });
        }

    }
}
