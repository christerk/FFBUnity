namespace Fumbbl.Ffb.Dto.Reports
{
    public class SecretWeaponBan : Report
    {
        public string reportId;
        public string[] playerIds;
        public int[] rolls;
        public bool[] banArray;

        public SecretWeaponBan() : base("secretWeaponBan") { }
    }
}
