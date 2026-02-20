using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CsvImporter_Ai))]
public class CsvImpoterEditor_Ai : Editor
{
    public override void OnInspectorGUI()
    {
        CsvImporter_Ai importer = target as CsvImporter_Ai;
        DrawDefaultInspector();

        if (GUILayout.Button("Aiデータの作成"))
        {
            SetCsvDataToScriptableObject(importer);
        }
    }

    void SetCsvDataToScriptableObject(CsvImporter_Ai csvImporter)
    {
        if (csvImporter.csvFile == null)
        {
            Debug.LogWarning($"{csvImporter.name} : CSVが未設定");
            return;
        }

        string[] lines = csvImporter.csvFile.text.Split('\n');
        List<AiData> aiList = new();

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

            AiData ai = new AiData();

            ai.Id = int.Parse(columns[column++]);
            ai.Name = columns[column++];
            ai.PairSeatId = int.Parse(columns[column++]);
            ai.ViewModelName = columns[column++];
            ai.ViewSpriteNmae = columns[column++];

            string infoCell = columns[column++];

            ai.InformationStringList =
                string.IsNullOrEmpty(infoCell)
                ? new List<string>()
                : new List<string>(infoCell.Split('|'));

            aiList.Add(ai);
        }

        AiDataBase db = ScriptableObject.CreateInstance<AiDataBase>();
        db.aiDataArray = aiList.ToArray();

        string path = "Assets/Scenes/DataConverter/ScriptableObject_Ai/AiDatabase.asset";
        AssetDatabase.CreateAsset(db, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Aiデータ生成 完了");
    }
}
