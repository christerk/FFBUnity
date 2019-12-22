namespace Fumbbl.Model.Types
{
    public class GameOption : FfbEnumerationFactory
    {
        public object Default;
        public string MessageIfCustom;

        public GameOption(string name) : base(name) { }

        public static GameOption Overtime = new GameOption("overtime") { Default = false, MessageIfCustom = "Game will go into overtime if there is a draw after 2nd half." };
        public static GameOption Turntime = new GameOption("turntime") { Default = 240, MessageIfCustom = "Turntime is {0} sec." };
        public static GameOption PettyCash = new GameOption("pettyCash") { Default = true, MessageIfCustom = "Petty Cash is not available." };
        public static GameOption Inducements = new GameOption("inducements") { Default = true, MessageIfCustom = "Inducements are not available." };
        public static GameOption CheckOwnership = new GameOption("checkOwnership") { Default = true, MessageIfCustom = "Team ownership is not checked." };
        public static GameOption TestMode = new GameOption("testMode") { Default = false, MessageIfCustom = "Game is in TEST mode. No result will be uploaded. See help for available test commands." };
        public static GameOption MaxNrOfCards = new GameOption("maxNrOfCards") { Default = 5, MessageIfCustom = "A maximum of {0} cards can be bought." };
        public static GameOption MaxPlayersOnField = new GameOption("maxPlayersOnField") { Default = 11, MessageIfCustom = "A maximum of {0} players may be set up on the field." };
        public static GameOption MaxPlayersInWideZone = new GameOption("maxPlayersInWideZone") { Default = 2, MessageIfCustom = "A maximum of {0} players may be set up in a widezone." };
        public static GameOption MinPlayersOnLos = new GameOption("minPlayersOnLos") { Default = 3, MessageIfCustom = "A minimum of {0} players must be set up on the line of scrimmage." };
        public static GameOption AllowStarOnBothTeams = new GameOption("allowStarOnBothTeams") { Default = false, MessageIfCustom = "A star player may play for both teams." };
        public static GameOption ForceTreasuryToPettyCash = new GameOption("forceTreasuryToPettyCash") { Default = true, MessageIfCustom = "Treasury is not automatically transferred to Petty Cash." };
        public static GameOption UsePredefinedInducements = new GameOption("usePredefinedInducements") { Default = false, MessageIfCustom = "Inducements are predefined." };
        public static GameOption ClawDoesNotStack = new GameOption("clawDoesNotStack") { Default = false, MessageIfCustom = "Claw does not stack with other skills that modify armour rolls." };
        public static GameOption FoulBonus = new GameOption("foulBonus") { Default = false, MessageIfCustom = "+1 to armour roll for a foul." };
        public static GameOption FoulBonusOutsideTacklezone = new GameOption("foulBonusOutsideTacklezone") { Default = false, MessageIfCustom = "+1 to armour roll for a foul, if fouler is not in an opposing tacklezone." };
        public static GameOption FreeInducementCash = new GameOption("freeInducementCash") { Default = 0, MessageIfCustom = "Both coaches get {0} extra gold to buy inducements with." };
        public static GameOption FreeCardCash = new GameOption("freeCardCash") { Default = 0, MessageIfCustom = "Both coaches get {0} extra gold to buy cards with." };
        public static GameOption PilingOnDoesNotStack = new GameOption("pilingOnDoesNotStack") { Default = false, MessageIfCustom = "Piling On does not stack with other skills that modify armour- or injury-rolls." };
        public static GameOption PilingOnInjuryOnly = new GameOption("pilingOnInjuryOnly") { Default = false, MessageIfCustom = "Piling On lets you re-roll injury-rolls only." };
        public static GameOption PilingOnArmorOnly = new GameOption("pilingOnArmorOnly") { Default = false, MessageIfCustom = "Piling On lets you re-roll armour-rolls only." };
        public static GameOption PilingOnToKoOnDouble = new GameOption("pilingOnToKoOnDouble") { Default = false, MessageIfCustom = "Piling On player knocks himself out when rolling a double on armour or injury." };
        public static GameOption PilingOnUsesATeamReroll = new GameOption("pilingOnUsesATeamReroll") { Default = true, MessageIfCustom = "Piling On does not cost a Team Re-roll to use." };
        public static GameOption RightStuffCancelsTackle = new GameOption("rightStuffCancelsTackle") { Default = false, MessageIfCustom = "Right Stuff prevents Tackle from negating Dodge for Pow/Pushback." };
        public static GameOption SneakyGitAsFoulGuard = new GameOption("sneakyGitAsFoulGuard") { Default = false, MessageIfCustom = "Sneaky Git works like Guard for fouling assists." };
        public static GameOption SneakyGitBanToKo = new GameOption("sneakyGitBanToKo") { Default = false, MessageIfCustom = "Sneaky Git players that get banned are sent to the KO box instead." };
        public static GameOption StandFirmNoDropOnFailedDodge = new GameOption("standFirmNoDropOnFailedDodge") { Default = false, MessageIfCustom = "Stand Firm players do not drop on a failed dodge roll but end their move instead." };
        public static GameOption SpikedBall = new GameOption("spikedBall") { Default = false, MessageIfCustom = "A Spiked Ball is used for play. Any failed Pickup or Catch roll results in the player being stabbed." };
        public static GameOption ArgueTheCall = new GameOption("argueTheCall") { Default = true, MessageIfCustom = "Calls may not be argued." };
        public static GameOption MvpNominations = new GameOption("mvpNominations") { Default = 3, MessageIfCustom = "{0} players may be nominated to receice the MVP award." };
        public static GameOption PettyCashAffectsTv = new GameOption("pettyCashAffectsTv") { Default = false, MessageIfCustom = "Petty Cash affects Team Value." };
        public static GameOption WizardAvailable = new GameOption("wizardAvailable") { Default = false, MessageIfCustom = "A wizard may be bought as an inducement." };
        public static GameOption ExtraMvp = new GameOption("extraMvp") { Default = false, MessageIfCustom = "An extra MVP is awarded at the end of the match" };
        public static GameOption CardsMiscellaneousMayhemCost = new GameOption("cardsMiscellaneousMayhemCost") { Default = 50000, MessageIfCustom = "Miscellaneous Mayhem cards can be bought for {0} gps each." };
        public static GameOption CardsMiscellaneousMayhemMax = new GameOption("cardsMiscellaneousMayhemMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Miscellaneous Mayhem cards." };
        public static GameOption CardsSpecialTeamPlayCost = new GameOption("cardsSpecialTeamPlayCost") { Default = 50000, MessageIfCustom = "Special Team Play cards can be bought for {0} gps each." };
        public static GameOption CardsSpecialTeamPlayMax = new GameOption("cardsSpecialTeamPlayMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Special Team Play cards." };
        public static GameOption CardsMagicItemCost = new GameOption("cardsMagicItemCost") { Default = 50000, MessageIfCustom = "Magic Item cards can be bought for {0} gps each." };
        public static GameOption CardsMagicItemMax = new GameOption("cardsMagicItemMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Magic Item cards." };
        public static GameOption CardsDirtyTrickCost = new GameOption("cardsDirtyTrickCost") { Default = 50000, MessageIfCustom = "Dirty Trick cards can be bought for {0} gps each." };
        public static GameOption CardsDirtyTrickMax = new GameOption("cardsDirtyTrickMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Dirty Trick cards." };
        public static GameOption CardsGoodKarmaCost = new GameOption("cardsGoodKarmaCost") { Default = 100000, MessageIfCustom = "Good Karma cards can be bought for {0} gps each." };
        public static GameOption CardsGoodKarmaMax = new GameOption("cardsGoodKarmaMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Good Karma cards." };
        public static GameOption CardsRandomEventCost = new GameOption("cardsRandomEventCost") { Default = 200000, MessageIfCustom = "Random Event cards can be bought for {0} gps each." };
        public static GameOption CardsRandomEventMax = new GameOption("cardsRandomEventMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Random Event cards." };
        public static GameOption CardsDesperateMeasureCost = new GameOption("cardsDesperateMeasureCost") { Default = 400000, MessageIfCustom = "Desperate Measure cards can be bought for {0} gps each." };
        public static GameOption CardsDesperateMeasureMax = new GameOption("cardsDesperateMeasureMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Desperate Measure cards." };
        public static GameOption InducementAposCost = new GameOption("inducementAposCost") { Default = 100000, MessageIfCustom = "Wandering apothecaries can be purchased for {0} gps each." };
        public static GameOption InducementAposMax = new GameOption("inducementAposMax") { Default = 2, MessageIfCustom = "Coaches may purchase up to {0} wandering apothecarie(s)." };
        public static GameOption InducementBribesCost = new GameOption("inducementBribesCost") { Default = 100000, MessageIfCustom = "Bribes can be purchased for {0} gps each." };
        public static GameOption InducementBribesReducedCost = new GameOption("inducementBribesReducedCost") { Default = 50000, MessageIfCustom = "Bribes for reduced price can be purchased for {0} gps each." };
        public static GameOption InducementBribesMax = new GameOption("inducementBribesMax") { Default = 3, MessageIfCustom = "Coaches may purchase up to {0} bribe(s)." };
        public static GameOption InducementChefsCost = new GameOption("inducementChefsCost") { Default = 300000, MessageIfCustom = "Halfling Master Chefs can be purchased for {0} gps each." };
        public static GameOption InducementChefsReducedCost = new GameOption("inducementChefsReducedCost") { Default = 100000, MessageIfCustom = "Halfling Master Chefs for reduced price can be purchased for {0} gps each." };
        public static GameOption InducementChefsMax = new GameOption("inducementChefsMax") { Default = 1, MessageIfCustom = "Coaches may purchase up to {0} Halfling Master Chef(s)." };
        public static GameOption InducementExtraTrainingCost = new GameOption("inducementExtraTrainingCost") { Default = 100000, MessageIfCustom = "Rerolls can be purchased for {0} gps each." };
        public static GameOption InducementExtraTrainingMax = new GameOption("inducementExtraTrainingMax") { Default = 4, MessageIfCustom = "Coaches may purchase up to {0} reroll(s)." };
        public static GameOption InducementIgorsCost = new GameOption("inducementIgorsCost") { Default = 100000, MessageIfCustom = "Igors can be purchased for {0} gps each." };
        public static GameOption InducementIgorsMax = new GameOption("inducementIgorsMax") { Default = 1, MessageIfCustom = "Coaches may purchase up to {0} Igor(s)." };
        public static GameOption InducementKegsCost = new GameOption("inducementKegsCost") { Default = 50000, MessageIfCustom = "Bloodweiser Kegs can be purchased for {0} gps each." };
        public static GameOption InducementKegsMax = new GameOption("inducementKegsMax") { Default = 2, MessageIfCustom = "Coaches may purchase up to {0} Bloodweiser Keg(s)." };
        public static GameOption InducementMercenariesExtraCost = new GameOption("inducementMercenariesExtraCost") { Default = 30000, MessageIfCustom = "Mercenaries can be purchased for an extra {0} gps each." };
        public static GameOption InducementMercenariesSkillCost = new GameOption("inducementMercenariesSkillCost") { Default = 50000, MessageIfCustom = "Mercenaries can can gain an extra skill for {0} gps." };
        public static GameOption InducementMercenariesMax = new GameOption("inducementMercenariesMax") { Default = int.MaxValue, MessageIfCustom = "Coaches may purchase up to {0} Mercenaries." };
        public static GameOption InducementStarsMax = new GameOption("inducementStarsMax") { Default = 2, MessageIfCustom = "Coaches may purchase up to {0} star(s)." };
        public static GameOption InducementWizardsCost = new GameOption("inducementWizardsCost") { Default = 150000, MessageIfCustom = "Wizards can be purchased for {0} gps each." };
        public static GameOption InducementWizardsMax = new GameOption("inducementWizardsMax") { Default = 0, MessageIfCustom = "Coaches may purchase up to {0} wizard(s)." };
        public static GameOption PitchUrl = new GameOption("pitchUrl") { MessageIfCustom = "Custom pitch set." };
    }
}
