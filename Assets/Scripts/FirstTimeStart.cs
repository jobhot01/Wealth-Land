using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeStart : MonoBehaviour
{
    void Awake()
    {
        GameObject[] deleterObject = GameObject.FindGameObjectsWithTag("Deleter");
        if (deleterObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            PlayerPrefs.DeleteAll();
            Debug.Log("Deleted");
        }
    }
}
