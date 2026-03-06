using System;
using UnityEngine;

public class ToSeatEventListener : IDisposable
{
    ToSearEventMessage _toSeatEeventMessage;

    public Func<Transform> _toSeatEventCallback;
    public ToSeatEventListener()
    {
        _toSeatEeventMessage = new ToSearEventMessage();
        RayEventHub._onSeatRayFire += SetTargetTransform;

        _toSeatEventCallback = GetTargetTransform;
    }

    public void Dispose()
    {
        RayEventHub._onSeatRayFire -= SetTargetTransform;

    }

    void SetTargetTransform(Transform _targetTransform) => _toSeatEeventMessage.SetTargetTransform(_targetTransform);

    Transform GetTargetTransform() => _toSeatEeventMessage.GetTargetTransform();
}