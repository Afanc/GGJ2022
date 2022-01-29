using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalEntity : MonoBehaviour
{
    public int team = 0;
    public float hp = 10f;

    public EnemyController enemy;

    void Awake()
    {
        if (team == 1) enemy = GetComponent<EnemyController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0f)
        {
            if (team == 1) Schedule<EnemyDeath>().enemy = enemy;

            if (team == 0) Schedule<PlayerDeath>();
        }
        
    }

    void DoDamage(float damage)
    {
        hp -= damage;
    }
}
