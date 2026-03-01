using System.Collections.Generic;
using UnityEngine;

public class AiNotification
{

    readonly List<Transform> _hitTransformList = new();
    readonly HashSet<Transform> _dedupe = new();

    /// <summary>
    /// 登録前にクリア（フレーム開始時に呼ぶ）
    /// </summary>
    public void Clear()
    {
        _hitTransformList.Clear();
        _dedupe.Clear();
    }

    public void AddHitTransform(Transform hitTransform)
    {
        if (hitTransform == null) return;

        // 重複防止
        if (_dedupe.Add(hitTransform))
        {
            _hitTransformList.Add(hitTransform);
        }
    }

    /// <summary>
    /// 読み取り専用で取得
    /// </summary>
    public IReadOnlyList<Transform> GetHitTransformList()
    {
        return _hitTransformList;
    }
}