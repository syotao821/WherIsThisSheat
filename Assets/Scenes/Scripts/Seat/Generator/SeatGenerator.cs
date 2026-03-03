using UnityEngine;
public class SeatGenerator : SpawnGenerator<SeatBase>, IGameInit
{
    public int InitOrder =>4;

    [SerializeField] LoadSeatData _loadSeatData;
    public void GameInit()
    {
        foreach (SeatSpawnData spawnData in _loadSeatData.SeatSpawnDataBase._seatSpawnDataArray)
        {
            foreach (StandardSeat standardSeat in spawnData.StandardSeatList)
            {
                (GameObject _seatObj, SeatBase _seatBase) =
                    CreateNew(
                        _loadSeatData.SeatDataBase._seatDataArray[standardSeat.StandardId].ViewModel,
                        spawnData.SpawnPos + standardSeat.SpawnOffset,
                        Quaternion.identity, 
                        seatObj => new SeatBase(seatObj, _loadSeatData.SeatDataBase._seatDataArray[standardSeat.StandardId]));
            }

        }
    }
}