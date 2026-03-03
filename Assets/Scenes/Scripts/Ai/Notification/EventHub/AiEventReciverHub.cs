public class AiEventReciverHub
{
    public static event OnReciverAiData onReciverAiData;
    public  delegate void OnReciverAiData(AiData _aiData);

    public static event OnReciverAiRunTimeData onReciverAiRunTimeData;
    public delegate void OnReciverAiRunTimeData(AiRunTimeData _aiRunTimeData);
    public void RaiseOnReciverAiData(AiData _aiData)
    {
        onReciverAiData.Invoke(_aiData);
    }

    public void RaiseOnReciverAiRunTimeData(AiRunTimeData _aiRunTimeData)
    {
        onReciverAiRunTimeData.Invoke(_aiRunTimeData);
    }
}