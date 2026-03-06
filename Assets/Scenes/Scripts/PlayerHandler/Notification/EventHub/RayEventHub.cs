using UnityEngine;

public  class RayEventHub
{
    public static event OnAiRayFire _onAiRayFire;
    public delegate void OnAiRayFire(Transform _targetTransform);

    public static event OnSeatRayFire _onSeatRayFire;
    public delegate void OnSeatRayFire(Transform _targetTransform);


   

    public  void RaiseOnAiRayFire(Transform _targetTransform)
    {
        _onAiRayFire?.Invoke(_targetTransform);
    }

    public  void RaiseOnSeatRayFire(Transform _targetTransform)
    {
        _onSeatRayFire?.Invoke(_targetTransform);
    }

}