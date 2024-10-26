using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("isRunning");
    private readonly int IsDeadTrigger = Animator.StringToHash("IsDead");

    [SerializeField] private Animator _animator;

    public void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }

    public void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    public void ChangeAnimationLayer(int weight)
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Hit"), weight);
    }

    public void PlayDeadAnimation()
    {
        _animator.SetTrigger(IsDeadTrigger);
    }
}
