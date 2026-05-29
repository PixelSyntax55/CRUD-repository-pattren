using lastoneapi.studu;

namespace lastoneapi.School.Repositories
{
    public interface IRepositoryPattern
    {
        Task<IEnumerable<Student>> GetAllAsync();
         Task<Student?> GetByIdAsync(int Id);
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(int Id, Student student);
        Task<bool> DeleteAsync(int Id);

    }
}
