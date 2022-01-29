using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ControleAI : MonoBehaviour
    {
        internal AnimationController control;

        void Awake()
        {
            control = this.transform.parent.GetComponent<AnimationController>();
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
                control.move.x = Mathf.Clamp(pe.gameObject.transform.position.x - transform.position.x, -1, 1);
            }
        }

    }
}
