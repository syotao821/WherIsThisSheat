using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                {
                    Debug.LogError(typeof(T) + " をアタッチしていません");
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected void CheckInstance()
    {
        if (instance == null)
        {
            instance = this as T;
            return;
        }

        if (instance == this)
        {
            return;
        }

        Destroy(gameObject); // ← 重要修正
    }
}