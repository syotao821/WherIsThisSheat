using UnityEngine;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

public static class SeatDataLoader
{
    /// <summary>
    /// SeatDataBase内のアセットを全部ロード
    /// </summary>
    public static async UniTask LoadAllAsync(SeatDataBase database)
    {
        if (database == null || database._seatDataArray == null)
        {
            Debug.LogError("SeatDataBase が null");
            return;
        }

        SeatData[] array = database._seatDataArray;

        for (int i = 0; i < array.Length; i++)
        {
            SeatData seat = array[i];

            // ---------- Prefab ----------
            if (!string.IsNullOrEmpty(seat.ViewModelName))
            {
                var handle =
                    Addressables.LoadAssetAsync<GameObject>(seat.ViewModelName);

                seat.ViewModel = await handle.ToUniTask();
            }


            //  structなので必ず戻す
            array[i] = seat;
        }

        database._seatDataArray = array;

        Debug.Log("SeatDataBase Addressables Load 完了");
    }
}
