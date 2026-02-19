using UnityEngine;
/// <summary>
/// Input関係
/// </summary>
public class PlayerHandlerInput
{

    /// <summary>
    /// !Input.GetMouseButton(0);
    /// </summary>
    /// <returns></returns>
    public bool InputSearchingAi() => !Input.GetMouseButton(0);

    /// <summary>
    /// Input.GetMouseButtonDown(0)
    /// </summary>
    /// <returns></returns>
    public bool InputHoldingAi() => Input.GetMouseButtonDown(0);

    /// <summary>
    /// Input.GetMouseButton(0)
    /// </summary>
    /// <returns></returns>
    public bool InputCarryingAi() => Input.GetMouseButton(0);

    /// <summary>
    ///Input.GetMouseButtonUp(0)
    /// </summary>
    /// <returns></returns>
    public bool InputTalkingAi() => Input.GetMouseButtonUp(0);



}