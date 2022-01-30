using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class Attack : MonoBehaviour
    {
        public float timePre = 0.5f;
        public float timeHit = 0.7f;
        public float timePost = 1.5f;

        public float time = 2f;

        public float damage = 5.0f;

        public bool hit = false;
        public bool hitting = false;

        public int team;

        public Animator animator;

        void Awake()
        {
            var pe = GetComponent<PhysicalEntity>();
            if (pe != null) team = pe.team;
            else
            {
                pe = this.transform.parent.GetComponent<PhysicalEntity>();
                if (pe != null) team = pe.team;
                else
                {
                    print("Fuck init attack");
                }
            }

            animator = GetComponent<Animator>();
            if (animator == null) animator = this.transform.parent.GetComponent<Animator>();
        }



        void OnTriggerStay2D(Collider2D other)
        {
            if (team == 1) print(hit);
            if (!hit && time > timePre && time < timeHit)
            {
                if (!hitting)
                {
                    animator.SetTrigger("attack");
                    hitting = true;
                }
                var pe_other = other.gameObject.GetComponent<PhysicalEntity>();
                if (pe_other != null && pe_other.team != team) 
                {
                    hit = true;
                    pe_other.DoDamage(damage);
                    // print(team.ToString() + "attack: " + pe_other.team.ToString());
                }
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            // if (Input.GetButtonDown("Attack"))
            //     Trigger()
        }

        public void Trigger()
        {
            if (time > timePost)
            {
                time = 0f;
                hit = false;
                hitting = false;
                // animator.SetTrigger("startAttack");
            }
        }
    }
}
