using DelayWeb.Modules;

namespace DelayWeb.Characters {
    public class Earl : NonPlayerCharacter {
        public Earl(string name)
            : base(name) {
            IsWorthy = item => item.Name.ToLowerInvariant().Contains("diamond");
            Success = " takes the {1}! Whilst he's examining it, you hide the {0} under your jerkin.";
            Failure = " is not interested in {0}. Furious, he banishes you to his deepest dungeons... forever.";
            Treasure = new TreasureItem() {
                Name = "The Control Key",
                Description = "The Control Key is one of the three Keys to the Kingdom of Winderos"
            };
        }
    }
}