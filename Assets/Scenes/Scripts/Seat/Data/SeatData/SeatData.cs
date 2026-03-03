
using UnityEngine;

[System.Serializable]
public struct SeatData 
{
    [Header("ID")]
    [SerializeField] int _id;

    [Header("名前")]
    [SerializeField] string _name;

    [Header("モデル(Addressables Key)")]
    [SerializeField] string _viewModelName;

    [Header("満足する席ID")]
    [SerializeField] int _pairSeatId;

    // ランタイム注入
    GameObject _viewModel;

    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }
    public string ViewModelName { get => _viewModelName; set => _viewModelName = value; }
    public int PairSeatId { get => _pairSeatId; set => _pairSeatId = value; }
    public GameObject ViewModel { get => _viewModel; set => _viewModel = value; }

}
