using Microsoft.AspNetCore.Mvc;
using SstProgrammingandDesignProject.Models;


namespace SstProgrammingandDesignProject.Controllers
{
    public class DiceController : Controller
    {
        private readonly ILogger<DiceController> _logger;

        public DiceController(ILogger<DiceController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View(new DiceModel());
        }

        [HttpPost]
        public ActionResult Roll(DiceModel model)
        {
            var resultsModel = new DiceRollResults();
            if (ModelState.IsValid)
            {
                resultsModel.Rolls = RollDice(model);
            }
            ViewBag.Results = resultsModel;
            return View("Index", model);

        }


        private List<int[]> RollDice(DiceModel model)
        {
            var results = new List<int[]>();
            var random = new Random();
            for (int i = 0; i < model.NumberOfRolls; i++)
            {
                results.Add(
                [
                    RollDie(model.FavoredFaceDie1, model.FactorDie1, random),
                    RollDie(model.FavoredFaceDie2, model.FactorDie2, random)
                ]);
            }
            return results;
        }

        private static int RollDie(int favoredFace, int factor, Random random)
        {
            int[] faces = new int[6 + factor - 1];
            for (int i = 0; i < faces.Length; i++)
            {
                faces[i] = i % 6 + 1;
            }
            for (int i = 0; i < factor - 1; i++)
            {
                faces[6 + i] = favoredFace;
            }
            return faces[random.Next(faces.Length)];
        }
    }

}
