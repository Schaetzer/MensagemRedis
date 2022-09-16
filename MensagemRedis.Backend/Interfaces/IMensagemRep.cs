using MensagemRedis.Backend.Models;

namespace MensagemRedis.Backend.Interfaces
{
    public interface IMensagemRep
    {
        public List<Mensagem> GetMensagem();
    }
}
