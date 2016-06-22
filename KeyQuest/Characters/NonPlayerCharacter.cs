using System;
using System.Threading;
using KeyQuest.Modules;

namespace KeyQuest.Characters {
    public abstract class NonPlayerCharacter {
        protected NonPlayerCharacter(string name) {
            Name = name;
        }


        protected string Name { get; set; }
        protected TreasureItem Treasure { get; set; }
        protected string Success { get; set; }
        protected string Failure { get; set; }
        protected Func<TreasureItem, bool> IsWorthy { get; set; }

        protected Random random = new Random();
        public Encounter Interact(TreasureItem item) {
            Thread.Sleep(500 + random.Next(1000));
            if (IsWorthy(item)) {
                return new Encounter() {
                    Text = Name + String.Format(Success, item.Name, Treasure.Name),
                    Item = Treasure
                };
            }
            var phrase = String.Format(Name + Failure, item.Name);
            throw (new Exception(phrase));
        }

    }
}