public class SeatReceiverImpl:SeatDataEventListener
{
    public SeatData _seatData;
    public SeatRunTimeData _seatRunTimeData;

    public void GetData()
    {
        _seatData = _getSeatData.Invoke();
        _seatRunTimeData = _getSeatRuntimeData.Invoke();
    }

    public void OverRideDispose()
    {
        base.Dispose();
    }
}