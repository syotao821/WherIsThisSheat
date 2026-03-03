using System;
using UnityEngine;

public abstract class SeatParentReceiverListener : IDisposable
{

    SeatParentReceiverMessage _seatParentReceiverMessage;
    Func<Transform> _getParentTransform;
    protected Transform _parentTransform;
    bool _disposed;

    public SeatParentReceiverListener()
    {
        _seatParentReceiverMessage = new SeatParentReceiverMessage();
        SeatParentReceiverEventHub._onSeatPearentReceiver += SetParentTransform;

        _getParentTransform = GetParentTransform;
        _parentTransform = _getParentTransform.Invoke();
    }

    public virtual void Dispose()
    {
        if (_disposed) return;
        SeatParentReceiverEventHub._onSeatPearentReceiver -= SetParentTransform;
        _disposed = true;
    }


    void SetParentTransform(Transform _parentTransform) => _seatParentReceiverMessage.SetParentTransform(_parentTransform);
    public Transform GetParentTransform() => _seatParentReceiverMessage.GetParentTransform();
}