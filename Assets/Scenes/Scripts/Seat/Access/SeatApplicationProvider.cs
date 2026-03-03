using UnityEngine;
/// <summary>
/// アプリケーションのアクセッサー
/// </summary>
public class SeatApplicationProvider
{
    SeatApplicationIntegration _seatApplicationIntegration;


    public SeatApplicationProvider(GameObject thisObj)
    {
        _seatApplicationIntegration = new SeatApplicationIntegration(thisObj);
    }

    public SeatApplicationIntegration GetApplication()
    {
        return _seatApplicationIntegration;
    }

}