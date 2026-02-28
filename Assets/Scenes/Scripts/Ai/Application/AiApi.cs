using UnityEngine;
public class AiApi
{
    Transform _aiTransform;
    Animator _aiAnimator;


    public Transform AiTransform { get => _aiTransform; set => _aiTransform = value; }
    public Animator AiAnimator { get => _aiAnimator; set => _aiAnimator = value; }
}