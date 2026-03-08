
using UnityEngine;

/// <summary>
/// AI生成ジェネレータ（グループ配置型）
/// </summary>
public class AiGenerator : SpawnGenerator<AiBase>,IGameInit
{
    [SerializeField] LoadAiData loadAiData;
    AiUpdaterEventListener _aiUpdaterEventListener;
    AiUpdaterListEventHub _aiUpdaterListEventHub;

    public int InitOrder =>2;

    /// <summary>
    /// 初回生成
    /// </summary>
    void IGameInit.GameInit()
    {
        _aiUpdaterEventListener = new AiUpdaterEventListener();
        _aiUpdaterListEventHub  = new AiUpdaterListEventHub();

        AiDiContainer.Inject(_aiUpdaterEventListener);

        foreach (AiSpawnData spawnData in loadAiData.AiSpawnDataBase.aiSpawnDataArray)
        {
            foreach (StandardAi standardAi in spawnData.StandardAiList)
            {
                (GameObject _aiObj, AiBase _aiBase) =
                    CreateNew(loadAiData.AiDataBase.aiDataArray[standardAi.StandardId].ViewModel, spawnData.SpawnPos + standardAi.SpawnOffset, Quaternion.identity, 
                    aiObj => new AiBase(aiObj, loadAiData.AiDataBase.aiDataArray[standardAi.StandardId], spawnData));
                _aiUpdaterListEventHub.RaiseOnAiBase(_aiBase);
            }

        }
    } 

    void OnDestroy()
    {
        _aiUpdaterListEventHub.RaiseOnAiBaseListClear();
        _aiUpdaterEventListener.Dispose();

    }

}