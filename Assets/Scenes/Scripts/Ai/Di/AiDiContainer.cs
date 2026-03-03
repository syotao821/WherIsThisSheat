
public class AiDiContainer
{
    static AiUpdater _aiUpdater;

    //MonoBehaviour 自己登録
    public static void Register(AiUpdater updater)
    {
        _aiUpdater = updater;
    }

    // 注入
    public static void Inject(AiUpdaterEventListener listener)
    {
        if (_aiUpdater == null)
        {
            UnityEngine.Debug.LogError("AiUpdaterが存在しません.");
            return;
        }

        _aiUpdater.InitDI(listener);
    }

}