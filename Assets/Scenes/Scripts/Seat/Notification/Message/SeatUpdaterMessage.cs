using System.Collections.Generic;

public class SeatUpdaterMessage
{

    List<SeatBase> _seatBaseList = new List<SeatBase>();


    public void AddSeatBaseList(SeatBase _seatBase)
    {
        _seatBaseList.Add(_seatBase);
    }

    public IReadOnlyList<SeatBase> GetSeatBases() => _seatBaseList;


}