
using UnityEngine;

/// <summary>
/// AI生成ジェネレータ（グループ配置型）
/// </summary>
public class AiGenerator : SpawnGenerator<AIBase>,IGameInit
{

    [SerializeField] LoadAiData loadAiData;

    //このクラスで通知リストのAddを行う
   
    /// <summary>
    /// 初回生成
    /// </summary>
    void IGameInit.GameInit()
    {

        foreach (AiSpawnData spawnData in loadAiData.AiSpawnDataBase.aiSpawnDataArray)
        {
            foreach (StandardAi standardAi in spawnData.StandardAiList)
            {
                (GameObject obj, AIBase logic) =
                    CreateNew(loadAiData.AiDataBase.aiDataArray[standardAi.StandardId].ViewModel, spawnData.SpawnPos+ standardAi.SpawnOffset,Quaternion.identity, go => new AIBase(go));
                NotificationManager.Instance.AiNotification.AddHitTransform(loadAiData.AiDataBase.aiDataArray[standardAi.StandardId].ViewModel.transform);
            }

        }
    } 


  
}