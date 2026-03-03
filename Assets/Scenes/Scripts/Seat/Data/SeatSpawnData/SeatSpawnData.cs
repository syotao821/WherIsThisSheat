
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct StandardSeat
{
    [Header("単体ID(どのSeatが生成されるか決定)")]
    [SerializeField] int _standardId;
    [Header("生成中心点からどれだけ離れるか？")]
    [SerializeField] Vector3 _spawnOffset;

    public int StandardId { get => _standardId; set => _standardId = value; }
    public Vector3 SpawnOffset { get => _spawnOffset; set => _spawnOffset = value; }
}

[System.Serializable]
public struct SeatSpawnData
{
    [Header("グループ")]
    [SerializeField] int _groupId;
    [Header("生成位置")]
    [SerializeField] Vector3 spawnPos;
    [Header("単体設定")]
    [SerializeField] List<StandardSeat> _standardSeatList;

    public int GroupId { get => _groupId; set => _groupId = value; }
    public Vector3 SpawnPos { get => spawnPos; set => spawnPos = value; }
    public List<StandardSeat> StandardSeatList { get => _standardSeatList; set => _standardSeatList = value; }
}
