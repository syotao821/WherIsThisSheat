
using UnityEngine;
/// <summary>
/// ロジックを集約させる
/// </summary>
public class AiLogickIntegration
{

    Transform _aiTransform;

    /// <summary>
    /// 初期化
    /// </summary>
    public AiLogickIntegration(Transform _aiTransform)
    {
        this._aiTransform = _aiTransform;
    }
}