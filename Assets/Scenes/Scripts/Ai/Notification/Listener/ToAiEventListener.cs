using System;
using UnityEngine;

public class ToAiEventListener: IDisposable
{
    ToAiEventMessage _toAieventMessage;

   public Func<Transform> _toAiEventCallback;
    public ToAiEventListener()
    {
        _toAieventMessage = new ToAiEventMessage();
        RayEventHub._onRayFire += SetTargetTransform;

        _toAiEventCallback = GetTargetTransform;
    }

    public void Dispose()
    {
        RayEventHub._onRayFire -= SetTargetTransform;

    }

    void SetTargetTransform(Transform _targetTransform) => _toAieventMessage.SetTargetTransform(_targetTransform);

    Transform GetTargetTransform() => _toAieventMessage.GetTargetTransform();
}