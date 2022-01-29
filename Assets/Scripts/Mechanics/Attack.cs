using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float timePre = 0.5f;
    public float timeHit = 0.7f;
    public float timePost = 1.5f;

    public float time = 2f;

    public float damage = 5.0f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (time > timePre && time < timeHit)
        {
            print(other);
            var team_player = other.gameObject.GetComponent<PhysicalEntity>();
            print(team_player);
            if (team_player != null) print(team_player.team);
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
        if (Input.GetButtonDown("Attack"))
            time = 0f;
    }
}
