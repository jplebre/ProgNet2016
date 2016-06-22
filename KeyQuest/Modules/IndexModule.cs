using System;
using System.Threading;
using Nancy;

namespace KeyQuest.Modules {
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
}