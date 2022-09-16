using MensagemRedis.Backend.Interfaces;
using MensagemRedis.Backend.Models;
using MensagemRedis.Backend.Repository;

namespace MensagemRedis.API.Interfaces
{
    public interface IRedisService
    {
        ResponseMensagem GetMensagens();
        MensagemRep GetMensagensPorId(long id, long languageId);
    }
}
