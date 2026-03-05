using System;
using UnityEngine;

public abstract class SeatParentReceiverListener : IDisposable
{

    SeatParentReceiverMessage _seatParentReceiverMessage;
    protected Func<Transform> _getParentTransform;
    protected Transform _parentTransform;
    bool _disposed;

    public SeatParentReceiverListener()
    {
        _seatParentReceiverMessage = new SeatParentReceiverMessage();
        SeatParentReceiverEventHub._onSeatPearentReceiver += SetParentTransform;

        _getParentTransform = GetParentTransform;
        _parentTransform = _getParentTransform.Invoke();
        //UnityEngine.Debug.Log(1);
    }

    public virtual void Dispose()
    {
        if (_disposed) return;
        SeatParentReceiverEventHub._onSeatPearentReceiver -= SetParentTransform;
        _disposed = true;
    }


    void SetParentTransform(Transform _parentTransform) => _seatParentReceiverMessage.SetParentTransform(_parentTransform);
    protected Transform GetParentTransform() => _seatParentReceiverMessage.GetParentTransform();
}