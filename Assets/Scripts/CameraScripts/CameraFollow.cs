using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector2 offset;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        // Smooth
        // Vector3.SmoothDamp(transform.position, new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10), ref velocity, 0.5f);
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, -10);
        }
    }
}
