using System;
using UnityEngine;

public class SeatEventOrder : IDisposable
{
    SeatParentEventListener _seatPearentEventListener;
    SeatParentReceiverEventHub seatParentReceiverEventHub;

    Transform _getSeatPearentTransfom;
    public SeatEventOrder()
    {
        _seatPearentEventListener = new SeatParentEventListener();
        seatParentReceiverEventHub= new SeatParentReceiverEventHub();
        _getSeatPearentTransfom = _seatPearentEventListener._getParentTransform.Invoke();
        seatParentReceiverEventHub.RaiseOnSeatParent(_getSeatPearentTransfom);
    }

    public void Dispose()
    {
        _seatPearentEventListener.Dispose();
    }


}