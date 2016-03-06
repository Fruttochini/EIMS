
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.AuthorizationIdentity
{
    //class UserStore : IUserPasswordStore<IdentityUser, long>
    //{
    //    private IIdentityUnit identity;

    //    public UserStore(IIdentityUnit repo)
    //    {
    //        identity = repo;
    //    }

    //    public Task CreateAsync(IdentityUser user)
    //    {

    //        identity.CreateUser(user);
    //        return Task.FromResult<object>(null);
    //    }

    //    public Task DeleteAsync(IdentityUser user)
    //    {
    //        identity.DeleteUser(user);
    //        return Task.FromResult<object>(null);

    //    }

    //    public void Dispose()
    //    {

    //    }

    //    public Task<IdentityUser> FindByIdAsync(long userId)
    //    {
    //        var usr = identity.FindUserByID(userId);
    //        return Task.FromResult<IdentityUser>(usr);
    //    }

    //    public Task<IdentityUser> FindByNameAsync(string userName)
    //    {
    //        var usr = identity.FindUserByName(userName);
    //        return Task.FromResult<IdentityUser>(usr);
    //    }

    //    public Task<string> GetPasswordHashAsync(IdentityUser user)
    //    {
    //        var usr = identity.FindUserByID(user.Id);
    //        return Task.FromResult<string>(usr.Password);
    //    }

    //    public Task<bool> HasPasswordAsync(IdentityUser user)
    //    {
    //        var usr = identity.FindUserByID(user.Id);
    //        if (!String.IsNullOrEmpty(usr.Password))
    //            return Task.FromResult(true);
    //        else
    //            return Task.FromResult(false);
    //    }

    //    public Task SetPasswordHashAsync(IdentityUser user, string passwordHash)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task UpdateAsync(IdentityUser user)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
