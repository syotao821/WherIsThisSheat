using System.IO;
using System.Text;
using UnityEngine;

public class CsvExporter_Seat : MonoBehaviour
{
    [SerializeField] private SeatDataBase seatDatabase;

    [ContextMenu("Seatデータを書き出す")]
    void CsvExport()
    {
        ExportToCsv("Assets/Scenes/Data/ExportedSeatData.csv");
    }

    public void ExportToCsv(string filePath)
    {
        if (seatDatabase == null || seatDatabase._seatDataArray == null)
        {
            Debug.LogWarning("SeatDatabase が設定されていないか、データが空です。");
            return;
        }

        // フォルダ生成
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        StringBuilder sb = new StringBuilder();

        // Importerと完全一致ヘッダー
        sb.AppendLine("Id,Name,PairSeatId,ViewModelKey");

        foreach (var seatData in seatDatabase._seatDataArray)
        {
            sb.Append(seatData.Id).Append(",");
            sb.Append(seatData.Name).Append(",");
            sb.Append(seatData.PairAiId).Append(",");
            sb.Append(seatData.ViewModelName).Append(",");
            sb.AppendLine();
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        Debug.Log("CSV書き出し完了: " + filePath);
        Debug.Log("実際の保存先: " + Path.GetFullPath(filePath));

    }
}
