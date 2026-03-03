/// <summary>
/// 通知専用のクラス
/// </summary>
public class AiDataNotificationMessage
{

    AiData _aiData;
    AiRunTimeData _aiRunTimeData;

    public void SetAiData(AiData _aiData) => this._aiData = _aiData;
    public void SetAiRunTimeData(AiRunTimeData _aiRunTimeData) => this._aiRunTimeData = _aiRunTimeData;

    public AiData GetAiData() => this._aiData;
    public AiRunTimeData GetAiRunTimeData() => this._aiRunTimeData;

}
  