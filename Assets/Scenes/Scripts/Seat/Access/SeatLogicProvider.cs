using System;
using UnityEngine;

/// <summary>
/// ロジックのアクセッサー
/// </summary>
public class SeatLogicProvider: IDisposable
{
    SeatLogickIntegration _seatLogickIntegration;

    public SeatLogicProvider(Transform _aiTransform)
    {
        _seatLogickIntegration = new SeatLogickIntegration(_aiTransform);
    }
    public SeatLogickIntegration GetSeatLogickIntegration() => _seatLogickIntegration;

    public void Dispose()=> _seatLogickIntegration.Dispose();
   

}