
using ICEDT.API.DTO.Request;
using ICEDT.API.DTO.Response;

namespace ICEDT.API.Services.Interfaces
{
    public interface ILessonService
    {
        Task<LessonResponseDto> AddLessonToLevelAsync(int levelId, LessonRequestDto dto);
        Task RemoveLessonFromLevelAsync(int levelId, int lessonId);
        Task<LevelWithLessonsResponseDto> GetLevelWithLessonsAsync(int levelId);

        Task<LessonRequestDto?> GetLessonByIdAsync(int lessonId);
        Task<bool> UpdateLessonAsync(int lessonId, LessonRequestDto updateDto); // Create UpdateLessonDto
        Task<bool> DeleteLessonAsync(int lessonId);
    }
}