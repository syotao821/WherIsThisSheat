/// <summary>
/// UI関連の効果音を管理するシングルトンクラス
/// </summary>
public class UiSound : SoundManager
{

    public static UiSound Instance { get; private set; }

    /// <summary>
    /// 初期化処理。親クラスのAwakeを呼び出し、
    /// 自身のインスタンスをセットする。
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

}