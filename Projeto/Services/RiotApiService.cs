using RiotSharp;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public class RiotApiService
    {
        private readonly RiotApi _apiKey;
        public RiotApiService()
        {
            _apiKey = RiotApi.GetDevelopmentInstance("RGAPI-dddab2e1-17d1-439f-88af-820c9996b2be");
        }

        public async Task<Summoner> getInvocador(String nick)
        {
            Summoner invocador = await _apiKey.Summoner.GetSummonerByNameAsync(Region.Br, nick);
            return invocador;
        }

        public async Task<MatchList> getPartidasJogadas(String accountId)
        {
            MatchList historico = await _apiKey.Match.GetMatchListAsync(Region.Br, accountId);
            return historico;
        }

        public async Task<Match> getPartida(int idPartida)
        {
            Match partida = await _apiKey.Match.GetMatchAsync(Region.Br, idPartida);
            return partida;
        }
    }
}
