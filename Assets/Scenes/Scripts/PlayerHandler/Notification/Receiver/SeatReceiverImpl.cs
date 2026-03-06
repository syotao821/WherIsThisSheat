public class SeatReceiverImpl:SeatDataEventListener
{
    public SeatData _seatData;


    public void GetData()
    {
        _seatData = _getSeatData.Invoke();

    }

    public void OverRideDispose()
    {
        base.Dispose();
    }
}