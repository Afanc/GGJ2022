using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip_Camera : MonoBehaviour
{

    public Camera m_camera;

    void OnPreCull()
    {
        m_camera.ResetWorldToCameraMatrix();
        m_camera.ResetProjectionMatrix();
        m_camera.projectionMatrix = m_camera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }
 
    void OnPreRender()
    {
         GL.SetRevertBackfacing(true);
    }
 
    void OnPostRender()
    {
        GL.SetRevertBackfacing(false);
    }
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
