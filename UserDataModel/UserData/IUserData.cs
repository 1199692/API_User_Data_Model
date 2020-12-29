using System.Collections.Generic;
using RoleDataModel.Models;
using UnitDataModel.Models;
using URoleDataModel.Models;
using UserDataModel.Models;

//User Interface
namespace UserDataModel.UserData
{
    public interface IUserData //Interface Constructor for User
    {
        List<User> GetUsers();

        User GetUser(int Id);

        User AddUser(User user);

        void DeleteUser(User user);

        User EditUser(User user);
    }
}

//Unit Interface
namespace UnitDataModel.UnitData
{
    public interface IUnitData //Interface Constructor for Unit
    {
        List<Unit> GetUnits();

        Unit GetUnit(int Id);

        Unit AddUnit(Unit unit);

        void DeleteUnit(Unit unit);

        Unit EditUnit(Unit unit);
    }
}

//Role Interface
namespace RoleDataModel.RoleData
{
    public interface IRoleData //Interface Constructor for Role
    {
        List<Role> GetRoles();

        Role GetRole(int Id);

        Role AddRole(Role role);

        void DeleteRole(Role role);

        Role EditRole(Role role);
    }
}

//URole (User Role )Interface
namespace URoleDataModel.URoleData
{
    public interface IURoleData //Interface Constructor for URole
    {
        List<URole> GetURoles();

        URole GetURole(int Id);

        URole AddURole(URole uRole);

        void DeleteURole(URole uRole);

        URole EditURole(URole uRole);
    }
}