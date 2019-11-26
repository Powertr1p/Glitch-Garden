using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        FindObjectOfType<PlayerLivesDisplay>().TakeLife();
    }
}
