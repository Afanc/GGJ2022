using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInputAttack : MonoBehaviour
{
    internal Attack attack;

    void Awake()
    {
        attack = GetComponent<Attack>();
    }

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack")) attack.Trigger();
    }


}
