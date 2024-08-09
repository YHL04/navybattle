using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrackAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public int ammo = 12;
    public int privateAmmo = 12;
    void Start()
    {
    }
    void Update()
    {
        if (ammo != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ammo--;
            }
            ammoText.text = ammo.ToString() + "/" + privateAmmo;
        }
    }
}