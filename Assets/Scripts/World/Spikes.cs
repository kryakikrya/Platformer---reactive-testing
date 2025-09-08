using UnityEngine;
public sealed class Spikes : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _playerForce = 140f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Creature creature))
        {
            creature.GetDamage(_damage);

            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = new Vector2(rb.velocity.x, _playerForce);
            }
        }
    }
}
