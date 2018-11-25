﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    
    public Animator anim;
    public Transform firePoint;
    public GameObject bullet;
    
    [HideInInspector]
    public bool isShooting;
	// Update is called once per frame
	void Update () {
        // Make weapon follow mouse cursor
        Transform weapon = transform.GetChild(0);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 weaponPos = weapon.transform.position;
        float angle = Mathf.Atan2(mousePos.y - weaponPos.y, mousePos.x - weaponPos.x) * Mathf.Rad2Deg - 90;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        weapon.transform.localPosition = new Vector3(weapon.transform.localPosition.x,
                                                     weapon.transform.localPosition.y,
                                                     anim.GetFloat("mousePosition") > 0 ? 1 : -1);

        isShooting = Input.GetMouseButtonDown(0) || Input.GetKeyDown("z");
	}
}
