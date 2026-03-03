#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class SeatAutoAttachWindow : EditorWindow
{
    private SeatDataBase targetDatabase;

    [MenuItem("Tools/Seat/Addressables Auto Attach")]
    public static void Open()
    {
        GetWindow<SeatAutoAttachWindow>("Seat Auto Attach");
    }

    void OnGUI()
    {
        GUILayout.Space(10);

        EditorGUILayout.LabelField("Seat Database Auto Attach", EditorStyles.boldLabel);

        GUILayout.Space(5);

        targetDatabase = (SeatDataBase)EditorGUILayout.ObjectField(
            "Target Database",
            targetDatabase,
            typeof(SeatDataBase),
            false);

        GUILayout.Space(10);

        GUI.enabled = targetDatabase != null;

        if (GUILayout.Button("Addressables から自動アタッチ", GUILayout.Height(40)))
        {
            Run().Forget();
        }

        GUI.enabled = true;
    }

    async UniTaskVoid Run()
    {
        if (targetDatabase == null)
        {
            Debug.LogWarning("SeatDataBase が未設定");
            return;
        }

        Debug.Log("[Seat] ロード開始");

        await SeatDataLoader.LoadAllAsync(targetDatabase);

        EditorUtility.SetDirty(targetDatabase);
        AssetDatabase.SaveAssets();

        Debug.Log("[Seat] Editorロード完了");
    }
}
#endif
