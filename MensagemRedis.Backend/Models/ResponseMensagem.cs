namespace MensagemRedis.Backend.Models
{
    public class ResponseMensagem
    {
        public string Origem { get; set; }
        public IEnumerable<Mensagem> Data { get; set; }
    }
}
