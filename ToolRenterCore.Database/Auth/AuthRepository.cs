using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToolRenterCore.Database.Contexts;
using ToolRenterCore.Database.DataContract.Auth.Interfaces;
using ToolRenterCore.Database.DataContract.Auth.RAOs;
using ToolRenterCore.Database.Entities.People;

namespace ToolRenterCore.Database.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly ToolRenterContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;


        public AuthRepository(IMapper mapper, ToolRenterContext context,
                UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ReceivedExistingUserRAO> Login(QueryForExistingUserRAO queryRao)
        {
            var user = await _userManager.FindByNameAsync(queryRao.UserName);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, queryRao.Password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                  .FirstOrDefaultAsync(u => u.NormalizedUserName == queryRao.UserName.ToUpper());

                return _mapper.Map<ReceivedExistingUserRAO>(appUser);
            }

            throw new NotImplementedException();
        }

        public async Task<ReceivedExistingUserRAO> Register(RegisterUserRAO regUserRAO, string password)
        {
            var user = _mapper.Map<UserEntity>(regUserRAO);

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var rao = _mapper.Map<ReceivedExistingUserRAO>(user);
                return rao;
            }
            throw new NotImplementedException("User already exists");
        }

        public async Task<bool> UserExists(string username)
        {
            var query = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ReceivedExistingUserRAO> GetUserById(int ownerId)
        {
            var query = await _context.UserTableAccess.FirstOrDefaultAsync(u => u.Id == ownerId);

            var user = _mapper.Map<ReceivedExistingUserRAO>(query);

            return user;
        }
    }
}
