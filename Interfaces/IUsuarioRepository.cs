using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        Usuarios BuscarPorId(Guid id);

        Usuarios BuscarPorEmailESenha(string email, string senha);
    }
}
