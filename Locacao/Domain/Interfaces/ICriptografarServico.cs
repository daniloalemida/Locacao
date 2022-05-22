namespace Locacao.Domain.Interfaces
{
    public interface ICriptografarServico
    {
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
                 
    }
}