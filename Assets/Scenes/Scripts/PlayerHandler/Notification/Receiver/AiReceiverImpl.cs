
/// <summary>
/// AiDataEventReciverListenerを２重継承させるためのからクラス
/// </summary>
class AiReceiverImpl : AiDataEventReciverListener
{
    public AiData _aiData;
    public AiRunTimeData _aiRunTimeData;


   public void GetData()
    {
        _aiData = _getAiData.Invoke();
        _aiRunTimeData= _getAiRunTaimeData.Invoke();

    }

    public  void OverRideDispose()
    {
        base.Dispose();
    }
}