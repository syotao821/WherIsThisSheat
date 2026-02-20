using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

public static class AiDataLoader
{
    /// <summary>
    /// AiDataBase内のアセットを全部ロード
    /// </summary>
    public static async UniTask LoadAllAsync(AiDataBase database)
    {
        if (database == null || database.aiDataArray == null)
        {
            Debug.LogError("AiDataBase が null");
            return;
        }

        AiData[] array = database.aiDataArray;

        for (int i = 0; i < array.Length; i++)
        {
            AiData ai = array[i];

            // ---------- Prefab ----------
            if (!string.IsNullOrEmpty(ai.ViewModelName))
            {
                var handle =
                    Addressables.LoadAssetAsync<GameObject>(ai.ViewModelName);

                ai.ViewModel = await handle.ToUniTask();
            }

            // ---------- Sprite ----------
            if (!string.IsNullOrEmpty(ai.ViewSpriteNmae))
            {
                var handle =
                    Addressables.LoadAssetAsync<Sprite>(ai.ViewSpriteNmae);

                ai.ViewSprite = await handle.ToUniTask();
            }

            //  structなので必ず戻す
            array[i] = ai;
        }

        database.aiDataArray = array;

        Debug.Log("AiData Addressables Load 完了");
    }
}
