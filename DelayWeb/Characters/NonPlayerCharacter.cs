using System;
using System.Threading;
using DelayWeb.Modules;

namespace DelayWeb.Characters {
    public abstract class NonPlayerCharacter {
        protected NonPlayerCharacter(string name) {
            Name = name;
        }


        protected string Name { get; set; }
        protected TreasureItem Treasure { get; set; }
        protected string Success { get; set; }
        protected string Failure { get; set; }
        protected Func<TreasureItem, bool> IsWorthy { get; set; }

        public Encounter Interact(TreasureItem item) {
            if (IsWorthy(item)) {
                Thread.Sleep(1000);
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