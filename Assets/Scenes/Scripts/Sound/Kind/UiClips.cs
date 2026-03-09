
/// <summary>
/// UI関連の効果音クリップを管理するクラス。
/// SceneSoundを継承し、シングルトンパターンでインスタンスを提供する。
/// </summary>
public class UiClips : SceneSound
{
    /// <summary>
    /// グローバルにアクセス可能なシングルトンインスタンス。
    /// </summary>
    public static UiClips Instance { get; private set; }

    /// <summary>
    /// Awake時に自身をインスタンスとして登録する。
    /// </summary>
    void Awake()
    {
        Instance = this;
    }
}