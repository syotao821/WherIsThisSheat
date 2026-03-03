

using UnityEngine;

public class BussChildSet
{
    SeatParentReceiverEventHub _seatParentReceiverEventHub;
    Transform _bussTrans;
    public BussChildSet(Transform _bussTrans)
    {
        this._bussTrans = _bussTrans;

        _seatParentReceiverEventHub = new SeatParentReceiverEventHub();
        _seatParentReceiverEventHub.RaiseOnSeatParent(this._bussTrans);
        UnityEngine.Debug.Log(2);

    }

}
