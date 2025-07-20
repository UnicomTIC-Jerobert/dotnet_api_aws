using System.Collections.Generic;
using System.Threading.Tasks;
using ICEDT.API.Models;

namespace ICEDT.API.Repositories.Interfaces
{
    public interface ILessonRepository
    {
        Task<Level> GetByIdWithLessonsAsync(int id);
        Task<List<Level>> GetAllWithLessonsAsync();
        Task<bool> SequenceOrderExistsAsync(int sequenceOrder);

        Task<Lesson?> GetByIdAsync(int lessonId); // Returns the full model
        Task<Lesson> CreateAsync(Lesson lesson);
        Task<bool> UpdateAsync(Lesson lesson);
        Task<bool> DeleteAsync(int lessonId);
    }
}