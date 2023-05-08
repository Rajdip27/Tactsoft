using Dapper_Store_Sqlprocedure.DbContext;
using Dapper_Store_Sqlprocedure.Models;
using Microsoft.AspNetCore.Connections;

namespace Dapper_Store_Sqlprocedure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Student student)
        {
            int rowAffected= await _dbContext.ExecuteAsync("AddStudent", new {name = student.Name,address=student.Address},commandType:System.Data.CommandType.StoredProcedure);
            if(rowAffected > 0)
            {
                return true;
            }return false;
        }

        public async Task<bool> Delete(int id)
        {
            int rowAffected= await _dbContext.ExecuteAsync("DeleteStudent", new {id=id},commandType:System.Data.CommandType.StoredProcedure);
            if(rowAffected > 0)
            {
                return true;
            }return false;
        }

        public async Task<List<Student>> GetAll()
        {
            var students = await _dbContext.QueryAsync<Student>("GetAll", commandType: System.Data.CommandType.StoredProcedure);
            return students.ToList();
        }

        public async Task<Student> GetById(int id)
        {
           var student =await _dbContext.QuerySingleOrDefaultAsync<Student>("GetById", new {id=id},commandType:System.Data.CommandType.StoredProcedure);    
            return student;
        }

        public async Task<bool> Update(Student student)
        {
            int rowAffected = await _dbContext.ExecuteAsync("UpdateStudent", student, commandType: System.Data.CommandType.StoredProcedure);
            if( rowAffected > 0)
            {
                return true;
            }return false;
        }
    }
}
