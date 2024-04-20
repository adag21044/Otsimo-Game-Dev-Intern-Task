using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    
    public KeyCode gecisTusu = KeyCode.Space;

    // Geçilecek sahnenin ismi
    public string yeniSahneIsmi;

    void Update()
    {
        // Eğer belirlenen tuşa basılırsa
        if (Input.GetKeyDown(gecisTusu))
        {
            // Yeni sahneye geç
            SceneManager.LoadScene(yeniSahneIsmi);
        }
    }
}
