using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject target;
    public float speed;

    void Start() {  }

    void Update() {
        Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
