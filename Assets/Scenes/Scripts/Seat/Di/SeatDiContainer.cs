
public class SeatDiContainer
{
    static SeatUpdater _seatUpdater;

    //MonoBehaviour 自己登録
    public static void Register(SeatUpdater updater)
    {
        _seatUpdater = updater;
    }

    // 注入
    public static void Inject(SeatUpdaterListenr listener)
    {
        if (_seatUpdater == null)
        {
            UnityEngine.Debug.LogError("SeatUpdaterが存在しません.");
            return;
        }

        _seatUpdater.InitDI(listener);
    }

}