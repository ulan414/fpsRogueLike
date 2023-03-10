using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviorBot : MonoBehaviour
{

    protected virtual void Start() { }
    public abstract int GetAmmunitionCurrent();
    public abstract int GetAmmunitionTotal();
    public abstract int GeTAmmo();
    public abstract bool HasAmmunition();
    public abstract bool IsFull();
}
