using Microsoft.Extensions.Caching.Distributed;
using MensagemRedis.Backend.Extensions;
using MensagemRedis.Backend.Models;
using MensagemRedis.Backend.Interfaces;
using MensagemRedis.Backend.Repository;

namespace MensagemRedis.Backend.Services
{
    public class RedisService : IRedisService
    {
        IDistributedCache _cache;
        IMensagemRep _mensagemRep = new MensagemRep();

        public RedisService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public ResponseMensagem GetMensagens()
        {
            string recordId = "TesteRevis_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            string origem = null;
            var mensagens = _cache.GetRecordAsync<List<Mensagem>>(recordId).Result;


            if (mensagens is null)
            {
                mensagens = GetNovasMensagens();
                origem = $"Dados retirados do banco de dados em {DateTime.Now}";

                _cache.SetRecordsAsync(recordId, mensagens);
            }
            else
            {
                origem = $"Dados retirados do cache em {DateTime.Now}";
            }

            ResponseMensagem result = new ResponseMensagem()
            {
                Origem = origem,
                Data = mensagens
            };

            return result;
        }

        public Mensagem GetMensagensPorId(long id, long languageId)
        {
            string recordId = "TesteRevis_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            string origem = null;
            var mensagens = _cache.GetRecordAsync<List<Mensagem>>(recordId).Result;


            if (mensagens is null)
            {
                mensagens = GetNovasMensagens();
                origem = $"Dados retirados do banco de dados em {DateTime.Now}";

                _cache.SetRecordsAsync(recordId, mensagens);
            }
            else
            {
                origem = $"Dados retirados do cache em {DateTime.Now}";
            }

            var result = mensagens.Find(sl => sl.Id == id);

            if (result is null)
            {
                return null;
            }

            return result;
        }

        private List<Mensagem> GetNovasMensagens()
        {
            return _mensagemRep.GetMensagem();
        }
    }
}
