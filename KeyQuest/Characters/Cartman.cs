using System;
using KeyQuest.Modules;

namespace KeyQuest.Characters {
    public class Cartman : NonPlayerCharacter {
        public Cartman(string name)
            : base(name) {
            IsWorthy = item => item.Name.ToLowerInvariant().Contains("bag of gold");
            Success = " being the bitchy boy he is, he only gives you the diamond when you give him the {0}";
            Failure = "Swears at you and farts and such, like the big bully he is";
            Treasure = new TreasureItem() {
                Name = "Diamond of Multiple Inheritance",
                Description = "Someone very high up the royal court might have an use for this"
            };
        }
    }
}