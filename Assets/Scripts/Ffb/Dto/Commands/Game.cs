using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Ffb.Dto.Commands
{
    public class Game
    {
        public long gameId;
        public DateTime? scheduled;
        public DateTime? started;
        public DateTime? finished;
        public bool homePlaying;
        public int half;
        public bool homeFirstOffense;
        public bool setupOffense;
        public bool waitingForOpponent;
        public long turnTime;
        public long gameTime;
        public bool timeoutPossible;
        public bool timeoutEnforced;
        public bool concessionPossible;
        public bool testing;
        public string turnMode;
        public string lastTurnMode;
        public string defenderId;
        public string defenderAction;
        public int[] passCoordinate;
        public string throwerId;
        public string throwerAction;
        
        public Team teamAway;
        public TurnData turnDataAway;
        public Team teamHome;
        public TurnData turnDataHome;
        public FieldModel fieldModel;
        public ActingPlayer actingPlayer;
        public GameResult gameResult;
        public GameOptions gameOptions;

        public DialogParameter dialogParameter;
    }
}
