using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBot : WeaponBehaviorBot
{
    private int ammunitionCurrent;
    private magazineBehaviorBot magazineBehaviour;

    public override int GetAmmunitionCurrent() => ammunitionCurrent;
    public override int GetAmmunitionTotal() => magazineBehaviour.GetAmmunitionTotal();
    public override int GeTAmmo() => magazineBehaviour.GetAmmo();
    public override bool IsFull() => ammunitionCurrent == magazineBehaviour.GetAmmunitionTotal();
    public override bool HasAmmunition() => ammunitionCurrent > 0;

    protected override void Start()
    {
        ammunitionCurrent = magazineBehaviour.GetAmmo();
    }
    void Update()
    {
        Debug.Log(ammunitionCurrent);
    }

}
