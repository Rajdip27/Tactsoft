using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbTest.Models;

namespace MongoDbTest.Services;

public class StudentRepository : IStudentRepository
{
    private readonly IMongoCollection<Student> _collection;
    private readonly DbConfiguration _settings;

    public StudentRepository(IOptions<DbConfiguration> settings)
    {
       _settings = settings.Value;
        var client= new MongoClient(_settings.ConnectionString);
        var database = client.GetDatabase(_settings.DatabaseName);
        _collection = database.GetCollection<Student>(_settings.CollectionName);

    }
    public async Task DeleteAsync(string id)=>await _collection.DeleteOneAsync(c => c.Id == id);
    public async Task<List<Student>> GetAllAsync()=>await _collection.Find(c => true).ToListAsync();
    public async Task<Student> GetByIdAsync(string id)=>await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    public Task UpdateAsync(string id, Student student) => _collection.ReplaceOneAsync(c => c.Id == id, student);
    public async Task<Student> CreateAsync(Student student)
    {
        await _collection.InsertOneAsync(student).ConfigureAwait(false);
        return student;
    }
}
