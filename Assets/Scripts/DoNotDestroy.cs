using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    Scene scene;
    
    void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }   
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        CheckSceneIndex();
    }

    void CheckSceneIndex()
    {
        if (scene.buildIndex == 10 || scene.buildIndex == 11)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
