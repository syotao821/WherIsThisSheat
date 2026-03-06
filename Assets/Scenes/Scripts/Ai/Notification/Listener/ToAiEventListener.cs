using System;
using UnityEngine;

public class ToAiEventListener: IDisposable
{
    ToAiEventMessage _toAieventMessage;

   public Func<Transform> _toAiEventCallback;
    public ToAiEventListener()
    {
        _toAieventMessage = new ToAiEventMessage();
        RayEventHub._onAiRayFire += SetTargetTransform;

        _toAiEventCallback = GetTargetTransform;
    }

    public void Dispose()
    {
        RayEventHub._onAiRayFire -= SetTargetTransform;

    }

    void SetTargetTransform(Transform _targetTransform) => _toAieventMessage.SetTargetTransform(_targetTransform);

    Transform GetTargetTransform() => _toAieventMessage.GetTargetTransform();
}