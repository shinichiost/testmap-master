using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection instance { get; private set; }
    [Header("Character :")]
    [SerializeField]private List<GameObject> gameoj = new List<GameObject>();
    private GameObject oj;
    [SerializeField]
    private static int index ;
    private void Awake()
    {
        
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        oj = character();
        oj.SetActive(true);
        Object.DontDestroyOnLoad(oj);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void decreaseIndex()
    {
        if(index > 0)
            index -= 1;
        else
            index = gameoj.Count - 1;
        oj.SetActive(false);
        oj = gameoj[index];
        oj.SetActive(true);
    }
    public void increaseIndex()
    {
        if (index < gameoj.Count - 1)
            index += 1;
        else
            index = 0;
        oj.SetActive(false);
        oj = gameoj[index];
        oj.SetActive(true);
    }
    public GameObject character()
    {
        return gameoj[index];
    }
    public static int getIndex()
    {
        return index;
    }
}
