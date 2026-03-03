using System;
using System.Collections.Generic;

public class SeatUpdaterListenr:IDisposable
{
    SeatUpdaterMessage _seatUpdaterMessage;
    public Func<IReadOnlyList<SeatBase>> _getSeatList;
    bool _disposed;

    public SeatUpdaterListenr()
    {
        _seatUpdaterMessage=new SeatUpdaterMessage();
        SeatUpdaterEventHub._onAddSeatBaseList += AddSeatBaseList;
        _getSeatList = GetSeatList;
    }

    public void Dispose()
    {
        if (_disposed) return;
        SeatUpdaterEventHub._onAddSeatBaseList -= AddSeatBaseList;
        _disposed = true;
    }


    void AddSeatBaseList(SeatBase _seatBase) => _seatUpdaterMessage.AddSeatBaseList(_seatBase);
    IReadOnlyList<SeatBase> GetSeatList()=>_seatUpdaterMessage.GetSeatBases();  
}