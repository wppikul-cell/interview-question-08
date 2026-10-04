using ExamSystem.Data;
using ExamSystem.DTOs;
using ExamSystem.Models;
using ExamSystem.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public QuestionsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/questions
    [HttpGet]
    public async Task<ActionResult<List<QuestionDto>>> GetQuestions()
    {
        var questions = await _context.Questions
            .Include(q => q.Choices)
            .OrderBy(q => q.Id)
            .Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,

                Choices = q.Choices
                    .Select(c => new QuestionChoiceDto
                    {
                        Id = c.Id,
                        ChoiceText = c.ChoiceText,
                        IsCorrect = c.IsCorrect
                    })
                    .ToList()
            })
            .ToListAsync();

        return Ok(questions);
    }


    // GET: api/questions/1
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
    {
        var question = await _context.Questions
            .Include(q => q.Choices)
            .Where(q => q.Id == id)
            .Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,

                Choices = q.Choices
                    .Select(c => new QuestionChoiceDto
                    {
                        Id = c.Id,
                        ChoiceText = c.ChoiceText,
                        IsCorrect = c.IsCorrect
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (question == null)
        {
            return NotFound();
        }

        return Ok(question);
    }


    // POST: api/questions
    [HttpPost]
    public async Task<ActionResult<QuestionDto>> CreateQuestion(
        CreateQuestionDto dto)
    {
        var question = new Question
        {
            QuestionText = dto.QuestionText,

            Choices = dto.Choices
                .Select(c => new QuestionChoice
                {
                    ChoiceText = c.ChoiceText,
                    IsCorrect = c.IsCorrect
                })
                .ToList()
        };

        _context.Questions.Add(question);

        await _context.SaveChangesAsync();

        var result = new QuestionDto
        {
            Id = question.Id,
            QuestionText = question.QuestionText,

            Choices = question.Choices
                .Select(c => new QuestionChoiceDto
                {
                    Id = c.Id,
                    ChoiceText = c.ChoiceText,
                    IsCorrect = c.IsCorrect
                })
                .ToList()
        };

        return CreatedAtAction(
            nameof(GetQuestion),
            new { id = question.Id },
            result
        );
    }


    // DELETE: api/questions/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        var question = await _context.Questions
            .FindAsync(id);

        if (question == null)
        {
            return NotFound();
        }

        _context.Questions.Remove(question);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}