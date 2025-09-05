using UnityEngine;
using DG.Tweening;
public class ElectricOrbMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _duration = 2f;

    private void Start()
    {
        gameObject.transform.DOKill();

        Vector3[] path = { _pointA.position, _pointB.position };

        transform.DOPath(path, _duration, PathType.Linear, PathMode.Ignore)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetLink(gameObject);
    }
}