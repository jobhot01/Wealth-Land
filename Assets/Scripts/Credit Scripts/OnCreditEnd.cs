using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCreditEnd : MonoBehaviour
{
    [SerializeField] LoadScene loadScene;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Credit")
        {
            Debug.Log("Triggered");
            loadScene.GoMainMenu();
        }
    }
}
