using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    int currentScene;
    int nextScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene +1;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        switch (collision.gameObject.tag) 
        {
            case "fuel":
                Debug.Log("fuel");
                break;
            case "safe":
                Debug.Log("player");
                break;
            case "goal":
                LoadNextLevel();
                break;
            default:
                this.GetComponent<movement>().enabled = false;
                Invoke("ReloadLevel", 3f);
                break;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(currentScene);
    }
    void LoadNextLevel()
    {
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
}
