using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool CanDamage()
    {
        return true;
    }

    public override bool IsSpinning()
    {
        return false;
    }

}
