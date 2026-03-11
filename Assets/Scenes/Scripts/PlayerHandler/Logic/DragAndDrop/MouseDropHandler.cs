using System;

public class MouseDropHandler: IDisposable
{
    AiReceiverImpl _aiReceiverImpl;
    public MouseDropHandler()
    {
        _aiReceiverImpl=new AiReceiverImpl();
    }

    /// <summary>
    /// 
    /// </summary>
    public void AiSeatCheckAll()
    {
        _aiReceiverImpl.GetData();

        _aiReceiverImpl._aiRunTimeData.IsSeated = true;
    }
    /// <summary>
    /// 
    /// </summary>
    public void AiSeatCheck()
    {
        _aiReceiverImpl.GetData();

        if (_aiReceiverImpl._aiRunTimeData.IsCustomerSatisfied)
        {
            _aiReceiverImpl._aiRunTimeData.IsSeated = true;
        }
    }

    public void Dispose()
    {
        _aiReceiverImpl.Dispose();
    }
}