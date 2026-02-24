using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour不要・複数種類対応ObjectPool
/// prefab参照で自動識別
/// </summary>
public class ObjectPool
{
    // prefab → プール
    Dictionary<GameObject, List<GameObject>> pools = new();
    List<GameObject>  pool = new List<GameObject>();
    GameObject newObj;
    /// <summary>
    /// 取得
    /// </summary>
    public GameObject Get(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // 未登録なら自動作成
        if (!pools.ContainsKey(prefab))
        {
            pools[prefab] = new List<GameObject>();
        }

        pool = pools[prefab];

        // 空きを探す
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.transform.SetPositionAndRotation(position, rotation);
                obj.SetActive(true);
                return obj;
            }
        }

        // 無ければ新規生成（←ここが重要：要求されたprefabで生成）
        newObj = Object.Instantiate(prefab);
        newObj.SetActive(false);
        pool.Add(newObj);

        newObj.transform.SetPositionAndRotation(position, rotation);
        newObj.SetActive(true);
        return newObj;
    }

    /// <summary>
    /// 返却
    /// </summary>
    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}