using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallmonster_death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(DestroyTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator  DestroyTimer()
    {
         yield return new WaitForSeconds(1f);
         Destroy(gameObject);
  }

}
