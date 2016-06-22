using System;
using System.Text.RegularExpressions;
using System.Threading;
using DelayWeb.Characters;
using Nancy;
using Nancy.ModelBinding;

namespace DelayWeb.Modules {
    public class IndexModule : NancyModule {
        public IndexModule() {
            Get["/"] = _ => View["index"];

            Get["/hello/{name?World}"] = parameters => {
                int delay;
                Int32.TryParse(Request.Query["delay"], out delay);
                if (delay > 0) Thread.Sleep(TimeSpan.FromSeconds(delay));
                return ("Hello, " + parameters["name"]);
            };
        }
    }

    public class QuestModule : NancyModule {

        public Func<Object> Wrap(Func<TreasureItem, Object> interaction) {
            return () => "foo"; /*{
                try {
                    return ("foo");
                    var treasure = this.Bind<TreasureItem>();
                    return (interaction(treasure));
                } catch (Exception ex) {
                    return new Response {
                        StatusCode = HttpStatusCode.BadRequest,
                        ReasonPhrase = ex.Message
                    };
                }
            };*/
        }

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
        private readonly Weaver weaver = new Weaver("The Webmaster");
        private readonly Earl earl = new Earl("Earl Ang");
        private readonly Wizard wizard = new Wizard("Ballmerack");
        public QuestModule() {
            Post["/knight"] = _ => Encounter(knight);
            Post["/cleric"] = _ => Encounter(cleric);
            Post["/earl"] = _ => Encounter(earl);
            Post["/wizard"] = _ => Encounter(wizard);
            Post["/weaver"] = _ => Encounter(weaver);
        }
    }
}