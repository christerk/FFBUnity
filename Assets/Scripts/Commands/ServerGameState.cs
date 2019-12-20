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

            var positions = new Dictionary<string, Position>();
            var roster = command.game.teamHome.roster;
            foreach (var pos in roster.positionArray)
            {
                positions[pos.positionId] = new Position()
                {
                    AbstractLabel = pos.shorthand,
                    Name = pos.positionName,
                    IconURL = pos.urlIconSet,
                    PortraitURL = pos.urlPortrait,
                };
                if (pos.skillArray != null)
                {
                    positions[pos.positionId].Skills.AddRange(pos.skillArray.Select(s => s.key));
                }
            }

            foreach (var p in command.game.teamHome.playerArray)
            {
                Player player = new Player()
                {
                    Id = p.playerId,
                    Name = p.playerName,
                    Team = homeTeam,
                    Gender = Gender.Male,
                    Position = positions[p.positionId],
                    Movement = p.movement,
                    Strength = p.strength,
                    Agility = p.agility,
                    Armour = p.armour,
                    PortraitURL = p.urlPortrait,

                };
                if (p.skillArray != null)
                {
                    player.Skills.AddRange(p.skillArray.Select(s => s.key));
                }
                FFB.Instance.Model.AddPlayer(player);
            }

            foreach (var p in command.game.gameResult.teamResultHome.playerResults)
            {
                var player = FFB.Instance.Model.GetPlayer(p.playerId);
                player.Spp = p.currentSpps;
            }

            positions.Clear();
            roster = command.game.teamAway.roster;
            foreach (var pos in roster.positionArray)
            {
                positions[pos.positionId] = new Position()
                {
                    AbstractLabel = pos.shorthand,
                    Name = pos.positionName,
                    IconURL = pos.urlIconSet,
                    PortraitURL = pos.urlPortrait,
                };
                if (pos.skillArray != null)
                {
                    positions[pos.positionId].Skills.AddRange(pos.skillArray.Select(s => s.key));
                }
            }

            foreach (var p in command.game.teamAway.playerArray)
            {
                Player player = new Player()
                {
                    Id = p.playerId,
                    Name = p.playerName,
                    Team = awayTeam,
                    Gender = Gender.Male,
                    PositionId = p.positionId,
                    Position = positions[p.positionId],
                    Movement = p.movement,
                    Strength = p.strength,
                    Agility = p.agility,
                    Armour = p.armour,
                    PortraitURL = p.urlPortrait,
                };
                if (p.skillArray != null)
                {
                    player.Skills.AddRange(p.skillArray.Select(s => s.key));
                }
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
