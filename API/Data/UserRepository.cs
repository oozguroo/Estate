using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
              return await _context.Users
               .Where(x => x.UserName == username)
             .Include(x => x.Houses)
             .ThenInclude(x => x.Photos)
             .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
             .SingleOrDefaultAsync();
        }


        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

       public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
            .SingleOrDefaultAsync(x => x.UserName == username);
        }
        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}