
using UnityEngine;
using static UnityEngine.PlayerLoop.PreUpdate;

/// <summary>
/// AI生成ジェネレータ（グループ配置型）
/// </summary>
public class AiGenerator : SpawnGenerator<AiBase>,IGameInit
{
    [SerializeField] LoadAiData loadAiData;
    AiUpdaterEventListener _aiUpdaterEventListener;
    AiUpdaterListEventHub _aiUpdaterListEventHub;
    AiUpdater _aiUpdater;
    /// <summary>
    /// 初回生成
    /// </summary>
    void IGameInit.GameInit()
    {
        _aiUpdater = FindFirstObjectByType<AiUpdater>();
        _aiUpdaterEventListener = new AiUpdaterEventListener();
        _aiUpdaterListEventHub  = new AiUpdaterListEventHub();
        _aiUpdater.InitDI(_aiUpdaterEventListener);
        foreach (AiSpawnData spawnData in loadAiData.AiSpawnDataBase.aiSpawnDataArray)
        {
            foreach (StandardAi standardAi in spawnData.StandardAiList)
            {
                (GameObject _aiObj, AiBase _aiBase) =
                    CreateNew(loadAiData.AiDataBase.aiDataArray[standardAi.StandardId].ViewModel, spawnData.SpawnPos + standardAi.SpawnOffset, Quaternion.identity, aiObj => new AiBase(aiObj));
                _aiUpdaterListEventHub.RaiseOnAiBase(_aiBase);
            }

        }
    } 

    void OnDestroy()
    {
        _aiUpdaterListEventHub.RaiseAiBaseListClear();
        _aiUpdaterEventListener.Dispose();

    }

}