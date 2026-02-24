using UnityEngine;

/// <summary>
/// CSV設定に基づいてオブジェクト生成を行うジェネレータ基底
/// </summary>
public abstract class SpawnGenerator<T> : MonoBehaviour where T : class, new()
{
   static ObjectPool pool = new ObjectPool();
    GameObject obj;
    T instance;
    
    protected virtual (GameObject obj, T logic) CreateNew(GameObject prefab, Vector3 position,Quaternion rotation)
    {
        obj = pool.Get(prefab, position, rotation);

        // 純C#ロジック生成
        instance = new T();

        return (obj, instance);
    }


}