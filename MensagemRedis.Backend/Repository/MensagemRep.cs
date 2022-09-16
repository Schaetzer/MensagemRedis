using Dapper;
using MensagemRedis.Backend.Interfaces;
using MensagemRedis.Backend.Models;
using Npgsql;

namespace MensagemRedis.Backend.Repository
{
    public class MensagemRep : IMensagemRep
    {
        public List<Mensagem> GetMensagem()
        {
            var cs = $"server=localhost;database=db_mensagem;user id=postgres;password=Postgresql706?";
            using var conn = new NpgsqlConnection(cs);
            {
                conn.Open();

                var sql = "SELECT id, descricao Descricao FROM mensagem;";

                var result = conn.Query<Mensagem>(sql).ToList();
                return result;
            }
        }
    }
}
