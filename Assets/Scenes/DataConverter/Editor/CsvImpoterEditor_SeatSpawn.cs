using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CsvImporter_SeatSpawn))]
public class CsvImpoterEditor_SeatSpawn : Editor
{
    public override void OnInspectorGUI()
    {
        CsvImporter_SeatSpawn importer = target as CsvImporter_SeatSpawn;
        DrawDefaultInspector();

        if (GUILayout.Button("Seat生成データの作成"))
        {
            SetCsvDataToScriptableObject(importer);
        }
    }

    void SetCsvDataToScriptableObject(CsvImporter_SeatSpawn csvImporter)
    {
        if (csvImporter.csvFile == null)
        {
            Debug.LogWarning($"{csvImporter.name} : CSVが未設定");
            return;
        }

        string[] lines = csvImporter.csvFile.text.Split('\n');
        List<SeatSpawnData> spawnList = new();

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

            SeatSpawnData spawn = new SeatSpawnData();

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

            List<StandardSeat> seatList = new();

            string[] idArray = idCell.Split('|');
            string[] offsetArray = offsetCell.Split('|');

            int count = Mathf.Min(idArray.Length, offsetArray.Length);

            for (int j = 0; j < count; j++)
            {
                StandardSeat seat = new StandardSeat();

                // --- ID ---
                seat.StandardId = int.Parse(idArray[j]);

                // --- Offset ---
                string[] xyz = offsetArray[j].Split(':');
                Vector3 offset = new Vector3(
                    float.Parse(xyz[0]),
                    float.Parse(xyz[1]),
                    float.Parse(xyz[2])
                );

                seat.SpawnOffset = offset;

                seatList.Add(seat);
            }

            spawn.StandardSeatList = seatList;
            spawnList.Add(spawn);
        }

        // ========= ScriptableObject =========
       SeatSpawnDataBase db = ScriptableObject.CreateInstance<SeatSpawnDataBase>();
        db._seatSpawnDataArray = spawnList.ToArray();

        string path = "Assets/Scenes/DataConverter/ScriptableObject_SpawnSeat/SeatSpawnDatabase.asset";
        AssetDatabase.CreateAsset(db, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Seat生成データ生成 完了");
    }
}