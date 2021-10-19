using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicHelper : MonoBehaviour
{
    Scene scene;
    
    // Start is called before the first frame update
     void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("MainMenuMusic");
        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        CheckSceneIndex();
    }

    void CheckSceneIndex()
    {
        if (scene.buildIndex == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
