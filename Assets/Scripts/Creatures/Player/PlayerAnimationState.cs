using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerAttack))]
public sealed class PlayerAnimationState : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        ChangeState();
    }
    private void ChangeState()
    {
        _animator.SetBool("IsAttacking", _playerAttack.IsAttacking);

        if (_playerAttack.IsAttacking == true)
        {
            return;
        }

        _animator.SetFloat("VerticalSpeed", _playerMovement.GetVerticalSpeed());

        if (_playerMovement.GetIsGrounded())
        {
            _animator.SetFloat("HorizontalSpeed", _playerMovement.GetHorizontalSpeed());
        }
        else
        {
            _animator.SetFloat("HorizontalSpeed", 0);
        }
    }
}
