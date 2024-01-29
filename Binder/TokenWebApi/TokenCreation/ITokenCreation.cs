namespace TokenWebApi.TokenCreation
{
    public interface ITokenCreation
    {
        string CreateToken(string email,string password);
    }
}
