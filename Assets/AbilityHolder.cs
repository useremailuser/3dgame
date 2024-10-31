using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldown;
    float casttime;

    enum AbilityState
    {
        ready,
        active,
        cooldown,

    }
    AbilityState state = AbilityState.ready;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if(input.GetKeyDown(key))
                {
                    Ability.Activate();
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
                case AbilityState.active:
                if (casttime > 0)
                {
                    casttime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldown = ability.cooldown;
                }
                break;
                case AbilityState.cooldown:
                if (casttime > 0)
                {
                    casttime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }

    }
}
