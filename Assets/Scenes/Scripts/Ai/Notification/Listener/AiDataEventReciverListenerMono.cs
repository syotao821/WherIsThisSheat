using System;
using UnityEngine;
public abstract class AiDataEventReciverListenerMono : MonoBehaviour,IGameInit
{


    //IDごとの保存に変更

    AiEventReciverMessage _aiEventReciverMessage;


    // 外部取得用
    protected Func<AiData> _getAiData;
    protected Func<AiRunTimeData> _getAiRunTaimeData;

    bool _disposed;

    public int InitOrder =>5;

    public virtual void GameInit()
    {
        _aiEventReciverMessage = new AiEventReciverMessage();
        // イベント購読
        AiEventReciverHub.onReciverAiData += SetAiData;
        AiEventReciverHub.onReciverAiRunTimeData += SetAiRunTimeData;

        // Func登録
        _getAiData = GetAiData;
        _getAiRunTaimeData = GetAiRunTimeData;
    }
 

    private void OnDestroy()
    {
        if (_disposed) return;

        AiEventReciverHub.onReciverAiData -= SetAiData;
        AiEventReciverHub.onReciverAiRunTimeData -= SetAiRunTimeData;

        _disposed = true;
    }

    /// <summary>
    /// AiData受信
    /// </summary>
    void SetAiData(AiData aiData) => _aiEventReciverMessage.SetAiData(aiData);


    /// <summary>
    /// AiRunTimeData受信
    /// </summary>
    void SetAiRunTimeData(AiRunTimeData aiRunTimeData) => _aiEventReciverMessage.SetAiRunTimeData(aiRunTimeData);


    /// <summary>
    /// AiData取得
    /// </summary>
    AiData GetAiData() => _aiEventReciverMessage.GetAiData();


    /// <summary>
    /// AiRunTimeData取得（ID指定）
    /// </summary>
    AiRunTimeData GetAiRunTimeData() => _aiEventReciverMessage.GetAiRunTimeData();

   
}