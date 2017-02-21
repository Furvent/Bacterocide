using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate () {

        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(moveHorizontal, moveVertical) * speed;

        // Rotation
        //transform.LookAt(new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y), Vector3.up);
        //transform.LookAt(new Vector3(0, Input.mousePosition.z, 0), Vector3.up);
        //transform.LookAt(Input.mousePosition);
        rotateToMouse();

        //Debug
        Debug.DrawLine(transform.position, Input.mousePosition);
        Debug.DrawLine(transform.forward, new Vector3(10, 0, 0), Color.red);
    }

    public void rotateToMouse() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(mousePos.x, mousePos.y, transform.position.z));
    }
}
