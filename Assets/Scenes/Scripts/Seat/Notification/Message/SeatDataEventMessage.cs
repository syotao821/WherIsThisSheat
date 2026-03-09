public class SeatDataEventMessage
{

    SeatData _seatData;
    SeatRunTimeData _seatRuntimeData;

    public void SetSeatData(SeatData _seatData)=>this._seatData = _seatData;

    public SeatData GetSeatData()=>_seatData;
    public void SetSeatRuntimeData(SeatRunTimeData _seatRuntimeData) =>this._seatRuntimeData = _seatRuntimeData;

    public SeatRunTimeData GetSeatRuntimeData()=> _seatRuntimeData;

    
}