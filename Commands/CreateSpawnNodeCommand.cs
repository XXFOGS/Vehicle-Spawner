using System.Collections.Generic;
using System.Xml.Linq;
using Rocket.API;
using SDG.Unturned;
using UP = Rocket.Unturned.Player.UnturnedPlayer;
using VehicleSpawner;

namespace Template.Commands
{
    class YuriCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "createspawnnode";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions
        {
            get { return new List<string>() { "vehiclespawner.createspawnnode" }; }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            var UP = (UP)caller;

            string folder = Rocket.Core.Environment.PluginsDirectory + "/VehicleSpawner/Databases/Nodes/";
            XDocument Document = XDocument.Load(folder + "SpawnNodes.xml");

            XElement Root = new XElement("SpawnNode");
            Root.Add(new XElement("X", UP.Position.x));
            Root.Add(new XElement("Y", UP.Position.y));
            Root.Add(new XElement("Z", UP.Position.z));

            Document.Element("SpawnNodes").Add(Root);
            Document.Save(folder + "SpawnNodes.xml");

            UP.sendMessage($"[<color=blue> Spawner </color>] Created a new vehicle spawn node");
        }
    }
}
