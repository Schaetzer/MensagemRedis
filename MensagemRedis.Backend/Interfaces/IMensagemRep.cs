using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensagemRedis.Backend.Interfaces
{
    public interface IMensagemRep
    {
        public long Id { get; set; }
        public string Descricao { get; set; }

        public void GetMensagem(long id);
    }
}
