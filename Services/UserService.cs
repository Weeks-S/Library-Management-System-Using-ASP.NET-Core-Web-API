using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Services;

public class UserService(IUserRepository repo)
{
    private readonly IUserRepository _repo = repo;

    public Task<List<User>> GetAllAsync() => _repo.GetAllAsync();

    public Task<User?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<User> CreateAsync(User user) => _repo.CreateAsync(user);
}
