using System;
using UnityEngine;

/// <summary>
/// ロジックのアクセッサー
/// </summary>
public class AiLogicProvider: IDisposable
{
    AiLogickIntegration _aiLogickIntegration;

    public AiLogicProvider(Transform _aiTransform)
    {
        _aiLogickIntegration=new AiLogickIntegration(_aiTransform);
    }

	public AiLogickIntegration GetAiLogickIntegration() => _aiLogickIntegration;

	public void Dispose() => _aiLogickIntegration.Dispose();

}