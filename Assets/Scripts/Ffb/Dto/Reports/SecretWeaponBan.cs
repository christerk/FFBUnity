namespace Fumbbl.Ffb.Dto.Reports
{
    public class SecretWeaponBan : Report
    {
        public SecretWeaponBan() : base("secretWeaponBan") { }

        public string reportId;
        public string[] playerIds;
        public int[] rolls;
        public bool[] banArray;
    }
}
