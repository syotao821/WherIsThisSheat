using System;
using UnityEngine;

public class SeatParentEventListener :IDisposable
{

    SeatPearentMessage _seatParentMessage;
    public Func<Transform> _getParentTransform;
    bool _disposed;

    public SeatParentEventListener()
    {
        _seatParentMessage= new SeatPearentMessage();
        SeatParentEventHub._onSeatParent += SetParentTransform;

        _getParentTransform = GetParentTransform;
    }

    public void Dispose()
    {
        if (_disposed) return;
        SeatParentEventHub._onSeatParent -= SetParentTransform;
        _disposed=true;
    }


    void SetParentTransform(Transform _parentTransform)=> _seatParentMessage.SetParentTransform(_parentTransform);
    public Transform GetParentTransform() =>_seatParentMessage.GetParentTransform();
}