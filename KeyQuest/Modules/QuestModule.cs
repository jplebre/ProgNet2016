using System;
using KeyQuest.Characters;
using Nancy;
using Nancy.ModelBinding;

namespace KeyQuest.Modules {
    public class QuestModule : NancyModule {

        public object Encounter(NonPlayerCharacter npc) {
            try {
                var treasure = this.Bind<TreasureItem>();
                return (npc.Interact(treasure));
            } catch (Exception ex) {
                return new Response {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = ex.Message
                };
            }
        }

        private readonly Knight knight = new Knight("Sir Timber-Nursely");
        private readonly Cleric cleric = new Cleric("Baliskov");
        private readonly Weaver weaver = new Weaver("The Dream-Weaver");
        private readonly Earl earl = new Earl("Earl Ang");
        private readonly Wizard wizard = new Wizard("Ballmerack");
        private readonly Keysmith keysmith = new Keysmith("Cherry");
        public QuestModule() {
            Post["/knight"] = _ => Encounter(knight);
            Post["/cleric"] = _ => Encounter(cleric);
            Post["/earl"] = _ => Encounter(earl);
            Post["/wizard"] = _ => Encounter(wizard);
            Post["/weaver"] = _ => Encounter(weaver);
            Post["/keysmith"] = _ => Encounter(keysmith);

        }
    }
}