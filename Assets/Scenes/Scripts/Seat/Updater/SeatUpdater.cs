using UnityEngine;
using System.Collections.Generic;
public class SeatUpdater : MonoBehaviour, IGameInit
{

    SeatUpdaterListenr _seatUpdaterEventListener;
    IReadOnlyList<SeatBase> _updaterSeatBaseList;
    public int InitOrder => 3;

    public void GameInit()
    {
        SeatDiContainer.Register(this);
    }

    void Start()
    {
        if (_updaterSeatBaseList == null)
            _updaterSeatBaseList = _seatUpdaterEventListener._getSeatList.Invoke();

        foreach (SeatBase _seatBase in _updaterSeatBaseList)
        {
            _seatBase.Start();
        }
    }

    public void InitDI(SeatUpdaterListenr _aiUpdaterEventListener)
    {
        this._seatUpdaterEventListener = _aiUpdaterEventListener;
    }
    private void Update()
    {
        foreach (SeatBase _seatBase in _updaterSeatBaseList)
        {
            _seatBase.Update();
        }
    }

    void OnDestroy()
    {
        foreach (SeatBase SeatBase in _updaterSeatBaseList)
        {
            SeatBase.Dispose();
        }
    }
}