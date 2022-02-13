using UnityEngine;

public class Dumb : MonoBehaviour
{
    [SerializeField] private GameObject _boomlaPrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        Tatu tatu = other.collider.GetComponent<Tatu>();
        if(tatu != null){
            Instantiate(_boomlaPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Dumb dumb = other.collider.GetComponent<Dumb>();
        if (dumb != null){
            return;
        }

        if (other.contacts[0].normal.y < -0.5){
            Instantiate(_boomlaPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
