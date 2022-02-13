using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    private Dumb[] _dummies;
    private void OnEnable() {
        _dummies = FindObjectsOfType<Dumb>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Dumb dumb in _dummies){
            if (dumb != null){
                return;
            }
        }

        Debug.Log("All dummies dead, Tatu is victorious!");

        _nextLevelIndex++;
        if(_nextLevelIndex > 3){
            _nextLevelIndex = 1;
        }
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }

    public void restart(){
        SceneManager.LoadScene("Level1");
    }

    public void quit(){
        Application.Quit();
        Debug.Log("Rage'd");
    }
}
