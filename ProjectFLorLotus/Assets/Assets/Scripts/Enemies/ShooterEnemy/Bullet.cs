using UnityEngine;
using Drone;
public class Bullet : MonoBehaviour
{
    float ttl = 2f;

    private void FixedUpdate() {
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CommonPlayer>().health -= 10;
            Destroy(gameObject);
        }
    }
}