using System;
using UnityEngine;

public class SeatEventOrderer : IDisposable
{

    Transform _targetTransform;
    ToSeatEventListener _toSeatEventListener;
    SeatDataEventHub _seatDataEventHub;
    public SeatEventOrderer()
    {
        _toSeatEventListener = new ToSeatEventListener();
        _seatDataEventHub=new SeatDataEventHub();
    }

    public void UpdateSelectSeat(Transform _targetTransform, SeatData _seatData)
    {
        this._targetTransform = _toSeatEventListener._toSeatEventCallback.Invoke();

        if (this._targetTransform==_targetTransform)
        {

            _seatDataEventHub.RaiseOnSeatData(_seatData);
            

        }
    }


    public void Dispose()
    {
        _toSeatEventListener.Dispose();
    }

}