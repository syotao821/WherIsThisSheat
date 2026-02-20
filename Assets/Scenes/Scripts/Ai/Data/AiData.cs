using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AiData
{
    [Header("ID")]
    [SerializeField] int _id;

    [Header("名前")]
    [SerializeField] string _name;

    [Header("モデル(Addressables Key)")]
    [SerializeField] string _viewModelName;

    [Header("満足する席ID")]
    [SerializeField] int _pairSeatId;

    [Header("詳細スプライト(Addressables Key)")]
    [SerializeField] string _viewSpriteName;

    [Header("詳細情報")]
    [SerializeField] List<string> _informationStringList;

    // ランタイム注入
    GameObject _viewModel;
    Sprite _viewSprite;

    // ===== property =====

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string ViewModelName { get => _viewModelName; set => _viewModelName = value; }
    public int PairSeatId { get => _pairSeatId; set => _pairSeatId = value; }
    public string ViewSpriteNmae { get => _viewSpriteName; set => _viewSpriteName = value; }
    public List<string> InformationStringList { get => _informationStringList; set => _informationStringList = value; }

    public GameObject ViewModel /*{ get => _viewModel; set => _viewModel = value; }*/;
    public Sprite ViewSprite ;
}
