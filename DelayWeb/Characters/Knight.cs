using DelayWeb.Modules;

namespace DelayWeb.Characters {
    public class Knight : NonPlayerCharacter {
        public Knight(string name)
            : base(name) {
            // The knight is only interested in swords.
            IsWorthy = item => item.Name.ToLowerInvariant().Contains("cloak of demeter");
            Success = " does not see you, thanks to {0}, and you quietly sneak away with {1}.";
            Failure = " defends his castle with ferocity and honour. Which is quite bad news for you, because he's a heavily-armed knight.";
            Treasure = new TreasureItem() {
                Name = "Potion of Immutability",
                Description = "This potion provides powerful defence against side-effects."
            };
        }
    }
}