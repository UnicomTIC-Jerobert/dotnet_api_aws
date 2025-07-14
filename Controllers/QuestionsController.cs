using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleTodoApi.Data;
using SimpleTodoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly TodoContext _context;

        public QuestionsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        // Gets all questions and includes their related options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            // .Include(q => q.Options) is crucial to load the options with the questions
            return await _context.Questions.Include(q => q.Options).ToListAsync();
        }

        // GET: api/Questions/5
        // Gets a single question by ID and includes its options
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions
                                         .Include(q => q.Options)
                                         .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // POST: api/Questions
        // Creates a new question along with its options
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            // EF Core is smart enough to see the nested Options and will
            // create them and link them to the new question automatically.
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, question);
        }

        // PUT: api/Questions/5
        // Updates a question's text. (A more complex update would handle option changes)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            var dbQuestion = await _context.Questions.FindAsync(id);
            if (dbQuestion == null)
            {
                return NotFound();
            }

            // Only update the question text for simplicity
            dbQuestion.Text = question.Text;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Questions/5
        // Deletes a question and its associated options (due to database cascading)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}