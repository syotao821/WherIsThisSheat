using UnityEngine;

[System.Serializable]

public struct LoadAiData
{
    [SerializeField] AiDataBase _aiDataBase;
    [SerializeField] AiSpawnDataBase _aiSpawnDataBase;

    public AiDataBase AiDataBase { get => _aiDataBase; set => _aiDataBase = value; }
    public AiSpawnDataBase AiSpawnDataBase { get => _aiSpawnDataBase; set => _aiSpawnDataBase = value; }
}