

using UnityEngine;

public class ToAiEventMessage
{

    Transform _targetTransform;

    public void SetTargetTransform(Transform _targetTransform) => this._targetTransform = _targetTransform;

    public Transform GetTargetTransform() => _targetTransform;
}