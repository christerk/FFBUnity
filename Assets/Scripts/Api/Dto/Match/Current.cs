using System.Collections.Generic;
namespace Fumbbl.Api.Dto.Match
{
    public class Tournament
    {
        public int id;
        public int group;
    }

    public class Team
    {
        public int id;
        public string side;
        public string name;
        public string coach;
        public string race;
        public string rating;
        public int tv;
        public int score;
        public string logo;
    }

    public class Current
    {
        public int id;
        public int half;
        public int turn;
        public string division;
        public Tournament tournament;
        public List<Team> teams;
    }


}
