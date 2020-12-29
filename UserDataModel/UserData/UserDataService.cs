using System.Collections.Generic;
using System;
using UserDataModel.Models;
using System.Linq;
using UnitDataModel.Models;
using RoleDataModel.Models;
using URoleDataModel.Models;

//------------------------------------------------------------------------------
//    ---------------Data Service for "users" Table-------------------------
//------------------------------------------------------------------------------
namespace UserDataModel.UserData
{
    public class UserDataService : IUserData //Inhereting interface IUserData class
    {       
        private UserContext _userContext;
        public UserDataService(UserContext userContext)
        {
            _userContext = userContext;
        }

        //Constructor for Adding a User
        public User AddUser(User user)
        {

            var uc = _userContext.users.Add(user);
            _userContext.SaveChanges(); //saving added User to table
            return user;
        }

        //Constructor for Deleting a User
        public void DeleteUser(User user)
        {
            var delUser = GetUser(user.Id);
            if (delUser == null)
                throw new InvalidOperationException("User is not present");
            else
            {
                _userContext.Remove(delUser);
                _userContext.SaveChanges(); //deletion of user and saving changes to Table
            }

        }

        //Construcor for Updating or modifying existing user
        public User EditUser(User user)
        {
            var existingUser = GetUser(user.Id);
            if (existingUser == null)
            {
                throw new InvalidOperationException("User is not present");
            }
            else
            {
                existingUser.Version = user.Version;
                existingUser.Name = user.Name;
                _userContext.users.Update(existingUser);
                _userContext.SaveChanges(); //Saving changes to table after update
                return user;
            }

        }

        //Constructor to get the list of User to use in other HTTP Methods
        public List<User> GetUser()
        {
            throw new System.NotImplementedException();
        }

        //Constructor to get selected User based on given Id
        public User GetUser(int Id)
        {
            return _userContext.users.Where(x => x.Id == Id).SingleOrDefault();
        }

        //Constructor to fetch all list of Users
        public List<User> GetUsers()
        {
            var result = _userContext.users.AsQueryable(); //Fetching all Users from Table
            return result.ToList();
        }
    }
}

//------------------------------------------------------------------------------
//     ---------------Data Service for "units" Table-------------------------
//------------------------------------------------------------------------------

namespace UnitDataModel.UnitData 
{
    public class UnitDataService : IUnitData //Inhereting interface IUnitData class
    {
        private UserContext _unitContext;
        public UnitDataService(UserContext unitContext)
        {
            _unitContext = unitContext;
        }

        //Constructor for Adding a Unit
        public Unit AddUnit(Unit unit)
        {

            var uc = _unitContext.units.Add(unit);
            _unitContext.SaveChanges(); //saving added Unit to table
            return unit;
        }

        //Constructor for Deleting a Unit
        public void DeleteUnit(Unit unit)
        {
            var delUnit = GetUnit(unit.Id);
            if (delUnit == null)
                throw new InvalidOperationException("Unit is not present");
            else
            {
                _unitContext.Remove(delUnit);
                _unitContext.SaveChanges(); //deletion of Unit and saving changes to table
            }
        }

        //Constructor for Updating an existing Unit
        public Unit EditUnit(Unit unit)
        {
            var existingUnit = GetUnit(unit.Id);
            if (existingUnit == null)
            {
                throw new InvalidOperationException("Unit is not present");
            }
            else
            {
                existingUnit.Version = unit.Version;
                existingUnit.Name = unit.Name;
                _unitContext.units.Update(existingUnit);
                _unitContext.SaveChanges(); ///Saving changes to table after Update
                return unit;
            }

        }

        //Constructor to get the list of Units to use in other HTTP Methods
        public List<Unit> GetUnit()
        {
            throw new System.NotImplementedException();
        }

        //Construcor to get selected Unit based on given Id
        public Unit GetUnit(int Id)
        {
            return _unitContext.units.Where(x => x.Id == Id).SingleOrDefault();
        }

        //Constructor to all list of Unit
        public List<Unit> GetUnits()
        {
            var result = _unitContext.units.AsQueryable(); ////Fetching all Units from Table
            return result.ToList();
        }
    }
}

