using Cinemachine;
using UnityEngine;

public sealed class CameraShake : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private CinemachineImpulseSource _impulseSource;
    [SerializeField] private float _shakeForceBuff;
    [SerializeField] private float _minimalShake = 0.6f;

    private bool _previousIsGrounded;
    private bool _currentIsGrounded;
    private float _shakeForce = 0f;

    private void FixedUpdate()
    {
        _previousIsGrounded = _currentIsGrounded;
        _currentIsGrounded = _playerMovement.GetIsGrounded();

        if (_previousIsGrounded == false &&  _currentIsGrounded == false)
        {
            _shakeForce += _shakeForceBuff;
        }

        else if (_previousIsGrounded == false && _currentIsGrounded == true)
        {
            if (_shakeForce > _minimalShake)
            {
                _impulseSource.GenerateImpulseWithForce(_shakeForce);
            }

            _shakeForce = 0f;
        }
    }
}
