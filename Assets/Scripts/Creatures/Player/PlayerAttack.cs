using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; } = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            IsAttacking = true;
        }
        else
        {
            IsAttacking = false;
        }
    }
}
