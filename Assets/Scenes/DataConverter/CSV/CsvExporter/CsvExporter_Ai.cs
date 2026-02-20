using System.IO;
using System.Text;
using UnityEngine;

public class CsvExporter_Ai : MonoBehaviour
{
    [SerializeField] private AiDataBase aiDatabase;

    [ContextMenu("Aiデータを書き出す")]
    void CsvExport()
    {
        ExportToCsv("Assets/Scenes/Data/ExportedAiData.csv");
    }

    public void ExportToCsv(string filePath)
    {
        if (aiDatabase == null || aiDatabase.aiDataArray == null)
        {
            Debug.LogWarning("AiDatabase が設定されていないか、データが空です。");
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
        sb.AppendLine("Id,Name,PairSeatId,ViewModelKey,ViewSpriteKey,InformationStrings");

        foreach (var ai in aiDatabase.aiDataArray)
        {
            sb.Append(ai.Id).Append(",");
            sb.Append(ai.Name).Append(",");
            sb.Append(ai.PairSeatId).Append(",");
            sb.Append(ai.ViewModelName).Append(",");
            sb.Append(ai.ViewSpriteNmae).Append(",");

            // List<string> → a|b|c
            if (ai.InformationStringList != null && ai.InformationStringList.Count > 0)
            {
                sb.Append(string.Join("|", ai.InformationStringList));
            }

            sb.AppendLine();
        }

        File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        Debug.Log("CSV書き出し完了: " + filePath);
        Debug.Log("実際の保存先: " + Path.GetFullPath(filePath));

    }
}
