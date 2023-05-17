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
        private Random random;

        public override void BeforeStart()
        {
            random = new Random();
            SpawnRandomPrefab();
        }

        private void SpawnRandomPrefab()
        {
            List<string> prefabList = new List<string>()
    {
        "blocker1", // Add your prefab names here
        "blocker1",
        "blocker1",
        "blocker1",
        "blocker1",
        "blocker1",
        "blocker1",
        "blocker1",
        "blocker1",
        "blocker1",
        // Add more prefab names here
    };

            int prefabCount = prefabList.Count;
            int spawnCount = 10; // Number of prefabs to spawn

            Vector3D origin = new Vector3D(0, 0, 0);

            for (int i = 0; i < spawnCount; i++)
            {
                int randomIndex = random.Next(prefabCount);
                string randomPrefab = prefabList[randomIndex];

                int spawnRange = 5000; // Range of 5000 in each direction

                double x = random.NextDouble() * spawnRange * 2 - spawnRange;
                double y = random.NextDouble() * spawnRange * 2 - spawnRange;
                double z = random.NextDouble() * spawnRange * 2 - spawnRange;

                Vector3D spawnPosition = new Vector3D(x, y, z);

                Vector3D direction = Vector3D.Normalize(origin - spawnPosition);
                Vector3D up = Vector3D.Normalize(spawnPosition);

                MyVisualScriptLogicProvider.SpawnPrefab(randomPrefab, spawnPosition, direction, up);
            }
        }

        protected override void UnloadData()
        {
        }
    }
}
