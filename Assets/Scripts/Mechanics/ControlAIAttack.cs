using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ControlAIAttack : MonoBehaviour
    {
        internal Attack attack;

        void Awake()
        {
            attack = this.transform.parent.GetComponent<Attack>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerStay2D(Collider2D other)
        {
            var pe = other.gameObject.GetComponent<PhysicalEntity>();
            if (pe != null && pe.team == 0)
            {
                attack.Trigger();
            }
        }

    }
}
