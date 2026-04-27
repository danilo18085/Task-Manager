using DTO;
using Models;

namespace Services
{
    public interface ITaskService
    {
        public Task<bool> CreateTask(DTOCreateTask task);
        public Task<bool> UpdateTask(DTOUpdateTask task);
        public Task<bool> DeleteTask(int TaskID);
        public Task<bool> AddComment(Comment comm);
        public Task<List<Comment>> ListComments(int id_taska);
    }
}
