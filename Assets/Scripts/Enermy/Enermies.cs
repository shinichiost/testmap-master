using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermies :Observer
{
    public override void onNotify()
    {
        beDestroyed();
    }
    
    void beDestroyed()
    {
        Destroy(this);
    }
}
