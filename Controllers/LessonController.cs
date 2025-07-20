

using ICEDT.API.DTO.Request;
using ICEDT.API.Models;
using ICEDT.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICEDT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service) => _service = service;

        [HttpPost("lessons/level/{levelId:int}")]
        public async Task<IActionResult> AddLesson(int levelId, [FromBody] LessonRequestDto dto)
        {
            if (levelId <= 0)
                return BadRequest(new { message = "Invalid Level ID." });
            var lesson = await _service.AddLessonToLevelAsync(levelId, dto);
            return CreatedAtAction(nameof(GetLevelWithLessons), new { levelId }, lesson);
        }

        [HttpDelete("lessons/{lessonId:int}/level/{levelId:int}")]
        public async Task<IActionResult> RemoveLesson(int levelId, int lessonId)
        {
            if (levelId <= 0 || lessonId <= 0)
                return BadRequest(new { message = "Invalid  ID." });
            await _service.RemoveLessonFromLevelAsync(levelId, lessonId);
            return NoContent();
        }

        [HttpGet("/lessons/{levelId:int}")]
        public async Task<IActionResult> GetLevelWithLessons(int levelId)
        {
            if (levelId <= 0)
                return BadRequest(new { message = "Invalid Level ID." });
            var result = await _service.GetLevelWithLessonsAsync(levelId);
            return Ok(result);
        }
    }
}