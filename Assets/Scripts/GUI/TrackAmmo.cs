using UnityEngine;
using TMPro;

public class TrackAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    private Firearm currentWeapon;
    private bool isReloading = false;

    void Start()
    {
        if (ammoText == null)
        {
            Debug.LogError("Ammo Text is not set in the inspector.");
        }
        else
        {
            Debug.Log("Ammo Text is set and ready.");
            UpdateAmmoText(); // Manually update ammo text on start
        }
    }

    void Update()
    {
        if (currentWeapon != null)
        {
            if (isReloading)
            {
                ammoText.text = "0/" + currentWeapon.Capacity;
            }
            else
            {
                UpdateAmmoText();
            }
        }
        else
        {
            // Update ammo text to 0/0 if no weapon is equipped
            ammoText.text = "0/0";
        }
    }

    public void SetCurrentWeapon(Firearm weapon)
    {
        currentWeapon = weapon;
        Debug.Log("Current weapon set to: " + (weapon != null ? weapon.name : "None"));
        UpdateAmmoText();
    }

    public void StartReload()
    {
        if (currentWeapon != null)
        {
            ammoText.text = "0/" + currentWeapon.Capacity;
            isReloading = true;
            Invoke("FinishReload", currentWeapon.ReloadTime);
        }
    }

    void FinishReload()
    {
        if (currentWeapon != null)
        {
            currentWeapon.Reload(currentWeapon.Capacity);
            isReloading = false;
            UpdateAmmoText();
        }
    }

    void UpdateAmmoText()
    {
        if (currentWeapon != null && ammoText != null)
        {
            Debug.Log("Updating ammo text: " + currentWeapon.Ammo + "/" + currentWeapon.Capacity);
            ammoText.text = currentWeapon.Ammo.ToString() + "/" + currentWeapon.Capacity;
        }
        else if (ammoText != null)
        {
            // Update ammo text to 0/0 if no weapon is equipped
            ammoText.text = "0/0";
        }
    }
}
