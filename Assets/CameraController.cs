using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      float step = 0.002f;

      var cameraPosition = gameObject.transform.position;
      cameraPosition.x += step;
      gameObject.transform.position = cameraPosition;
    }
}
