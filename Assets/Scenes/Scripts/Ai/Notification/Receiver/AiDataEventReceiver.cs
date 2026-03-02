using UnityEngine;

public class AiDataEventReceiver
{
    AiData aiData;
    public static event OnAiData _onAiData;
    public delegate void OnAiData(AiData _aiaData);

    AiData _getAiData;
    public AiDataEventReceiver()
    {
        aiData = new AiData();
        aiData.Name = "abc";


        _onAiData?.Invoke(aiData);

        Debug.Log(_getAiData.Name);
    }

}