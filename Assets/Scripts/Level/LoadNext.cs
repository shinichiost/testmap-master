using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNext : MonoBehaviour
{
    
    public void loadnext()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         UIManager.instance.ResumeGame();
    }

}
