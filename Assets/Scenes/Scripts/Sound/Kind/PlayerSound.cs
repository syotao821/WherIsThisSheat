/// <summary>
/// プレイヤーの効果音を管理するサウンドマネージャークラス。
/// SoundManager を継承し、シングルトンパターンでインスタンスを提供する。
/// </summary>
public class PlayerSound:SoundManager
{
    /// <summary>
    /// グローバルアクセス用のシングルトンインスタンス。
    /// </summary>
    public static PlayerSound Instance { get; private set; }

    /// <summary>
    /// Awake時にベースクラスの初期化を呼び出し、自身をインスタンスとして登録する。
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}