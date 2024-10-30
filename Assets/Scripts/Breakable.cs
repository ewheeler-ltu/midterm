using UnityEngine;

public class Breakable : MonoBehaviour {

    public Player player;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Player") && player.max) {
            Destroy(gameObject);
        }
    }
}
