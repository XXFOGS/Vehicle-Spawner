using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Globalization;
using Rocket.API;
using Rocket.Core;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Items;
using Rocket.Unturned.Player;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Plugins;
using Rocket.Core.Logging;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Steamworks;
using SDG;
using UnityEngine;
using UnityEngine.Events;
using UP = Rocket.Unturned.Player.UnturnedPlayer;
using Rocket.API.Serialisation;
using Rocket.Unturned.Chat;
using SDG.Provider;
using Logger = Rocket.Core.Logging.Logger;

namespace VehicleSpawner
{
    public class VehicleSpawnerPlugin : RocketPlugin<Configuration>
    {
        public static VehicleSpawnerPlugin Instance;
        public string Creator = "XXFOGS";
        public string PluginName = "VehicleSpawner";
        public string Version = "1.0.0";

        public DateTime? lastSpawn = null;

        protected override void Load()
        {
            Instance = this;

            String cellsFolder = Rocket.Core.Environment.PluginsDirectory + "/VehicleSpawner/Databases/Nodes/";

            if (!System.IO.Directory.Exists(cellsFolder))
            {
                System.IO.Directory.CreateDirectory(cellsFolder);

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = true;

                using (XmlWriter writer = XmlWriter.Create(cellsFolder + "SpawnNodes.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("SpawnNodes");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                }
            }

            Logger.Log($"{PluginName} by {Creator} has been loaded! Version: {Version}");
            
        }

        protected override void Unload()
        {
            Instance = null;

            Logger.Log($"{PluginName} has been unloaded");
        }

        void FixedUpdate()
        {
            spawnVehicle();
        }

        private void spawnVehicle()
        {
            try
            {
                if (State == PluginState.Loaded && Level.isLoaded && Configuration.Instance.Enabled && (lastSpawn == null || ((DateTime.Now - lastSpawn.Value).TotalSeconds > Configuration.Instance.Interval)))
                {
                    String folder = Rocket.Core.Environment.PluginsDirectory + "/VehicleSpawner/Databases/Nodes/";
                    XDocument Nodes = XDocument.Load(folder + "SpawnNodes.xml");
                    var NodesList = Nodes.Element("SpawnNodes").Elements("SpawnNode").ToList();
                    List<SpawnNode> SpawnNodes = new List<SpawnNode>();

                    if (NodesList.Count > 0)
                    {
                        foreach (var SpawnNode in NodesList)
                        {
                            SpawnNodes.Add(new SpawnNode(float.Parse(SpawnNode.Element("X").Value), float.Parse(SpawnNode.Element("Y").Value), float.Parse(SpawnNode.Element("Z").Value)));
                        }

                        VehicleAsset vehicle = ((VehicleAsset)SDG.Unturned.Assets.find(EAssetType.VEHICLE, Configuration.Instance.Vehicles[UnityEngine.Random.Range(0, Configuration.Instance.Vehicles.Length - 1)].Id));
                        SpawnNode node = SpawnNodes.ToArray()[UnityEngine.Random.Range(0, SpawnNodes.ToArray().Length - 1)];
                        Vector3 pos = new Vector3(node.X, node.Y + 10, node.Z);
                        VehicleManager.SpawnVehicleV3(vehicle, 0, 0, 0, pos, new Quaternion(0, 90, 0, 0), false, false, false, false, vehicle.fuelMax, vehicle.healthMax, ushort.MaxValue, CSteamID.Nil, CSteamID.Nil, false, null, byte.MaxValue);
                        Logger.Log($"Spawned a {vehicle.vehicleName} at {pos}", ConsoleColor.Cyan);
                        lastSpawn = DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
