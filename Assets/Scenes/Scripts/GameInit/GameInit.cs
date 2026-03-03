using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 初期化の集約クラス
/// </summary>
public class GameInit : MonoBehaviour
{
    List<IGameInit> _initObjects = new List<IGameInit>();
    private void Awake()
    {
        _initObjects = 
            FindObjectsOfType<MonoBehaviour>(true).OfType<IGameInit>() .OrderBy(x => x.InitOrder).ToList();

        foreach (IGameInit obj in _initObjects)
        {
            obj.GameInit();
        }
    }
}
