using System;

/// <summary>
/// AIデータのイベント受信とデータ提供を担当
/// ・IDごとにAiDataを保持
/// ・Func経由で外部取得可能
/// ・Disposeでイベント解除
/// </summary>
public class AiDataEventListener : IDisposable
{
    //IDごとの保存に変更

    AiDataNotificationMessage _aiDataNotificationMessage;

    // 外部取得用
    public Func<AiData> _getAiData;
    public Func<AiRunTimeData> _getAiRunTaimeData;

    bool _disposed;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public AiDataEventListener()
    {
        _aiDataNotificationMessage = new AiDataNotificationMessage();
        // イベント購読
        AiDataEventHub._onAiData += SetAiData;
        AiDataEventHub._onAiRunTimeData += SetAiRunTimeData;

        // Func登録
        _getAiData = GetAiData;
        _getAiRunTaimeData = GetAiRunTimeData;
    }

    /// <summary>
    /// 後始末
    /// </summary>
    public void Dispose()
    {
        if (_disposed) return;

        AiDataEventHub._onAiData -= SetAiData;
        AiDataEventHub._onAiRunTimeData -= SetAiRunTimeData;

        _disposed = true;
    }

    /// <summary>
    /// AiData受信
    /// </summary>
    void SetAiData( AiData aiData)=> _aiDataNotificationMessage.SetAiData(aiData);


    /// <summary>
    /// AiRunTimeData受信
    /// </summary>
    void SetAiRunTimeData( AiRunTimeData aiRunTimeData)=> _aiDataNotificationMessage.SetAiRunTimeData(aiRunTimeData);   


    /// <summary>
    /// AiData取得
    /// </summary>
    AiData GetAiData()=> _aiDataNotificationMessage.GetAiData();


    /// <summary>
    /// AiRunTimeData取得（ID指定）
    /// </summary>
    AiRunTimeData GetAiRunTimeData()=> _aiDataNotificationMessage.GetAiRunTimeData();


}