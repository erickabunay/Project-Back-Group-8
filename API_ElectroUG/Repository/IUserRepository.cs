using API_ElectroUG.Context;
using API_ElectroUG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ElectroUG.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<List<User>> GetByNameAsync(string name);

        Task<List<User>> GetByLastNameAsync(string lastName);

        Task<User> GetByEmailAndPassword(string email, string password);

        Task<List<User>> GetAllUserByRoleManagerAsync(); 

        Task<List<User>> GetAllUserByRoleClientAsync(); 

        Task<User> CreateAsync(User user);

        Task<User> UpdateAsync(User user);

        Task<User> DisableByIdAsync(int id);

        Task<bool> SaveChanges();

    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) 
        {
            _context = context;
        }

        #region Methods Get

        public async Task<List<User>> GetAllAsync()
        {
            List<User> users = await _context.User
                                            .Where(x => x.IsDisable != true)
                                            .ToListAsync();
            return users;

        }

        public async Task<User> GetByIdAsync(int id)
        {
            User user = await _context.User
                                      .Where(x => x.IsDisable != true)
                                      .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<List<User>> GetByLastNameAsync(string lastName)
        {
            List<User> user = await _context.User
                                            .Where(x => x.LastName == lastName && x.IsDisable != true)
                                            .ToListAsync();
            return user;
        }

        public async Task<List<User>> GetByNameAsync(string name)
        {
            List<User> user = await _context.User
                                            .Where(x => x.Name == name && x.IsDisable != true)
                                            .ToListAsync();
            return user;
        }

        public async Task<List<User>> GetAllUserByRoleManagerAsync()
        {
            List<User> user = await _context.User
                                            .Where(x => x.Role == "Gerente" && x.IsDisable != true)
                                            .ToListAsync();
            return user;
        }

        public async Task<List<User>> GetAllUserByRoleClientAsync()
        {
            List<User> user = await _context.User
                                            .Where(x => x.Role == "Cliente" && x.IsDisable != true)
                                            .ToListAsync();
            return user;
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            User user = await _context.User
                                      .Where(x => x.IsDisable != true)
                                      .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;

        }
        #endregion

        #region Method Create
        public async Task<User> CreateAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        #endregion

        public async Task<User> UpdateAsync(User user)
        {
            var existsUser = await _context.User.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (existsUser != null) 
            { 
                _context.Entry(existsUser).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
                return existsUser;
            }else
            {
                throw new InvalidOperationException("El usuario con el Id " +user.Id + "no existe.");
            }

        }

        public async Task<User> DisableByIdAsync(int id)
        {
            var existsUser = await _context.User.FindAsync(id);

            if (existsUser != null)
            {
                _context.Entry(existsUser).CurrentValues.SetValues(existsUser.IsDisable = true);
                await _context.SaveChangesAsync();
                return existsUser;

            }
            else
            {
                throw new InvalidOperationException("El usuario con el Id " + id + "no existe.");
            }

        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
