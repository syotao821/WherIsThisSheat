using UnityEngine;

/// <summary>
/// ロジックのアクセッサー
/// </summary>
public class AiLogicProvider
{
    AiLogickIntegration _aiLogickIntegration;

    public AiLogicProvider(Transform _aiTransform)
    {
        _aiLogickIntegration=new AiLogickIntegration(_aiTransform);
    }
}