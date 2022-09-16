using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensagemRedis.Backend.Interfaces;

namespace MensagemRedis.Backend.Models
{
    public class ResponseMensagem
    {
        public string Origem { get; set; }
        public IEnumerable<IMensagemRep> data { get; set; }

        public ResponseMensagem(string origem, IEnumerable<IMensagemRep> redis)
        {
            Origem = origem;
            data = redis;
        }
    }
}
