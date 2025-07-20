using ICEDT.API.Models;
using ICEDT.API.Middleware;
using ICEDT.API.Repositories.Interfaces;
using ICEDT.API.Services.Interfaces;
using ICEDT.API.DTO.Request;
using ICEDT.API.DTO.Response;

namespace ICEDT.API.Services.Implementation
{
    public class LessonService : ILessonService
    {
        private readonly ILevelRepository _repo;

        public LessonService(ILevelRepository repo) => _repo = repo;


        public async Task<LessonResponseDto> AddLessonToLevelAsync(int levelId, LessonRequestDto dto)
        {

            var level = await _repo.GetByIdWithLessonsAsync(levelId);
            if (level == null) throw new NotFoundException("Level not found.");

            if (level.Lessons?.Any(l => l.LessonName == dto.LessonName) == true)
                throw new ConflictException("A lesson with the same name already exists in this level.");
            if (level.Lessons?.Any(l => l.SequenceOrder == dto.SequenceOrder) == true)
                throw new ConflictException("A lesson with the same SequenceOrder already exists.");

            var lesson = new Lesson
            {
                LevelId = levelId,
                LessonName = dto.LessonName,
                Description = dto.Description,
                SequenceOrder = dto.SequenceOrder
            };

            level.Lessons ??= new List<Lesson>();
            level.Lessons.Add(lesson);
            await _repo.UpdateAsync(level);

            return new LessonResponseDto
            {
                LessonId = lesson.LessonId,
                LevelId = lesson.LevelId,
                LessonName = lesson.LessonName,
                Description = lesson.Description,
                SequenceOrder = lesson.SequenceOrder
            };
        }


        public async Task RemoveLessonFromLevelAsync(int levelId, int lessonId)
        {

            var level = await _repo.GetByIdWithLessonsAsync(levelId);
            if (level == null) throw new NotFoundException("Level not found.");
            var lesson = level.Lessons?.FirstOrDefault(l => l.LessonId == lessonId);
            if (lesson == null) throw new NotFoundException("Lesson not found in this level.");
            level.Lessons.Remove(lesson);
            await _repo.UpdateAsync(level);
        }

        public async Task<LevelWithLessonsResponseDto> GetLevelWithLessonsAsync(int levelId)
        {

            var level = await _repo.GetByIdWithLessonsAsync(levelId);
            if (level == null) throw new NotFoundException("Level not found.");
            return new LevelWithLessonsResponseDto
            {
                LevelId = level.LevelId,
                LevelName = level.LevelName,
                SequenceOrder = level.SequenceOrder,
                Lessons = level.Lessons?.Select(l => new LessonResponseDto
                {
                    LessonId = l.LessonId,
                    LevelId = l.LevelId,
                    LessonName = l.LessonName,
                    Description = l.Description,
                    SequenceOrder = l.SequenceOrder
                }).ToList() ?? new List<LessonResponseDto>()
            };
        }

        private LevelResponseDto MapToResponseDto(Level level)
        {
            return new LevelResponseDto
            {
                LevelId = level.LevelId,
                LevelName = level.LevelName,
                SequenceOrder = level.SequenceOrder
            };
        }
    }
}