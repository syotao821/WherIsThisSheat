using System;
using UnityEngine;

/// <summary>
/// CSV設定に基づいてオブジェクト生成を行うジェネレータ基底
/// </summary>
public abstract class SpawnGenerator<T> : MonoBehaviour where T : class
{
    ObjectPool pool = new ObjectPool();

    protected virtual (GameObject obj, T logic) CreateNew(GameObject prefab,Vector3 position,Quaternion rotation, Func<GameObject, T> logicFactory) 
    {
        GameObject obj = pool.Get(prefab, position, rotation);

        // 呼び出し側に生成を委譲
        T instance = logicFactory(obj);

        return (obj, instance);
    }
}