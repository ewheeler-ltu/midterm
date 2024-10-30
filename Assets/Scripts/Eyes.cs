using UnityEngine;

public class eyes : MonoBehaviour {
    public Player body;
    public float xOffset;
    public float yOffset;

    void Start() {
        
    }

    void Update() {
        transform.position = new Vector3(body.transform.position.x + xOffset, body.transform.position.y + yOffset, body.transform.position.z);
    }
}
