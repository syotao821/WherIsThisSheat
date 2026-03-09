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

    public void UpdateSelectSeat(Transform _targetTransform, SeatData _seatData,SeatRunTimeData _seatRunTimeData )
    {
        this._targetTransform = _toSeatEventListener._toSeatEventCallback.Invoke();

        if (this._targetTransform==_targetTransform)
        {

            _seatDataEventHub.RaiseOnSeatData(_seatData);
            _seatDataEventHub.RaiseOnSeatRunTimeData(_seatRunTimeData);
            UnityEngine.Debug.Log(_seatRunTimeData);

        }
    }


    public void Dispose()
    {
        _toSeatEventListener.Dispose();
    }

}