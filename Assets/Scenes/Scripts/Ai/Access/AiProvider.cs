using UnityEngine;
/// <summary>
/// AIに関する総合的なアクセッサー
/// </summary>
public class AiProvider
{
    AiApplicationProvider _applicationProvider;
    AiLogickIntegration _logickIntegration;


    public AiProvider(GameObject _aiObj)
    {
        _applicationProvider = new AiApplicationProvider(_aiObj);
        _logickIntegration = new AiLogickIntegration(_aiObj.transform);
    }


    /// <summary>
    /// アプリケーションのゲッター
    /// </summary>
    /// <returns></returns>
    public AiApplicationProvider GetApplication() => _applicationProvider;

    /// <summary>
    /// ロジックのゲッター
    /// </summary>
    /// <returns></returns>
    public AiLogickIntegration GetAiLogickIntegration() => _logickIntegration;

}