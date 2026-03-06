public class SeatReceiverImpl:SeatDataEventListener
{
    public SeatData _seatData;


    public void Start()
    {
        _seatData = _getSeatData.Invoke();

    }

    public void OverRideDispose()
    {
        base.Dispose();
    }
}