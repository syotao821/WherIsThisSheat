using System;

public class SeatDataEventListener : IDisposable
{
    SeatDataEventMessage _seatEventMessage;
    public Func<SeatData> _getSeatData;

    public SeatDataEventListener()
    {
        _seatEventMessage=new SeatDataEventMessage();
        SeatDataEventHub._onSeatDate += SetSeatDate;
        _getSeatData = GetSeatDate;
    }


    public void Dispose()
    {
        SeatDataEventHub._onSeatDate -= SetSeatDate;
    }

    void SetSeatDate(SeatData _seatData) => _seatEventMessage.SetSeatData(_seatData);
    SeatData GetSeatDate() => _seatEventMessage.GetSeatData();
}