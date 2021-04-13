using System;
using System.Collections.Generic;
using System.Linq;
using Bill.Management.Abstractions;
using Bill.Management.Abstractions.Data.Users;
using Bill.Management.Implementations.Data.Users.Repositories.Contexts;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Implementations.Data.Users.Repositories
{
    internal sealed class UseEfRepository : IUserRepository
    {
        private readonly BillDbContext _context;

        public UseEfRepository()
        {
            _context = new BillDbContext();
        }

        public IReadOnlyList<User> Read()
        {
            return _context.Users.Where(x=> x.IsDeleted == false).ToList();
        }

        public void Create(User data)
        {
            _context.Users.Add(data);
            
            Commit();
        }

        public void Update(User data)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == data.Id);

            if (user is null)
            {
                return;
            }

            user.Text = data.Text;
            user.IsDeleted = data.IsDeleted;

            Commit();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefault();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
