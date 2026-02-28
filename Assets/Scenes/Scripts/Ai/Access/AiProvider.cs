using UnityEngine;

public class AiProvider
{
    AiApplicationProvider _applicationProvider;
    public AiProvider(GameObject aiObj)
    {
        _applicationProvider = new AiApplicationProvider(aiObj);
    }


    /// <summary>
    /// アプリケーションのゲッター
    /// </summary>
    /// <returns></returns>
    public AiApplicationProvider GetApplication() => _applicationProvider;

}