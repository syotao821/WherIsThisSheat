using System;
using System.Collections.Generic;
public class AiUpdaterEventListener : IDisposable
{
    AiUpdaterListNotificationMessage _aiUpdaterListNotificationMessage;
    public Func<IReadOnlyList<AiBase>> _getAiBaseList;

    bool _disposed;

    public AiUpdaterEventListener()
    {
        _aiUpdaterListNotificationMessage=new AiUpdaterListNotificationMessage();

        AiUpdaterListEventHub._onAiBase += AddAiBase;
        AiUpdaterListEventHub._onAiBaseClear += Clear;

        _getAiBaseList = GetAiBaseList;
    }

    public void Dispose()
    {
        // すでに破棄済みなら何もしない
        if (_disposed) return;

        // イベント購読解除（メモリリーク防止）
        AiUpdaterListEventHub._onAiBase -= AddAiBase;
        AiUpdaterListEventHub._onAiBaseClear -= Clear;

        // 破棄済みフラグON
        _disposed = true;
    }
  
    void Clear()=> _aiUpdaterListNotificationMessage.Clear();

    void AddAiBase(AiBase _aiBase) => _aiUpdaterListNotificationMessage.AddAiBase(_aiBase);

    public IReadOnlyList<AiBase> GetAiBaseList() => _aiUpdaterListNotificationMessage.GetAiBaseList();


}