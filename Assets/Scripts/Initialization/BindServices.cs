using Scripts.Content;
using TofuCore.Config;
using TofuCore.Events;
using TofuCore.FrameUpdateServices;
using TofuCore.Player;
using TofuCore.Service;
using TofuCore.Strings;
using TofuPlugin.Pathfinding;
using TofuPlugin.UI;
using UnityEngine;

namespace Assets.Scripts.Initialization {
    public class BindServices : IContextConfigurator {
        public void ConfigureCoreServices(ServiceContext rootServiceContext) {
            new EventLogger().BindServiceContext(rootServiceContext);
            rootServiceContext.AddAlias("EventLogger", "IEventLogger");
            new EventPayloadTypeLibrary(new Payloads().Get()).BindServiceContext(rootServiceContext);
            rootServiceContext.AddAlias("EventPayloadTypeLibrary", "IEventPayloadTypeLibrary");
            new StringsService("English").BindServiceContext(rootServiceContext);

            
        }

        public void ConfigureMenuOnlyServices(ServiceContext rootServiceContext) {

            ConfigLibrary configLibrary = new ConfigLibrary().BindServiceContext(rootServiceContext);
            configLibrary.LoadConfig(Resources.Load<TextAsset>("Config/config").text);

        }

        public void ConfigureGameServices(ServiceContext rootServiceContext) {



            

        }

        public void Configure(IServiceContext context) {
            throw new System.NotImplementedException();
        }

        private static GameObject NewServiceGameObject(string typeName) {
            GameObject obj = new GameObject();
            obj.name = typeName;
            return obj;
        }

    }
}

