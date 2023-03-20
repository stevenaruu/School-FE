using Bootcamp_CKres_Minor.Input;
using Bootcamp_CKres_Minor_FE.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_CKres_Minor_FE.Controllers
{
    public class ScoreController : Controller
    {

        private readonly IScore _scoreApi;

        public ScoreController(IScore scoreApi)
        {
            _scoreApi = scoreApi;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetGenderList()
        {
            var result = await _scoreApi.getGenderList();
            return Json(result);
        }
        public async Task<IActionResult> GetReligionList()
        {
            var result = await _scoreApi.getReligionList();
            return Json(result);
        }
        public async Task<IActionResult> GetStudentDetail(string id)
        {
            var result = await _scoreApi.getStudentDetail(id);
            return Json(result);
        }
        public async Task<IActionResult> CreateStudent([FromBody] StudentInput data)
        {
            var result = await _scoreApi.createStudent(data);
            return Json(result);
        }

    }
}
