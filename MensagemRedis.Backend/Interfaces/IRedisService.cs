using MensagemRedis.Backend.Models;

namespace MensagemRedis.Backend.Interfaces
{
    public interface IRedisService
    {
        ResponseMensagem GetMensagens();
        Mensagem GetMensagensPorId(long id, long languageId);
    }
}
