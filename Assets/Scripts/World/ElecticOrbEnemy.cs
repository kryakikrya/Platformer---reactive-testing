using UnityEngine;

public class ElecticOrbEnemy : MonoBehaviour
{

    [SerializeField] private int _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Creature creature))
        {
            creature.GetDamage(_damage);
        }
    }
}
