using UnityEngine;
/// <summary>
/// AIの基本処理　（井町さんが触る場所）
/// </summary>
public class AiBase 
{
    AiProvider _aiProvider;

    public AiBase(GameObject thisObj)
    {
        _aiProvider = new AiProvider(thisObj);


    }

    public void Update()
    {

    }

}