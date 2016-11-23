using UnityEngine;
using System.Collections;

public class ProjectileEnemy : MonoBehaviour {
    public int dMG;
    public float speed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player") {
            col.GetComponent<IDamageable>().ReceiveHit(dMG);
            Destroy(gameObject);
        }
    }
}
