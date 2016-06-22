using DelayWeb.Modules;

namespace DelayWeb.Characters {
    public class Cleric : NonPlayerCharacter {
        public Cleric(string name)
            : base(name) {
            Treasure = new TreasureItem() {
                Name = "The Alt Key",
                Description = "The Alt Key is one of the three Keys to the Kingdom of Winderos"
            };
            IsWorthy = item => item.Name.ToLowerInvariant().Contains("key");
            Success = " gratefully accepts the {0}, and offers you the {1} in exchange.";
            Failure = " is not interested in {0}. She casts a spell on you, and you spend the rest of your life trying to prove that all squares are rectangles.";
            Treasure = new TreasureItem() {
                Name = "The Control Key",
                Description = "The Control Key is one of the three Keys to the Kingdom of Winderos"
            };
        }
    }
}