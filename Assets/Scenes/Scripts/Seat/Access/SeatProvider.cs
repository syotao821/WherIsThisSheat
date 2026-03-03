using System;
using UnityEngine;
/// <summary>
/// Seatに関する総合的なアクセッサー
/// </summary>
public class SeatProvider  :IDisposable
{
    SeatApplicationProvider _applicationProvider;
    SeatLogicProvider _logicProvider;
    SeatData _seatData;
    SeatEventOrder _seatEventOrder;
    public SeatProvider(GameObject _aiObj, SeatData _aiData)
    {
        _applicationProvider = new SeatApplicationProvider(_aiObj);
        _logicProvider = new SeatLogicProvider(_aiObj.transform);
        this._seatData = _aiData;
        _seatEventOrder=new SeatEventOrder();
    }


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

    /// <summary>
    /// イベントの破棄
    /// </summary>
    public void Dispose()
    {

        _seatEventOrder.Dispose();
        _logicProvider.Dispose();

    } 
    

     
}