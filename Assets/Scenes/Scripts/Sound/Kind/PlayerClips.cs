
/// <summary>
/// プレイヤー関連の効果音クリップを管理するクラス。
/// SceneSoundを継承し、シングルトンでインスタンスを提供する。
/// </summary>
public class PlayerClips:SceneSound
{
    /// <summary>
    /// グローバルアクセス用のシングルトンインスタンス。
    /// </summary>
    public static PlayerClips Instance { get; private set; }

    /// <summary>
    /// インスタンスの初期化処理。自身をシングルトンとして登録する。
    /// </summary>
    void Awake()
    {
        Instance = this;
    }
}