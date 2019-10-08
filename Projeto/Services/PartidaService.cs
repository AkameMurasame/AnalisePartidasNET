using playground.Models;
using Projeto.Models;
using RiotSharp.Endpoints.MatchEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services
{
    public class PartidaService
    {
        private readonly RiotApiService riotApiService;

        public PartidaService(RiotApiService _riotApiService)
        {
            riotApiService = _riotApiService;
        }
        public async Task<MatchList> getPartidasJogadas(String accountId)
        {
            MatchList historico = await riotApiService.getPartidasJogadas(accountId);
            return historico;
        }

        public async Task<Match> getPartida(int idPartida)
        {
            Match partida = await riotApiService.getPartida(idPartida);
            return partida;
        }

        public Partida salvarPartida(MatchReference partida, Invocador invocador, Match partidaAPI, Participant jogador)
        {
            Partida partidaEntity = new Partida();
            partidaEntity.accountId = invocador;
            //partidaEntity.setStatusPartida(statusPartida);
            partidaEntity.id = partida.GameId;

            ParticipantStats jogadorStats = jogador.Stats;

            long getMultikill = jogadorStats.LargestMultiKill;
            if (getMultikill == 1)
            {
                partidaEntity.multiKill = "Kill '-'";
            }
            else if (getMultikill == 2)
            {
                partidaEntity.multiKill = "Double Kill";
            }
            else if (getMultikill == 3)
            {
                partidaEntity.multiKill = "Triple Kill";
            }
            else if (getMultikill == 4)
            {
                partidaEntity.multiKill = "Quadra Kill";
            }
            else if (getMultikill == 5)
            {
                partidaEntity.multiKill = "Penta Kill";
            }

            partidaEntity.duracao = partidaAPI.GameDuration;
            // jogador.getChampionId()

            long kills = jogadorStats.Kills;
            long deaths = jogadorStats.Deaths;
            long assists = jogadorStats.Assists;

            partidaEntity.kda  = kills.ToString . "/" . deaths.ToString + "/" + assists.IoString;
            partidaEntity.scoreVisao = jogadorStats.VisionScore;
            partidaEntity.farm = jogadorStats.totalMinionsKilled;
            partidaEntity.gold = jogadorStats.goldEarned;
            partidaEntity.wards = jogadorStats.wardsPlaced;
            partidaEntity.resultado = jogadorStats.Winner;
            partidaEntity = partidaRepository.save(partidaEntity);

            for (int indexBuild = 0; indexBuild < 6; indexBuild++)
            {
                ItensPartida itens = new ItensPartida();
                itens.setIdPartida(partidaEntity);
                itens.setItemId(utilService.getItem(indexBuild, jogadorStats));
                itensRepository.save(itens);
                logger.info("salvando iten: " + itens.getItemId());
            }

            SpellsPartida spells = new SpellsPartida();
            spells.setIdPartida(partidaEntity);
            spells.setSpellId(jogador.getSpell1Id());
            spellsPartidaRepository.save(spells);
            logger.info("salvando spell: " + spells.getSpellId());
            spells.setSpellId(jogador.getSpell2Id());
            spellsPartidaRepository.save(spells);
            logger.info("salvando spell: " + spells.getSpellId());

            //RunasPartida runas = new RunasPartida();
            //runas.setIdPartida(partidaEntity);
            //runas.setRunaId(jogador.getRunes().get(0).getRuneId());
            //runasPartidaRepository.save(runas);
            //logger.info("salvando runa: " + runas.getRunaId());
            //runas.setRunaId(jogador.getRunes().get(1).getRuneId());
            //runasPartidaRepository.save(runas);
            //logger.info("salvando runa: " + runas.getRunaId());

            logger.info("partida salva: id da Partida" + partidaEntity.getIdPartida());

            return partidaEntity;
        }
    }
}
