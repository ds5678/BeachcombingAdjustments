using UnityEngine;
namespace BeachcombingAdjustments
{
    class LootTableUtils
    {
        public static LootTable GetLootTable(string name)
        {
            foreach (LootTable t in Resources.FindObjectsOfTypeAll<LootTable>())
            {
                if (t.name == name)
                {
                    return t;
                }
            }
            return null;
        }

        public static bool IsInLootTable(LootTable table, string gearname)
        {
            foreach(GameObject prefab in table.m_Prefabs)
            {
                if(prefab.name == gearname)
                {
                    return true;
                }
            }
            return false;
        }

        public static void AddEntryToLootTable(LootTable table, string gearname, int weight)
        {
            if (IsInLootTable(table, gearname))
            {
                for (int i = 0; i < table.m_Prefabs._size; i++)
                {
                    if (table.m_Prefabs[i].name == gearname)
                    {
                        table.m_Weights[i] = weight;
                    }
                }
            }
            else
            {
                table.m_Prefabs.Add(GetObjectPrefab(gearname));
                table.m_Weights.Add(weight);
            }
        }

        public static void RemoveEntryFromLootTable(LootTable table, string gearname)
        {
            for (int i = 0; i < table.m_Prefabs._size; i++)
            {
                if (table.m_Prefabs[i].name == gearname)
                {
                    table.m_Prefabs.RemoveAt(i);
                    table.m_Weights.RemoveAt(i);
                    break;
                }
            }
        }
        
        public static void AddOrRemoveEntryFromLootTable(LootTable table, bool isAdding, string gearname, int weight)
        {
            if (isAdding)
            {
                AddEntryToLootTable(table, gearname, weight);
            }
            else
            {
                RemoveEntryFromLootTable(table, gearname);
            }
        }

        private static GameObject GetObjectPrefab(string name) => Resources.Load(name).Cast<GameObject>();
    }
}
