using Models;
using InterfaceDAL;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TokenWebApi.TokenCreation
{
    public class CreateToken : ITokenCreation
    {
        private IDAL<User> _dAL;
        private IDAL<UserRole> _dAL1;
        private IDAL<Role> _dAL2;

        public CreateToken(IDAL<User> dAL, IDAL<UserRole> dAL1, IDAL<Role> dAL2)
        {
            this._dAL = dAL;
            this._dAL1 = dAL1;
            _dAL2 = dAL2;
        }

        string ITokenCreation.CreateToken(string email, string password)
        {
            //dummy security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABC@123456789Feb2024"));
            var algo = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var user = this._dAL.GetAll(). Where(u => u.EmailId == email && u.Password == password).FirstOrDefault();

            if ((user is null))
            {
                return string.Empty;
            }
            var role = this._dAL1.GetAll().Where(r => r.UserId == user.Id).First();
            var claims = new List<Claim> {  new Claim(JwtRegisteredClaimNames.UniqueName, user.EmailId) };

            claims.Add(new Claim("Role", this._dAL2.Get(role.RoleId).Name));
            

            var token = new JwtSecurityToken("FullCart", null, claims, DateTime.Now, DateTime.Now.AddMinutes(50), algo);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
