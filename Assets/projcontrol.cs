using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projcontrol : MonoBehaviour
{
    public Vector3 dv = new Vector3(-115.1f, 0.2f, 0);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += dv * Time.deltaTime;
    }
}
