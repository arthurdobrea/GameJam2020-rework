using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Camera camera;
    public Plane plane;
    
    private float moveSpeed = 3;
    private Vector3 finalVelocity;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
        plane = new Plane(Vector3.up,Vector3.zero);
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        finalVelocity = input.normalized * moveSpeed;
        
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        
        if (plane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin,point,Color.red);
            lookAt(point);
        }
    }

    void lookAt(Vector3 point)
    {
        Vector3 correction = new Vector3(point.x, transform.position.y, point.z);
        transform.LookAt(correction);
    }

    void FixedUpdate()
    {
        
        rigidbody.MovePosition(rigidbody.position + finalVelocity * Time.deltaTime);
    }
}