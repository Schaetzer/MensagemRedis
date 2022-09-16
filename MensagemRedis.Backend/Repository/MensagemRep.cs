using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensagemRedis.Backend.Interfaces;

namespace MensagemRedis.Backend.Repository
{
    public class MensagemRep : IMensagemRep
    {
        public long Id { get ; set ; }
        public string Descricao { get ; set ; }

        public void GetMensagem(long id)
        {
            
        }
    }
}
