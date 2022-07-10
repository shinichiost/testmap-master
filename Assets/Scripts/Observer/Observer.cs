using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void onNotify();
}
public abstract class Event : MonoBehaviour{
    public abstract void getwin();
    public abstract void getlose();
}
    
    

