using UnityEngine;
public class SeatPearentMessage
{

    Transform _parentTransform;


    public void SetParentTransform(Transform _parentTransform)=>this._parentTransform = _parentTransform;

    public Transform GetParentTransform() => _parentTransform;



}