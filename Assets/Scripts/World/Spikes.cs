using UnityEngine;
public sealed class Spikes : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _playerForce = 140f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Creature creature = collision.gameObject.GetComponent<Creature>();
        if (creature != null)
        {
            creature.GetDamage(_damage);

            if (collision.gameObject.CompareTag("Player"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

                rb.velocity = new Vector2(rb.velocity.x, _playerForce);
            }
        }
    }
}
