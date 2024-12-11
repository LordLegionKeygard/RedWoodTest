using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public void SetBoolAnimation(int animation, bool state)
    {
        _animator.SetBool(animation, state);
    }

    public void SetDirection(Vector2 direction)
    {
        if(direction.x < 0) 
        {
            _spriteRenderer.flipX = true;
        }
        else if(direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
