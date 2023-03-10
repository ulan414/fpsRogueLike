using UnityEngine;
using System.Collections;

public class AttachWeapon : MonoBehaviour {
	public Transform attachPoint;
	public Transform Weapon;
	
	// Use this for initialization
	void Start () {
		/*        Weapon.parent = attachPoint;
				*//*Weapon.gameObject.transform.GetChild(14) = attachPoint;
				Weapon.gameObject.transform.GetChild(14).position = attachPoint.position;*//*
				Weapon.position = attachPoint.position;

				Weapon.position = new Vector3(0, 0, 0);
				Debug.Log(Weapon.position);
				Weapon.position = Weapon.position + new Vector3(0, 0.635f, -0.492f); //-0.109f
				Debug.Log(Weapon.position);
				Weapon.rotation = attachPoint.rotation;
				Quaternion rotationY = Quaternion.AngleAxis(180, Vector3.up);
				Weapon.rotation *= rotationY;*/
		Weapon.SetParent(attachPoint);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
