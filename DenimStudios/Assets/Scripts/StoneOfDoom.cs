using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoneOfDoom : MonoBehaviour
{
    
    void OnTriggerEnter(Collider doom)
    {
        if (doom.gameObject.tag == "Player")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
