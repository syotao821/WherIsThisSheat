using UnityEngine;

public class MouseDragHandler
{
    readonly Camera _camera;
    Plane _movePlane;
    Transform _draggedObject;
    Vector3 hitPoint;
    Ray ray;

    // 子付け対象のレイヤー
    readonly LayerMask attachLayer;

    public MouseDragHandler()
    {
        _camera = Camera.main;
        _movePlane = new Plane(Vector3.up, Vector3.zero);
        attachLayer = 1 << LayerMask.NameToLayer("Seat");
    }

    /// <summary>
    /// ドラッグ開始
    /// </summary>
    public void StartDrag(Transform obj)
    {
        _draggedObject = obj;
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
            hitPoint = ray.GetPoint(enter);
            _draggedObject.position = hitPoint;
        }
    }

    /// <summary>
    /// ドラッグ終了
    /// </summary>
    public void EndDrag()
    {
        _draggedObject = null;
    }

    /// <summary>
    /// 現在ドラッグ中か
    /// </summary>
    public bool IsDragging()
    {
        return _draggedObject != null;
    }

    
}