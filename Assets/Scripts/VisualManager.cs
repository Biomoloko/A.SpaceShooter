using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualManager : MonoBehaviour
{
    public static VisualManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public void Drawator(Image image, float currentHealth, float maxHealth)
    {
        image.fillAmount = currentHealth / maxHealth;
    }
}