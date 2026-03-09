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
        _getParentTransform = GetParentTransform;
        _parentTransform = _getParentTransform.Invoke();

        _seatTransform.SetParent(_parentTransform, true);
    }

    public void ResetParent()
    {
        _seatTransform.transform.parent = null;
	}

	public override void Dispose()
    {
      base.Dispose();
    }

}