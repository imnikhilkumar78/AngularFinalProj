using Angular_Final_Proj.Models;

namespace Angular_Final_Proj.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
    }
}
