using UnityEngine;

[System.Serializable]

public struct LoadSeatData
{
    [SerializeField] SeatDataBase _seatDataBase;
    [SerializeField] SeatSpawnDataBase _seatSpawnDataBase;

    public SeatDataBase SeatDataBase { get => _seatDataBase; set => _seatDataBase = value; }
    public SeatSpawnDataBase SeatSpawnDataBase { get => _seatSpawnDataBase; set => _seatSpawnDataBase = value; }
}