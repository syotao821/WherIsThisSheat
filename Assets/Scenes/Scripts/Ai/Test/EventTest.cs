using System.Diagnostics;

public class EventTest: AiDataEventReciverListener
{
    AiData AiData;
    public void Update()
    {
        AiData = _getAiData.Invoke();

        UnityEngine.Debug.Log(AiData.Name);
    }
}