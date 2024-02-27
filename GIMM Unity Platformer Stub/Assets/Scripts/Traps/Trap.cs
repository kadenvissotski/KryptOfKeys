using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap
{
   public virtual bool IsSpinning()
    {
        return false;
    }

    public virtual bool CanDamage()
    {
        return true;
    }

}
