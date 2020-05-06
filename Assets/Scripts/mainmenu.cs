using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public Text label;
    public static string level;
    void Start()
    {
        level = label.text;
        
    }
    void Update()
    {
        level = label.text; 
       
    }
    public void play()
    {

        SceneManager.LoadScene(1);

    }
}
