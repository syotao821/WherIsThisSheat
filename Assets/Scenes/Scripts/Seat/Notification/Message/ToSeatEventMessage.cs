

using UnityEngine;

public class ToSearEventMessage
{

    Transform _targetTransform;

    public void SetTargetTransform(Transform _targetTransform) => this._targetTransform = _targetTransform;

    public Transform GetTargetTransform() => _targetTransform;
}