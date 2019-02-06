using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TicTacToePlayer
{
    public static class MakePlay
    {
        [FunctionName("make-play")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var playerType = req.RequestUri.ParseQueryString().Get("playerType");
            var requestString = await req.Content.ReadAsStringAsync();
            var boardState = JsonConvert.DeserializeObject<BoardState>(requestString);
            var newState = new PlayerFactory().GetPlayer(playerType).MakePlay(boardState);


            return req.CreateResponse(new PlayerResponse{board = newState});
        }
    }
}
