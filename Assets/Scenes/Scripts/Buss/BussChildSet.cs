

using UnityEngine;

public class BussChildSet
{
    SeatParentReceiverEventHub _seatParentReceiverEventHub;
    AiParentReceiverEventHub _aiParentReceiverEventHub;
	Transform _bussTrans;
    public BussChildSet(Transform _bussTrans)
    {
        this._bussTrans = _bussTrans;

        _seatParentReceiverEventHub = new SeatParentReceiverEventHub();
        _seatParentReceiverEventHub.RaiseOnSeatParent(this._bussTrans);

		_aiParentReceiverEventHub = new AiParentReceiverEventHub();
        _aiParentReceiverEventHub.RaiseOnAiParent(this._bussTrans);


    }

}
