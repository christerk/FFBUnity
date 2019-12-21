using Fumbbl.Ffb.Dto.Reports;
using Fumbbl.Model;
using Fumbbl.Model.Types;
using System.Collections.Generic;
using System.Linq;

namespace Fumbbl.Commands
{
    public class ServerGameState : CommandHandler<Ffb.Dto.Commands.ServerGameState>
    {
        public override void Apply(Ffb.Dto.Commands.ServerGameState command)
        {
            FFB.Instance.Model.Clear();

            Coach homeCoach = new Coach()
            {
                Name = command.game.teamHome.coach,
                IsHome = true
            };

            Coach awayCoach = new Coach()
            {
                Name = command.game.teamAway.coach,
                IsHome = false
            };

            Team homeTeam = new Team()
            {
                Id = command.game.teamHome.teamId,
                Coach = homeCoach,
                Name = command.game.teamHome.teamName,
                Fame = command.game.gameResult.teamResultHome.fame,
                FanFactor = command.game.teamHome.fanFactor
            };

            Team awayTeam = new Team()
            {
                Id = command.game.teamAway.teamId,
                Coach = awayCoach,
                Name = command.game.teamAway.teamName,
                Fame = command.game.gameResult.teamResultAway.fame,
                FanFactor = command.game.teamAway.fanFactor
            };

            FFB.Instance.Model.TeamHome = homeTeam;
            FFB.Instance.Model.TeamAway = awayTeam;

            FFB.Instance.Model.HomePlaying = command.game.homePlaying;

            FFB.Instance.Model.HomeCoach = homeCoach;
            FFB.Instance.Model.AwayCoach = awayCoach;

            FFB.Instance.Model.Ball.Coordinate = Coordinate.Create(command.game.fieldModel.ballCoordinate);
            FFB.Instance.Model.Ball.InPlay = command.game.fieldModel.ballInPlay;
            FFB.Instance.Model.Ball.Moving = command.game.fieldModel.ballMoving;

            var roster = command.game.teamHome.roster;
            FFB.Instance.Model.PositionsHome.Clear();
            foreach (var pos in roster.positionArray)
            {
               FFB.Instance.Model.PositionsHome[pos.positionId] = Ffb.Conversion.PositionFactory.Position(pos);
            }

            foreach (var p in command.game.teamHome.playerArray)
            {
                Player player = Ffb.Conversion.PlayerFactory.Player(p, homeTeam, FFB.Instance.Model.PositionsHome[p.positionId]);
                FFB.Instance.Model.AddPlayer(player);
            }

            foreach (var p in command.game.gameResult.teamResultHome.playerResults)
            {
                var player = FFB.Instance.Model.GetPlayer(p.playerId);
                player.Spp = p.currentSpps;
            }

            roster = command.game.teamAway.roster;
            FFB.Instance.Model.PositionsAway.Clear();
            foreach (var pos in roster.positionArray)
            {
               FFB.Instance.Model.PositionsAway[pos.positionId] = Ffb.Conversion.PositionFactory.Position(pos);
            }

            foreach (var p in command.game.teamAway.playerArray)
            {
                Player player = Ffb.Conversion.PlayerFactory.Player(p, awayTeam, FFB.Instance.Model.PositionsAway[p.positionId]);
                FFB.Instance.Model.AddPlayer(player);
            }

            foreach (var p in command.game.gameResult.teamResultAway.playerResults)
            {
                var player = FFB.Instance.Model.GetPlayer(p.playerId);
                player.Spp = p.currentSpps;
            }


            foreach (var p in command.game.fieldModel.playerDataArray)
            {
                Player player = FFB.Instance.Model.GetPlayer(p.playerId);
                player.Coordinate = Coordinate.Create(p.playerCoordinate);
                player.PlayerState = PlayerState.Get(p.playerState);
            }

            FFB.Instance.Model.Half = command.game.half;
            FFB.Instance.Model.TurnHome = command.game.turnDataHome.turnNr;
            FFB.Instance.Model.TurnAway = command.game.turnDataAway.turnNr;
            FFB.Instance.Model.TurnMode = command.game.turnMode.As<TurnMode>();

            FFB.Instance.Model.ScoreHome = command.game.gameResult.teamResultHome.score;
            FFB.Instance.Model.ScoreAway = command.game.gameResult.teamResultAway.score;
            FFB.Instance.Model.ActingPlayer.PlayerId = command.game.actingPlayer.playerId;
            FFB.Instance.Model.ActingPlayer.CurrentMove = command.game.actingPlayer.currentMove;
        }
    }
}
