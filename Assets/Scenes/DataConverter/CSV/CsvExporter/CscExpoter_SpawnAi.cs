using System.IO;
using System.Text;
using UnityEngine;

public class CsvExporter_AiSpawn : MonoBehaviour
{

   

    [SerializeField] private AiSpawnDataBase spawnDatabase;

    [ContextMenu("AiSpawnを書き出す")]
    void Export()
    {
        ExportToCsv("Assets/Scenes/Data/ExportedAiSpawn.csv");
    }

    public void ExportToCsv(string filePath)
    {
        if (spawnDatabase == null || spawnDatabase.aiSpawnDataArray == null)
        {
            Debug.LogWarning("AiSpawnDatabase が未設定か空です");
            return;
        }

        // フォルダ生成
        string dir = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        StringBuilder sb = new StringBuilder();

        // ヘッダー
        sb.AppendLine("GroupId,SpawnPos,StandardAiList");

        foreach (var data in spawnDatabase.aiSpawnDataArray)
        {
            // GroupId
            sb.Append(data.GroupId).Append(",");

            // SpawnPos → x|y|z
            sb.Append(VectorToString(data.SpawnPos)).Append(",");

            // StandardAiList
            sb.Append(StandardAiListToString(data.StandardAiList));

            sb.AppendLine();
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        Debug.Log("AiSpawn CSV書き出し完了: " + Path.GetFullPath(filePath));
    }

    // =========================
    // Vector3 → "x|y|z"
    // =========================
    string VectorToString(Vector3 v)
    {
        return $"{v.x}|{v.y}|{v.z}";
    }

    // =========================
    // List<StandardAi> → 文字列
    // =========================
    string StandardAiListToString(System.Collections.Generic.List<StandardAi> list)
    {
        if (list == null || list.Count == 0) return "";

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < list.Count; i++)
        {
            var ai = list[i];

            sb.Append(ai.StandardId);
            sb.Append(":");
            sb.Append(VectorToString(ai.SpawnOffset));

            if (i < list.Count - 1)
                sb.Append(";");
        }

        return sb.ToString();
    }
}