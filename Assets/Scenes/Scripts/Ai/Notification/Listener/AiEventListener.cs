using System;

/// <summary>
/// AIデータのイベント受信とデータ提供を担当するリスナークラス
/// ・AiDataEventReceiver から送られてくる AiData を受け取る
/// ・最新の AiData を保持する
/// ・外部から Func 経由で AiData を取得できるようにする
/// ・Dispose 時にイベント購読を解除してリークを防ぐ
/// </summary>
public class AiEventListener : IDisposable
{
    /// <summary>
    /// AiData の保存・取得を実際に行うメッセージクラス
    /// </summary>
    AiDataNotificationMessage _aiDataNotificationMessage;

    /// <summary>
    /// 外部から AiData を取得するための公開 Func
    /// 他クラスは AiEventListener._getAiData?.Invoke() で取得できる
    /// </summary>
    public static System.Func<AiData> _getAiData;

    /// <summary>
    /// Dispose が二重に呼ばれないようにするフラグ
    /// </summary>
    bool _disposed;

    /// <summary>
    /// コンストラクタ
    /// ・メッセージクラス生成
    /// ・イベント購読開始
    /// ・取得用 Func を登録
    /// </summary>
    public AiEventListener()
    {
        // AiData の保存先を生成
        _aiDataNotificationMessage = new AiDataNotificationMessage();

        // AiDataEventReceiver からの通知を購読
        AiDataEventReceiver._onAiData += SetAiData;

        // 外部から取得できるよう Func を登録
        _getAiData = GetAiData;
    }

    /// <summary>
    /// 後始末
    /// ・イベント購読解除
    /// ・二重解除防止
    /// </summary>
    public void Dispose()
    {
        // すでに破棄済みなら何もしない
        if (_disposed) return;

        // イベント購読解除（メモリリーク防止）
        AiDataEventReceiver._onAiData -= SetAiData;

        // 破棄済みフラグON
        _disposed = true;
    }

    /// <summary>
    /// AiDataEventReceiver から呼ばれる受信処理
    /// 受け取った AiData を内部に保存する
    /// </summary>
    void SetAiData(AiData _aiData)
        => _aiDataNotificationMessage.SetAiData(_aiData);

    /// <summary>
    /// 外部から呼ばれる取得処理
    /// 現在保持している AiData を返す
    /// </summary>
    AiData GetAiData()
        => _aiDataNotificationMessage.GetAiData();
}