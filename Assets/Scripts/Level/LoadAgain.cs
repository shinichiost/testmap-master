using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadAgain : MonoBehaviour
{
    // Start is called before the first frame update
   
    public void loadagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIManager.instance.ResumeGame();
    }
   
}
