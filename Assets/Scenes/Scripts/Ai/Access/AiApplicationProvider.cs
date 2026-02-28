using UnityEngine;

public class AiApplicationProvider
{
    AiApplicationIntegration _aiApplicationIntegration;

    public AiApplicationProvider(GameObject thisObj)
    {
        _aiApplicationIntegration=new AiApplicationIntegration(thisObj);
        Debug.Log(_aiApplicationIntegration.GetAiTransform().position);
    }
    public AiApplicationIntegration GetApplication()
    {
        return _aiApplicationIntegration;
    }

}