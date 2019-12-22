namespace Fumbbl.Model.Types
{
    public class CardType : FfbEnumerationFactory
    {
        public string DeckName;
        public string InducementNameSingle;
        public string InducementNameMultiple;
        public GameOption MaxGameOption;
        public GameOption CostGameOption;

        public CardType(string name) : base(name) { }

        public static CardType MiscellaneousMayhem = new CardType("miscellaneousmayhem") { DeckName = "Miscellaneous Mayhem Deck", InducementNameSingle = "Miscellaneous Mayhem Card", InducementNameMultiple = "Miscellaneous Mayhem Cards", MaxGameOption = GameOption.CardsMiscellaneousMayhemMax , CostGameOption = GameOption.CardsDesperateMeasureCost };
        public static CardType SpecialTeamPlays = new CardType("specialTeamPlay") { DeckName = "Special Team Plays Deck", InducementNameSingle = "Special Team Play Card", InducementNameMultiple = "Special Team Play Cards", MaxGameOption = GameOption.CardsSpecialTeamPlayMax , CostGameOption = GameOption.CardsSpecialTeamPlayCost };
        public static CardType MagicItems = new CardType("magicItem") { DeckName = "Magic Items Deck", InducementNameSingle = "Magic Item Card", InducementNameMultiple = "Magic Item Cards", MaxGameOption = GameOption.CardsMagicItemMax , CostGameOption = GameOption.CardsMagicItemCost };
        public static CardType DirtyTricks = new CardType("dirtyTrick") { DeckName = "Dirty Tricks Deck", InducementNameSingle = "Dirty Trick Card", InducementNameMultiple = "Dirty Trick Cards", MaxGameOption = GameOption.CardsDirtyTrickMax , CostGameOption = GameOption.CardsDirtyTrickCost };
        public static CardType GoodKarma = new CardType("goodKarma") { DeckName = "Good Karma Deck", InducementNameSingle = "Good Karma Card", InducementNameMultiple = "Good Karma Cards", MaxGameOption = GameOption.CardsGoodKarmaMax , CostGameOption = GameOption.CardsGoodKarmaCost };
        public static CardType RandomEvents = new CardType("randomEvent") { DeckName = "Random Events Deck", InducementNameSingle = "Random Event Card", InducementNameMultiple = "Random Event Cards", MaxGameOption = GameOption.CardsRandomEventMax , CostGameOption = GameOption.CardsRandomEventCost };
        public static CardType DesperateMeasures = new CardType("desperateMeasure") { DeckName = "Desperate Measures Deck", InducementNameSingle = "Desperate Measure Card", InducementNameMultiple = "Desperate Measure Cards", MaxGameOption = GameOption.CardsDesperateMeasureMax , CostGameOption = GameOption.CardsDesperateMeasureCost };
    }
}
