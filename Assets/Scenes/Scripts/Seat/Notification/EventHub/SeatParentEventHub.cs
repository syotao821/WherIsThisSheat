using UnityEngine;

public class SeatParentEventHub
{
    public delegate void OnSeatParent(Transform _parentTransform);
    public static event OnSeatParent _onSeatParent;

    public void RaiseOnSeatParent(Transform _parentTransform)
    {
        _onSeatParent?.Invoke(_parentTransform);
    }
}