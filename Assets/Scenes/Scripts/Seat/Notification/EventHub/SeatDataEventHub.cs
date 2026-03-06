

public class SeatDataEventHub
{
    public delegate void OnSeatData(SeatData _seatData);
    public static event OnSeatData _onSeatDate;


    public void RaiseOnSeatData(SeatData _seatData)
    {
        _onSeatDate.Invoke(_seatData);
    }

}