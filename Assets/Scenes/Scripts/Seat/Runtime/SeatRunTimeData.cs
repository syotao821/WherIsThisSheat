using UnityEngine;
public class SeatRunTimeData
{
    bool _toBeSat;
    Transform _seatTransform;
    public bool ToBeSat { get => _toBeSat; set => _toBeSat = value; }
    public Transform SeatTransform { get => _seatTransform; set => _seatTransform = value; }
}