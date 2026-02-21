using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CsvImporter_AiSpawn))]
public class CsvImpoterEditor_AISpawn : Editor
{
    public override void OnInspectorGUI()
    {
        CsvImporter_AiSpawn importer = target as CsvImporter_AiSpawn;
        DrawDefaultInspector();

        if (GUILayout.Button("Ai生成データの作成"))
        {
            SetCsvDataToScriptableObject(importer);
        }
    }

    void SetCsvDataToScriptableObject(CsvImporter_AiSpawn csvImporter)
    {
        if (csvImporter.csvFile == null)
        {
            Debug.LogWarning($"{csvImporter.name} : CSVが未設定");
            return;
        }

        string[] lines = csvImporter.csvFile.text.Split('\n');
        List<AiSpawnData> spawnList = new();

        // CSV列:
        // 0:GroupId
        // 1:PosX
        // 2:PosY
        // 3:PosZ
        // 4:StandardIdList (|)
        // 5:OffsetList (x:y:z|x:y:z)

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] columns = line.Split(',');
            int col = 0;

            AiSpawnData spawn = new AiSpawnData();

            // ========= 基本 =========
            spawn.GroupId = int.Parse(columns[col++]);

            Vector3 pos = new Vector3(
                float.Parse(columns[col++]),
                float.Parse(columns[col++]),
                float.Parse(columns[col++])
            );
            spawn.SpawnPos = pos;

            // ========= 単体AI =========
            string idCell = columns[col++];
            string offsetCell = columns[col++];

            List<StandardAi> aiList = new();

            string[] idArray = idCell.Split('|');
            string[] offsetArray = offsetCell.Split('|');

            int count = Mathf.Min(idArray.Length, offsetArray.Length);

            for (int j = 0; j < count; j++)
            {
                StandardAi ai = new StandardAi();

                // --- ID ---
                ai.StandardId = int.Parse(idArray[j]);

                // --- Offset ---
                string[] xyz = offsetArray[j].Split(':');
                Vector3 offset = new Vector3(
                    float.Parse(xyz[0]),
                    float.Parse(xyz[1]),
                    float.Parse(xyz[2])
                );

                ai.SpawnOffset = offset;

                aiList.Add(ai);
            }

            spawn.StandardAiList = aiList;
            spawnList.Add(spawn);
        }

        // ========= ScriptableObject =========
        AiSpawnDataBase db = ScriptableObject.CreateInstance<AiSpawnDataBase>();
        db.aiSpawnDataArray = spawnList.ToArray();

        string path = "Assets/Scenes/DataConverter/ScriptableObject_Ai/AiSpawnDatabase.asset";
        AssetDatabase.CreateAsset(db, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Ai生成データ生成 完了");
    }
}