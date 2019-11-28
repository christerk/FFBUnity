using System.Collections.Generic;

namespace Fumbbl.Model
{
    public class GazeModifier
    {
        public string Name { get; set; }
        public int Modifier { get; set; }
        public boolean TacklezoneModifier { get; set; }
    }

    public static class GazeModifierExtensions
    {
        private static readonly Dictionary<string, GazeModifier> GazeModifiers = new Dictionary<string, GazeModifier>();

        static GazeModifierExtensions()
        {
            GazeModifiers= new Dictionary<string, GazeModifier>()
            {
                ["1 Tacklezone"] = new GazeModifier() { Name = "1 Tacklezone", Modifier = 1, TacklezoneModifier = true},
                ["2 Tacklezones"] = new GazeModifier() { Name = "2 Tacklezones", Modifier = 2, TacklezoneModifier = true},
                ["3 Tacklezones"] = new GazeModifier() { Name = "3 Tacklezones", Modifier = 3, TacklezoneModifier = true},
                ["4 Tacklezones"] = new GazeModifier() { Name = "4 Tacklezones", Modifier = 4, TacklezoneModifier = true},
                ["5 Tacklezones"] = new GazeModifier() { Name = "5 Tacklezones", Modifier = 5, TacklezoneModifier = true},
                ["6 Tacklezones"] = new GazeModifier() { Name = "6 Tacklezones", Modifier = 6, TacklezoneModifier = true},
                ["7 Tacklezones"] = new GazeModifier() { Name = "7 Tacklezones", Modifier = 7, TacklezoneModifier = true},
                ["8 Tacklezones"] = new GazeModifier() { Name = "8 Tacklezones", Modifier = 8, TacklezoneModifier = true}
            }
        }

        public static GazeModifier AsGazeModifier(this FFBEnumeration ffbEnum)
        {
            return GazeModifiers.ContainsKey(ffbEnum.key) ? GazeModifiers[ffbEnum.key] : null;
        }
 }