using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CsvImporter_Seat))]
public class CsvImpoterEditor_Seat : Editor
{
    public override void OnInspectorGUI()
    {
        CsvImporter_Seat importer = target as CsvImporter_Seat;
        DrawDefaultInspector();

        if (GUILayout.Button("Seatデータの作成"))
        {
            SetCsvDataToScriptableObject(importer);
        }
    }

    void SetCsvDataToScriptableObject(CsvImporter_Seat csvImporter)
    {
        if (csvImporter.csvFile == null)
        {
            Debug.LogWarning($"{csvImporter.name} : CSVが未設定");
            return;
        }

        string[] lines = csvImporter.csvFile.text.Split('\n');
        List<SeatData> seatList = new();

        // CSV列:
        // 0:Id
        // 1:Name
        // 2:PairSeatId
        // 3:ViewModelKey
        // 4:ViewSpriteKey
        // 5:Info(|区切り)

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] columns = line.Split(',');
            int column = 0;

            SeatData seat = new SeatData();

            seat.Id = int.Parse(columns[column++]);
            seat.Name = columns[column++];
            seat.PairAiId = int.Parse(columns[column++]);
            seat.ViewModelName = columns[column++];

           



        }

        SeatDataBase db = ScriptableObject.CreateInstance<SeatDataBase>();
        db._seatDataArray = seatList.ToArray();

        string path = "Assets/Scenes/DataConverter/ScriptableObject_Seat/SeatDatabase.asset";
        AssetDatabase.CreateAsset(db, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Aiデータ生成 完了");
    }
}
