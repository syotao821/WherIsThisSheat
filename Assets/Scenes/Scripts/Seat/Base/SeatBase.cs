using UnityEngine;

public class SeatBase
{
    [SerializeField] LoadAiData loadAiData;

    public SeatBase(GameObject _thisObj,SeatData _thisSeatData)
    {
        Debug.Log("席初期化完了");
    }
}