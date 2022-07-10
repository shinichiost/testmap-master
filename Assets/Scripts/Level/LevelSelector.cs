using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public Text leveltext;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        leveltext.text = level.ToString();
    }

    // Update is called once per frame
    public void openScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
}
