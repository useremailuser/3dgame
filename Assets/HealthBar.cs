using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Damageable agent;
    [SerializeField] private Gradient gradient;

    private Image healthbar;

    private void Start()
    {
       healthbar = GetComponent<Image>();
    }
    void Update()
    {
        healthbar.fillAmount = agent.GetHealthPercent();
        healthbar.color = gradient.Evaluate(agent.GetHealthPercent());
    }


}
