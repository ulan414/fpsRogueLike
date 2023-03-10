using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttachmentManagerBot : WeaponAttachmentManagerBehaviourBot
{
    private magazineBehaviorBot magazineBehaviour;
    [Tooltip("Selected Magazine Index.")]
    [SerializeField]
    private int magazineIndex;
    [Tooltip("All possible Magazine Attachments that this Weapon can use!")]
    [SerializeField]
    private magazineBot[] magazineArray;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Awake()
    {
        magazineBehaviour = magazineArray.SelectAndSetActive(magazineIndex);
    }
    public override magazineBehaviorBot GetEquippedMagazine() => magazineBehaviour;
}
