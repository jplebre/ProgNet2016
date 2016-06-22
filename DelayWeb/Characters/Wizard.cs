using DelayWeb.Modules;

namespace DelayWeb.Characters {
    public class Wizard : NonPlayerCharacter {
        public Wizard(string name)
            : base(name) {
            IsWorthy = item => item.Name.ToLowerInvariant().Contains("potion");
            Success = " takes the {0}! Whilst he's examining it, you hide the {1} under your jerkin.";
            Failure = " is not interested in {0}. Furious, he turns you into a newt.";
            Treasure = new TreasureItem() {
                Name = "The Control Key",
                Description = "The Control Key is one of the three Keys to the Kingdom of Winderos"
            };
        }
    }
}