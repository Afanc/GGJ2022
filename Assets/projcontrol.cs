using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class projcontrol : MonoBehaviour
    {
        public Vector3 dv = new Vector3(-115.1f, 0.2f, 0);

        // Start is called before the first frame update
        void Start()
        {
            int play_nbr = 2;
            if (transform.position.y > -5f) play_nbr = 1;
            
            var players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                print(player.GetComponent<PlayerController>().PlayerNumber);
            }
            
        }

        // Update is called once per frame
        void Update()
        {
           transform.position += dv * Time.deltaTime;
        }
    }
}
