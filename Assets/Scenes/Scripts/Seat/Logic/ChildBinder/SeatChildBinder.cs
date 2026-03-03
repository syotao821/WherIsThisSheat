using UnityEngine;

public class SeatChildBinder: SeatParentReceiverListener
{
    Transform _seatTransform;
    public SeatChildBinder(Transform _seatTransform)
    {
        this._seatTransform = _seatTransform;
    }

    public void ChildBinder()
    {
        _seatTransform.SetParent(_parentTransform, false);
    }

    public override void Dispose()
    {
      base.Dispose();
    }

}