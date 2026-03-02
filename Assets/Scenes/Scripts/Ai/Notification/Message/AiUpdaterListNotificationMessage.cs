using System.Collections.Generic;

public class AiUpdaterListNotificationMessage
{

    readonly List<AiBase> _aiBaseList = new();
    readonly HashSet<AiBase> _dedupe = new();

    /// <summary>
    /// 登録前にクリア（フレーム開始時に呼ぶ）
    /// </summary>
    public void Clear()
    {
        _aiBaseList.Clear();
        _dedupe.Clear();
    }

    public void AddAiBase(AiBase _aiBase)
    {
        if (_aiBase == null) return;

        // 重複防止
        if (_dedupe.Add(_aiBase))
        {
            _aiBaseList.Add(_aiBase);
        }
    }

    /// <summary>
    /// 読み取り専用で取得
    /// </summary>
    public IReadOnlyList<AiBase> GetAiBaseList()
    {
        return _aiBaseList;
    }
}