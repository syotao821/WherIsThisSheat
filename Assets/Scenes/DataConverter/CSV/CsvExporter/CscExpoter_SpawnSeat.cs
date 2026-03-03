using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CsvExporter_SeatSpawn : MonoBehaviour
{



    [SerializeField] private SeatSpawnDataBase spawnDatabase;

    [ContextMenu("SeatSpawnを書き出す")]
    void Export()
    {
        ExportToCsv("Assets/Scenes/Data/ExportedSeatSpawn.csv");
    }

    public void ExportToCsv(string filePath)
    {
        if (spawnDatabase == null || spawnDatabase._seatSpawnDataArray == null)
        {
            Debug.LogWarning("SeatSpawnDatabase が未設定か空です");
            return;
        }

        string dir = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        StringBuilder sb = new StringBuilder();

        // Importer互換ヘッダー
        sb.AppendLine("GroupId,PosX,PosY,PosZ,StandardIdList,OffsetList");

        foreach (var data in spawnDatabase._seatSpawnDataArray)
        {
            sb.Append(data.GroupId).Append(",");

            // --- Pos ---
            sb.Append(data.SpawnPos.x).Append(",");
            sb.Append(data.SpawnPos.y).Append(",");
            sb.Append(data.SpawnPos.z).Append(",");

            // --- ID一覧 ---
            sb.Append(GetIdList(data.StandardSeatList)).Append(",");

            // --- Offset一覧 ---
            sb.Append(GetOffsetList(data.StandardSeatList));

            sb.AppendLine();
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        Debug.Log("AiSpawn CSV書き出し完了: " + Path.GetFullPath(filePath));
    }

    // =========================
    // List<StandardAi> → 文字列
    // =========================
    string GetIdList(List<StandardSeat> list)
    {
        if (list == null || list.Count == 0) return "";

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < list.Count; i++)
        {
            sb.Append(list[i].StandardId);
            if (i < list.Count - 1)
                sb.Append("|");
        }

        return sb.ToString();
    }

    string GetOffsetList(List<StandardSeat> list)
    {
        if (list == null || list.Count == 0) return "";

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < list.Count; i++)
        {
            Vector3 v = list[i].SpawnOffset;
            sb.Append($"{v.x}:{v.y}:{v.z}");

            if (i < list.Count - 1)
                sb.Append("|");
        }

        return sb.ToString();
    }
}