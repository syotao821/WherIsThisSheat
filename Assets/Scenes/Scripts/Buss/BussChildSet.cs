

using UnityEngine;

public class BussChildSet 
{
    SeatParentEventHub _seatPearentEventHub;
    Transform _bussTrans;
    public BussChildSet(Transform _bussTrans)
    {
        this._bussTrans = _bussTrans;
        _seatPearentEventHub=new SeatParentEventHub();
        _seatPearentEventHub.RaiseOnSeatParent(this._bussTrans);

    }

}
