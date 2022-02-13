using UnityEngine;
using UnityEngine.SceneManagement;
public class Tatu : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _tatuWasLaunched;

    [SerializeField] private float _launchPower = 500;

    private float _timeStuck;

    private void Awake() {
        _initialPosition = transform.position;
    }

    private void Update() {
        string currentSceneName = SceneManager.GetActiveScene().name;

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);  

        if(currentSceneName != "Level3"){
            if (_tatuWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1){
                _timeStuck += Time.deltaTime;
            }

            if (transform.position.y > 10 || transform.position.y < -10 ||
                transform.position.x > 10 || transform.position.x < -10 ||
                _timeStuck > 3){
                SceneManager.LoadScene(currentSceneName);
            }
        }
        else{
            if (transform.position.y > 100 || transform.position.y < -100 ||
                transform.position.x > 100 || transform.position.x < -100 ||
                _timeStuck > 3){
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    private void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.cyan;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp() 
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _tatuWasLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() 
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }
}
