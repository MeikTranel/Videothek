using System;
using AutoMapper;
using Videothek.Persistence;
using Videothek.Persistence.Entities;

namespace Videothek.Core
{
    public class UserService
    {
        private readonly Repository<UserEntity> _userRepository;

        public UserService(Repository<UserEntity> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public bool TryGetUser(string userName, out User user)
        {
            var userEntity = _userRepository.Get(u => u.Name == userName);
            if (userEntity == null)
            {
                user = null;
                return false;
            }
            else
            {
                user = Mapper.Map<User>(userEntity);
                return true;
            }
        }

        public void Debit(int userID,float amount)
        {
            UserEntity updatedUser = _userRepository.Get(userID);
            var currentBalance = updatedUser.Balance;
            updatedUser.Balance = currentBalance - amount;

            if (updatedUser.Balance < 0)
                throw new InvalidOperationException("Cannot invoice beyond the users balance.");

            _userRepository.Update(updatedUser);
        }
    }
}
