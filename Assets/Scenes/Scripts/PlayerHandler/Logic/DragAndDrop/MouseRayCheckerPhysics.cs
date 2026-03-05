using UnityEngine;

public class MouseRayCheckerPhysics
{
    readonly Camera _camera;
    readonly LayerMask _hitLayer;

    Vector3 mousePos;
    Ray ray;
    public MouseRayCheckerPhysics()
    {
        _camera = Camera.main;

        // "Ai" レイヤーだけに当たるように LayerMask を作成
        _hitLayer = 1 << LayerMask.NameToLayer("Ai");
    }

    /// <summary>
    /// マウス位置からレイを飛ばしてヒットした Transform を返す
    /// </summary>
    public Transform GetHitTransform()
    {
        mousePos = Input.mousePosition;
        ray = _camera.ScreenPointToRay(mousePos);

        // デバッグ用：Sceneビューで赤線
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        // Ai レイヤーだけを対象に Raycast
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _hitLayer, QueryTriggerInteraction.Collide))
        {
            // 緑線でヒット可視化
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            return hit.transform;
        }

        return null;
    }

    public bool GetIsRayHit()
    {
        return GetHitTransform() != null;
    }

    
}