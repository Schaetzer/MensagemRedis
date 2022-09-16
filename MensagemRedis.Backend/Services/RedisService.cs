using Microsoft.Extensions.Caching.Distributed;
using MensagemRedis.Backend.Extensions;
using MensagemRedis.Backend.Interfaces;
using MensagemRedis.Backend.Models;
using MensagemRedis.Backend.Repository;
using MensagemRedis.API.Interfaces;

namespace MensagemRedis.API.Services
{
    public class RedisService : IRedisService
    {
        IDistributedCache _cache;

        public RedisService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public ResponseMensagem GetMensagens()
        {
            string recordId = "TesteRevis_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            string origem = null;
            var mensagens = _cache.GetRecordAsync<IEnumerable<MensagemRep>>(recordId).Result;


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

            ResponseMensagem result = new ResponseMensagem(origem, mensagens);

            return result;
        }

        public MensagemRep GetMensagensPorId(long id, long languageId)
        {
            string recordId = "TesteRevis_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            string origem = null;
            var mensagens = _cache.GetRecordAsync<IEnumerable<MensagemRep>>(recordId).Result;


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

            var result = mensagens.Single(sl => sl.Id.Equals(id));

            if (result is null)
            {
                return null;
            }

            return result;
        }

        private IEnumerable<MensagemRep> GetNovasMensagens()
        {
            return new[]
                {
                    new MensagemRep()
                    {
                        Id = 1,
                        Descricao = "Campo inválido."
                    },
                    new MensagemRep()
                    {
                        Id = 2,
                        Descricao = "Campo fora dos padrões."
                    }
                }.ToList();
        }
    }
}
