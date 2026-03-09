using System;
using UnityEngine;
using static SeatDataEventHub;
/// <summary>
/// Seatに関する総合的なアクセッサー
/// </summary>
public class SeatProvider  :IDisposable
{
    SeatApplicationProvider _applicationProvider;
    SeatLogicProvider _logicProvider;
    SeatData _seatData;
    SeatRunTimeData _seatRunTimeData;
    SeatSpawnData _seatSpawnData;
	SeatEventOrderer _seatEventOrderer;
    Transform _seatTransform;
    public SeatProvider(GameObject _seatObj, SeatData _seatData, SeatSpawnData _thisSeatSpawnData)
    {
        _seatTransform=_seatObj.transform;
        _seatRunTimeData=new SeatRunTimeData();
        _applicationProvider = new SeatApplicationProvider(_seatObj);
        _logicProvider = new SeatLogicProvider(_seatObj.transform);
        _seatEventOrderer = new SeatEventOrderer();

        this._seatData = _seatData;
        this._seatSpawnData = _thisSeatSpawnData;
        _seatRunTimeData.SeatTransform= _applicationProvider.GetApplication().GetAiTransform();

    }

    public void EventOderUpdate() => _seatEventOrderer.UpdateSelectSeat(_seatTransform, _seatData, _seatRunTimeData);

    /// <summary>
    /// アプリケーションのゲッター
    /// </summary>
    /// <returns></returns>
    public SeatApplicationProvider GetApplication() => _applicationProvider;

    /// <summary>
    /// ロジックのゲッター
    /// </summary>
    /// <returns></returns>
    public SeatLogicProvider GetSeatLogickProvider() => _logicProvider;

    /// <summary>
    /// 静的データのゲッター
    /// </summary>
    /// <returns></returns>
    public SeatData GetSeatData() => _seatData;
    public SeatSpawnData GetSeatSpawnData() => _seatSpawnData;

	/// <summary>
	/// イベントの破棄
	/// </summary>
	public void Dispose()
    {

        _logicProvider.Dispose();
        _seatEventOrderer.Dispose();

    }



}