using AutoMapper;
using lastoneapi.Data;
using lastoneapi.School.controllers;
using lastoneapi.School.Controllers.DTOS;
using lastoneapi.studu;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lastoneapi.School.Repositories
{
    public class RepositoryImplementation : IRepositoryPattern
    {
        private readonly DataBase _context;

        public RepositoryImplementation(DataBase context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int Id)
        {
            return await _context.students.FindAsync(Id);
        }

        public async Task<Student> CreateAsync(Student Student)
        {
            _context.students.Add(Student);
            await _context.SaveChangesAsync();
            return Student;
        }

        public async Task<Student> UpdateAsync(int Id, Student Student)
        {
            var upo = await _context.students.FindAsync(Id);
            if (upo == null) return null;

            upo.Name = Student.Name;
            upo.Age = Student.Age;
            upo.Semester = Student.Semester;

            await _context.SaveChangesAsync();
            return upo;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var delo = await _context.students.FindAsync(Id);
            if (delo == null) return false;

            _context.students.Remove(delo);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task CreateAsync(ResponceStudentDto requestStudent)
        {
            throw new NotImplementedException();
        }
    }
}