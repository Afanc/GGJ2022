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
            
            var players = UnityEngine.Object.FindObjectsOfType<PlayerController>();  

            foreach (PlayerController player in players)
            {
                if (play_nbr == player.PlayerNumber) dv = player.transform.position - transform.position;
                dv.Normalize();
                dv = dv * 5.0f;
            }
            
        }

        // Update is called once per frame
        void Update()
        {
           transform.position += dv * Time.deltaTime;
        }
    }
}
