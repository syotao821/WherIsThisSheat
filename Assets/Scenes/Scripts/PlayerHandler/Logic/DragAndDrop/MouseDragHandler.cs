using UnityEngine;

public class MouseDragHandler: SeatParentReceiverListener
{


    readonly Camera _camera;
    const float MAX_DISTANCE = 5.0f;
    const float Hit_DISTANCE = 0.01f;
    float radius =0.5f;
    Plane _movePlane;
    Transform _draggedObject;
    Transform _rayHitTransform;
    Vector3 _hitPoint;
    Vector3 _startPos;
    float _distance;
    float _seatDistance;
    Ray ray;
    Transform seat;
    RaycastHit _hit;
    AiReceiverImpl _aiReceiverImpl;
    SeatReceiverImpl _seatReceiverImpl;
    // 子付け対象のレイヤー
    readonly LayerMask _attachLayer;

    public MouseDragHandler()
    {
        _camera = Camera.main;
        _movePlane = new Plane(Vector3.up, Vector3.zero);
        _attachLayer = 1 << LayerMask.NameToLayer("Seat");
        _aiReceiverImpl=new AiReceiverImpl();
        _seatReceiverImpl=new SeatReceiverImpl();

    }

    /// <summary>
    /// ドラッグ開始
    /// </summary>
    public void StartDrag(Transform obj)
    {
        _draggedObject = obj;
        _startPos= _draggedObject.position;
        _getParentTransform = GetParentTransform;
        _parentTransform = _getParentTransform.Invoke();
        _aiReceiverImpl.GetData();
        _seatReceiverImpl.GetData();
    }

    /// <summary>
    /// ドラッグ中
    /// </summary>
    public void UpdateDrag()
    {
        if (_draggedObject == null) return;

        ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (_movePlane.Raycast(ray, out float enter))
        {
            _hitPoint = ray.GetPoint(enter);
            _draggedObject.position = _hitPoint;
        }

        if (Physics.SphereCast(ray, radius, out _hit, Mathf.Infinity, _attachLayer))
        {
            _aiReceiverImpl.GetData();
            _seatReceiverImpl.GetData();
           

            _draggedObject.position = _hit.transform.position;

            _rayHitTransform = _hit.transform;

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.blue);


            if (_aiReceiverImpl._aiRunTimeData != null)
            {
                if (_seatReceiverImpl._seatData.PairAiId == _aiReceiverImpl._aiData.PairSeatId)
                    _aiReceiverImpl._aiRunTimeData.IsCustomerSatisfied = true;

                else
                    _aiReceiverImpl._aiRunTimeData.IsCustomerSatisfied = false;

            }
          

        }
    }

    public Transform GetSeatTransform()
    {
            return _rayHitTransform;
    }

    /// <summary>
    /// ドラッグ終了
    /// </summary>
    public void EndDrag()
    {
        if (_draggedObject == null) return;

        _distance = Vector3.Distance(_parentTransform.position, _draggedObject.position);

        if (_distance >= MAX_DISTANCE)
        {
            _draggedObject.position = _startPos;
        }

        if (_seatReceiverImpl._seatRunTimeData != null && _rayHitTransform != null)
        {
            // 席との距離
            _seatDistance = Vector3.Distance(_seatReceiverImpl._seatRunTimeData.SeatTransform.position, _draggedObject.position);

            if (_seatDistance < Hit_DISTANCE)
            {
                seat = _seatReceiverImpl._seatRunTimeData.SeatTransform;

                // 席が空いているかチェック
                if (seat.childCount == 0)
                {
                    _draggedObject.position = seat.position;
                    _draggedObject.SetParent(seat);
                    _seatReceiverImpl._seatRunTimeData.ToBeSat = true;
                }
                else
                {
                    // すでに座っている
                    _draggedObject.position = _startPos;
                    _draggedObject.SetParent(null);
                }
            }
            else
            {
                ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out _hit))
                {
                    _draggedObject.position = _hit.point;
                    if (_draggedObject.parent == _seatReceiverImpl._seatRunTimeData.SeatTransform)
                    {
                        _draggedObject.SetParent(_seatReceiverImpl._seatRunTimeData.SeatTransform.parent);
                    }
                   
                    _seatReceiverImpl._seatRunTimeData.ToBeSat = false;
                }

            }

            _draggedObject = null;
            _startPos = Vector3.zero;
        }
    }
    /// <summary>
    /// 現在ドラッグ中か
    /// </summary>
    public bool IsDragging()
    {
        return _draggedObject != null;
    }

    public override void Dispose()
    {
         base.Dispose();
        _aiReceiverImpl.OverRideDispose();
        _seatReceiverImpl.Dispose();
    }

}