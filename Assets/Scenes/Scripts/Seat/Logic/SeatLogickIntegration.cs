
using System;
using UnityEngine;
/// <summary>
/// ロジックを集約させる
/// </summary>
public class SeatLogickIntegration:IDisposable
{

    Transform _seatTransform;
    SeatChildBinder _seatChildBinder;
    /// <summary>
    /// 初期化
    /// </summary>
    public SeatLogickIntegration(Transform _aiTransform)
    {
        this._seatTransform = _aiTransform;
        _seatChildBinder=new SeatChildBinder(_seatTransform);
    }
    public void ChildBinder()=> _seatChildBinder.ChildBinder();
    public void ResetParent()=> _seatChildBinder.ResetParent();

	public void Dispose()
    {
        _seatChildBinder.Dispose();
    }
}