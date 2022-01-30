using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

using static Platformer.Core.Simulation;
namespace Platformer.Mechanics
{
    public class PhysicalEntity : MonoBehaviour
    {
        public int team = 0;
        public float hp = 10f;

        public EnemyController enemy;

        public Animator animator;

        void Awake()
        {
            var player = GetComponent<PlayerController>();
            if (player) team = 0;
            else team = 1;

            animator = GetComponent<Animator>();
        }

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (hp < 0f)
            {
                Die();
            }
            
        }

        public void Die()
        {
            if (team == 1)
            {
                DestroyEnemy();
            }

            if (team == 0) 
            {
                LostTheGame();
            }
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        public void LostTheGame()
        {
            print("Lost The Game");

            Destroy(gameObject);
            // Schedule<PlayerDeath>();
        }

        public void DoDamage(float damage)
        {
            print("tak damage");

            animator.SetTrigger("hurt");
            hp -= damage;
        }
    }
}
