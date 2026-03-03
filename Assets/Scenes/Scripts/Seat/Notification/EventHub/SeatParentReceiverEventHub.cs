using UnityEngine;

public class SeatParentReceiverEventHub
{

    public delegate void OnSeatPearentReceiver(Transform _parentTransform);
    public static event OnSeatPearentReceiver _onSeatPearentReceiver;
    public void RaiseOnSeatParent(Transform _parentTransform)
    {
        _onSeatPearentReceiver.Invoke(_parentTransform);
    }
}