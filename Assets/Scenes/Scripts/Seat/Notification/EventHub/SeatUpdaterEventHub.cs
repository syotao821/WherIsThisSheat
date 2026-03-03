using System.Collections.Generic;


public class SeatUpdaterEventHub
{
    public delegate void OnAddSeatBaseList(SeatBase _seatBase);
    public static event OnAddSeatBaseList _onAddSeatBaseList;

    public void RaiseOnSeatParent(SeatBase _seatBase)
    {
        _onAddSeatBaseList.Invoke(_seatBase);
    }



}