using UnityEngine;

public static class RayEventHub
{
    public static event OnRayFire _onRayFire;
    public delegate void OnRayFire(Transform _targetTransform);

 
    public static void RaiseOnRayFire(Transform _targetTransform)
    {
        _onRayFire?.Invoke(_targetTransform);
    }

   
}