

using static SeatDataEventHub;

public class SeatDataEventHub
{
    public delegate void OnSeatData(SeatData _seatData);
    public static event OnSeatData _onSeatDate;
    public delegate void OnSeatRunTimeData(SeatRunTimeData _seatRunTimeData);
    public static event OnSeatRunTimeData _onSeatRunTimeData;

    public void RaiseOnSeatData(SeatData _seatData)
    {
        _onSeatDate.Invoke(_seatData);
    }
    public void RaiseOnSeatRunTimeData(SeatRunTimeData _seatRunTimeData)
    {
        _onSeatRunTimeData.Invoke(_seatRunTimeData);
    }

}