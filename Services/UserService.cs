using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Communication;
using SahafAPI.Domain.Services.Interfaces;

namespace SahafAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<User>> ListAsync()
        {
            return await userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.ComplateAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await userRepository.FindByIdAsync(id);

            if(existingUser == null)
                return new UserResponse($"The user with id {id} does not exist");
            
            existingUser.name = user.name;
            existingUser.bookId = user.bookId;
            existingUser.bookBorrowDate = user.bookBorrowDate;
            existingUser.bookReturnDate = user.bookReturnDate;
            
            try
            {
                userRepository.Update(existingUser);
                await unitOfWork.ComplateAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }
    }
}