//------------------------------------------------------------------------------
//     ---------------Data Service for “Role” Table-------------------------
//------------------------------------------------------------------------------

namespace RoleDataModel.RoleData
{
    public class RoleDataService : IRoleData //Inhereting interface IRoleData class
    {
        private UserContext _roleContext;
        public RoleDataService(UserContext roleContext)
        {
            _roleContext = roleContext;
        }

        //Constructor for Adding a Role
        public Role AddRole(Role role)
        {

            var uc = _roleContext.roles.Add(role);
            _roleContext.SaveChanges(); //saving added Role to table
            return role;
        }

        //Constructor for Deleting a Role
        public void DeleteRole(Role role)
        {
            var delRole = GetRole(role.Id);
            if (delRole == null)
                throw new InvalidOperationException("User is not present");
            else
            {
                _roleContext.Remove(delRole);
                _roleContext.SaveChanges(); //deletion of Role and saving changes to table
            }
        }

        //Constructor for Updating an existing Role
        public Role EditRole(Role role)
        {
            var existingRole = GetRole(role.Id);
            if (existingRole == null)
            {
                throw new InvalidOperationException("Role is not present");
            }
            else
            {
                existingRole.Version = role.Version;
                existingRole.Name = role.Name;
                _roleContext.roles.Update(existingRole);
                _roleContext.SaveChanges(); ///Saving changes to table after Update
                return role;
            }

        }

        //Constructor to get the list of Roles to use in other HTTP Methods
        public List<Role> GetRole()
        {
            throw new System.NotImplementedException();
        }

        //Constructor to get selected Role based on given Id
        public Role GetRole(int Id)
        {
            return _roleContext.roles.Where(x => x.Id == Id).SingleOrDefault();
        }

        //Constructor to all list of Role
        public List<Role> GetRoles()
        {
            var result = _roleContext.roles.AsQueryable(); ////Fetching all Roles from Table
            return result.ToList();
        }
    }
}

//------------------------------------------------------------------------------
//     ---------------Data Service for User Role “URole” Table-------------
//------------------------------------------------------------------------------

namespace URoleDataModel.URoleData
{
    public class URoleDataService : IURoleData //Inheriting interface IURoleData class
    {
        private UserContext _uroleContext;
        public URoleDataService(UserContext uroleContext)
        {
            _uroleContext = uroleContext;
        }

        //Constructor for Adding a URole
        public URole AddURole(URole urole)
        {
            urole.ValidFrom = DateTime.Now;
            _uroleContext.uRoles.Add(urole);
            _uroleContext.SaveChanges(); //saving added URole to table
            return urole;
        }

        //Constructor for Deleting a URole
        public void DeleteURole(URole urole)
        {
            var delURole = GetURole(urole.Id);
            if (delURole == null)
            {
                throw new InvalidOperationException("Invalid Role Id");
            }
            else
             {
                _uroleContext.Remove(delURole);
                _uroleContext.SaveChanges(); //deletion of URole and saving changes to table
            }
        }

        //Constructor for Updating an existing URole
        public URole EditURole(URole urole)
        {
            var existingURole = GetURole(urole.Id);
            if (existingURole == null)
            {
                throw new InvalidOperationException("Invalid input");
            }
            
            else
            {
                existingURole.ValidFrom = urole.ValidFrom;
                existingURole.ValidTo = urole.ValidTo;
                _uroleContext.uRoles.Update(existingURole);
                _uroleContext.SaveChanges(); ///Saving changes to table after Update
                return urole;
            }
        }

        //Constructor to get the list of URoles to use in other HTTP Methods
        public List<URole> GetURole()
        {
            throw new System.NotImplementedException();
        }

        //Constructor to get selected URole based on given Id
        public URole GetURole(int Id)
        {
            //return users.SingleOrDefault(x => x.Id == Id);
            return _uroleContext.uRoles.Where(x => x.Id == Id).SingleOrDefault();
        }

        //Constructor to all list of URole
        public List<URole> GetURoles()
        {
            var result = _uroleContext.uRoles.AsQueryable(); ////Fetching all URoles from Table
            return result.ToList();
        }
    }
}