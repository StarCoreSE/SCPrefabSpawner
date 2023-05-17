using System;
using System.Collections.Generic;
using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRageMath;


namespace Klime.spawnmytheprefab
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class spawnmytheprefab : MySessionComponentBase
    {
        public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
        {
            MyAPIGateway.Utilities.MessageEntered += UtilitiesOnMessageEntered;
        }

        private void UtilitiesOnMessageEntered(string messagetext, ref bool sendtoothers)
        {
            try
            {
                if (messagetext.StartsWith("/prefab "))
                {
                    if (messagetext.Length > 8)
                    {
                        string words = "";
                        words = messagetext.Substring(7);
                        if (words != null  && words.Length > 0)
                        {
                            MyVisualScriptLogicProvider.SpawnPrefab(words, MyAPIGateway.Session.Player.GetPosition() + MyAPIGateway.Session.Player.Character.WorldMatrix.Forward * 100,
                                                                MyAPIGateway.Session.Player.Character.WorldMatrix.Forward, MyAPIGateway.Session.Player.Character.WorldMatrix.Up);
                            sendtoothers = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MyAPIGateway.Utilities.ShowMessage("", e.Message);
            }

        }

        protected override void UnloadData()
        {
            MyAPIGateway.Utilities.MessageEntered -= UtilitiesOnMessageEntered;
        }
    }
}