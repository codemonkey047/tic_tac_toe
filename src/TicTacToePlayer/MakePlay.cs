using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace TicTacToePlayer
{
    public static class MakePlay
    {
        [FunctionName("make-play")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var requestString = await req.Content.ReadAsStringAsync();
            var boardState = JsonConvert.DeserializeObject<BoardState>(requestString);
            log.Info(boardState.NextPlayer);
            for (var i = 0 ; i < boardState.Board.Length; i++)
                if (boardState.Board[i] == "-")
                {
                    boardState.Board[i] = boardState.NextPlayer;
                    break;
                }
            return req.CreateResponse(boardState.Board);
        }
    }
}
