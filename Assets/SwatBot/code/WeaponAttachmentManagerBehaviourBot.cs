using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAttachmentManagerBehaviourBot : MonoBehaviour
{
    protected virtual void Awake() { }
    // Start is called before the first frame update
    public abstract magazineBehaviorBot GetEquippedMagazine();
}
