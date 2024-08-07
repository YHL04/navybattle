using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour, IComponent
{
    [SerializeField]
    private Image healthBar;
    private float healthAmount;
    private float totalHealth;
    public Component component { get { return this; } }
    private void Awake()
    {
        healthAmount = 1f;
        totalHealth = 1f;
    }
    // Start is called before the first frame update
    public void UpdateAmount(float val, float maxval)
    {
        this.healthAmount = val;
        this.totalHealth = maxval;
        healthBar.fillAmount = healthAmount/totalHealth;
    }
    public void SetColor(Color c)
    {
        healthBar.color = c;
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
