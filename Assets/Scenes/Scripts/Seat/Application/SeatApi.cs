using UnityEngine;
public class SeatApi
{
    Transform _seatTransfom;
    Animator _seatAnimator;

    public Transform SeatTransfom { get => _seatTransfom; set => _seatTransfom = value; }
    public Animator SeatAnimator { get => _seatAnimator; set => _seatAnimator = value; }
}