using UnityEngine;
public class SeatGenerator : SpawnGenerator<SeatBase>, IGameInit
{
    public int InitOrder =>4;

    [SerializeField] LoadSeatData _loadSeatData;

    SeatUpdaterListenr _seatUpdaterListenr;
    SeatUpdaterEventHub _seatUpdaterEventHub;
    public void GameInit()
    {
        _seatUpdaterEventHub=new SeatUpdaterEventHub();
        _seatUpdaterListenr=new SeatUpdaterListenr();

        SeatDiContainer.Inject(_seatUpdaterListenr);

        foreach (SeatSpawnData spawnData in _loadSeatData.SeatSpawnDataBase._seatSpawnDataArray)
        {
            foreach (StandardSeat standardSeat in spawnData.StandardSeatList)
            {
                (GameObject _seatObj, SeatBase _seatBase) =
                    CreateNew
                    (
                        _loadSeatData.SeatDataBase._seatDataArray[standardSeat.StandardId].ViewModel,
                        spawnData.SpawnPos + standardSeat.SpawnOffset,
                        Quaternion.identity, 
                        seatObj => new SeatBase(seatObj, _loadSeatData.SeatDataBase._seatDataArray[standardSeat.StandardId], spawnData)
                    );
                _seatUpdaterEventHub.RaiseOnSeatParent(_seatBase);


            }

        }
    }

    void OnDestroy()
    {
        _seatUpdaterListenr.Dispose();
    }
}