

public class AiDataEventHub
{
    public static event OnAiData _onAiData;
    public delegate void OnAiData(AiData _aiaData);

    public static event OnAiRunTimeData _onAiRunTimeData;
    public delegate void OnAiRunTimeData(AiRunTimeData _aiRunTimeData);

    public void RaiseAiData(AiData _aiData)
    {
        _onAiData?.Invoke(_aiData);
    }

    public void RaiseAiRunTimeData(AiRunTimeData _aiRunTimeData)
    {
        _onAiRunTimeData?.Invoke(_aiRunTimeData);
    }
}