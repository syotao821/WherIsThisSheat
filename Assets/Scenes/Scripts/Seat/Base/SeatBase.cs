using System;
using UnityEngine;

public class SeatBase:IDisposable
{
    SeatProvider _seatProvider;

    public SeatBase(GameObject _thisObj,SeatData _thisSeatData)
    {
        _seatProvider=new SeatProvider(_thisObj, _thisSeatData);
        _seatProvider.GetSeatLogickProvider().GetSeatLogickIntegration().ChildBinder();
        Debug.Log("席初期化完了");
    }

    public void Dispose()
    {
        _seatProvider.GetSeatLogickProvider().Dispose();
    }
}