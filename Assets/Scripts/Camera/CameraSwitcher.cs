using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] GameObject _activeFrame;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            _activeFrame.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            _activeFrame.SetActive(false);
        }
    }
}
