using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineSurveys.Core.Interfaces;
using OnlineSurveys.Core.Models;

namespace OnlineSurveys.Services
{
    public class RoleService
    {
        private IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetAll()
        {
            var allRoles = _roleRepository.GetAll().ToList();
            return allRoles;
        }

        public void AddRole(Role role)
        {
            _roleRepository.Add(role);
        }

        public void SaveChanges()
        {
            _roleRepository.Save();
        }
    }
}
