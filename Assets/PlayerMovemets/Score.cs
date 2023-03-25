using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int marcador = 0;

    public Text textomarcador; 

    Dictionary<int, bool> CollectedStars = new Dictionary<int, bool>();
    
    void Start()
    { 
        textomarcador.text= "STARS " + marcador;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Star") 
        {
            int StarID = other.gameObject.GetInstanceID();
            if(CollectedStars.ContainsKey(StarID) && CollectedStars[StarID])
            {
              return;
            }
             CollectedStars[StarID] = true;
            marcador++;
            textomarcador.text= "STARS " + marcador;
        }
    }

}
