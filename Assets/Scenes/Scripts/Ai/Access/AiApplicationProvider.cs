using UnityEngine;
/// <summary>
/// アプリケーションのアクセッサー
/// </summary>
public class AiApplicationProvider
{
    AiApplicationIntegration _aiApplicationIntegration;

    public AiApplicationProvider(GameObject thisObj)
    {
        _aiApplicationIntegration=new AiApplicationIntegration(thisObj);
    }
    public AiApplicationIntegration GetApplication()
    {
        return _aiApplicationIntegration;
    }

}