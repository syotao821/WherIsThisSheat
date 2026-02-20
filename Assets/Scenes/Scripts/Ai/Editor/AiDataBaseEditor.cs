#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class AiAutoAttachWindow : EditorWindow
{
    private AiDataBase targetDatabase;

    [MenuItem("Tools/AI/Addressables Auto Attach")]
    public static void Open()
    {
        GetWindow<AiAutoAttachWindow>("AI Auto Attach");
    }

    void OnGUI()
    {
        GUILayout.Space(10);

        EditorGUILayout.LabelField("AI Database Auto Attach", EditorStyles.boldLabel);

        GUILayout.Space(5);

        targetDatabase = (AiDataBase)EditorGUILayout.ObjectField(
            "Target Database",
            targetDatabase,
            typeof(AiDataBase),
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
            Debug.LogWarning("AiDataBase が未設定");
            return;
        }

        Debug.Log("[AI] ロード開始");

        await AiDataLoader.LoadAllAsync(targetDatabase);

        EditorUtility.SetDirty(targetDatabase);
        AssetDatabase.SaveAssets();

        Debug.Log("[AI] Editorロード完了");
    }
}
#endif
