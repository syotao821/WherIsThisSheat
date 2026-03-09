using System;

public class SeatDataEventListener : IDisposable
{
    SeatDataEventMessage _seatEventMessage;
    public Func<SeatData> _getSeatData;
    public Func<SeatRunTimeData> _getSeatRuntimeData;

    public SeatDataEventListener()
    {
        _seatEventMessage=new SeatDataEventMessage();
        SeatDataEventHub._onSeatDate += SetSeatDate;
        SeatDataEventHub._onSeatRunTimeData += SetSeatRuntimeData;
        _getSeatData = GetSeatDate;
        _getSeatRuntimeData= GetSeatRuntimeData;
  
    }


    public void Dispose()
    {
        SeatDataEventHub._onSeatDate -= SetSeatDate;
        SeatDataEventHub._onSeatRunTimeData -= SetSeatRuntimeData;

    }

    void SetSeatDate(SeatData _seatData) => _seatEventMessage.SetSeatData(_seatData);
    SeatData GetSeatDate() => _seatEventMessage.GetSeatData();

   void SetSeatRuntimeData(SeatRunTimeData _seatRuntimeData) => _seatEventMessage.SetSeatRuntimeData(_seatRuntimeData);

   SeatRunTimeData GetSeatRuntimeData() => _seatEventMessage.GetSeatRuntimeData();
}