using System;
using System.Collections.Generic;
using System.Linq;
using OnlineSurveys.Core.Interfaces;
using OnlineSurveys.Core.Models;

namespace OnlineSurvey.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepositoru)
        {
            _userRepository = userRepositoru;
        }

        public List<User> GetAll()
        {
            var allRoles = _userRepository.GetAll().ToList();
            return allRoles;
        }

        public void AddUser(User role)
        {
            _userRepository.Add(role);
        }

        public void Delete(Guid id)
        {
            var roleToDelete = _userRepository.GetById(id);
            _userRepository.Delete(roleToDelete);
        }

        public bool CheckIfUserExist(string email, string username)
        {
            return _userRepository.CheckIfExist(email, username);
        }

        public bool IfUserExistWithThisUserAndPass(string email, string password)
        {
            return _userRepository.IfExistUserWithTheseEmailAndPass(email, password);
        }

        public void SaveChanges()
        {
            _userRepository.Save();
        }
    }
}
