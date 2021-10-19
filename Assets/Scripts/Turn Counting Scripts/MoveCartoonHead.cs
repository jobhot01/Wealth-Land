using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCartoonHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch ( GameController.gameturn )
        {
            case 1:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (-230,0);
                break;

            case 2:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (-170,0);
                break;
                
            case 3:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (-130,0);
                break;

            case 4:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (-75,0);
                break;

            case 5:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (-20,0);
                break;
                
            case 6:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (10,0);
                break;

            case 7:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (40,0);
                break;
                
            case 8:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (75,0);
                break;

            case 9:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (130,0);
                break;
                
            case 10:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (155,0);
                break;
                
            case 11:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (190,0);
                break;

            case 12:
                GetComponent<RectTransform>().anchoredPosition = new Vector2 (230,0);
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
