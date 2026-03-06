/// <summary>
/// AI個別の動的データ
/// </summary>
public class AiRunTimeData
{
    bool _isCustomerSatisfied;
    bool _isSeated;
    public bool IsCustomerSatisfied { get => _isCustomerSatisfied; set => _isCustomerSatisfied = value; }
    public bool IsSeated { get => _isSeated; set => _isSeated = value; }
}