using UnityEngine;

public sealed class Coin : MonoBehaviour
{
    const int Value = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBalance balance))
        {
            balance.IncreaseMoney(Value);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
