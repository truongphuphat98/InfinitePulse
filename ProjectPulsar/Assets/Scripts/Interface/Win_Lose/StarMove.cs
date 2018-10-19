using UnityEngine;
using System.Collections;

public class StarMove : MonoBehaviour {

    public int starTarget;
    float targetX, targetY;
   

    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
        MoveTo();
	}

    void MoveTo()
    {
        targetX = GameObject.Find("Star" + starTarget.ToString()).transform.position.x;
        targetY = GameObject.Find("Star" + starTarget.ToString()).transform.position.y;
        rb.AddForce(new Vector2(targetX - transform.position.x, targetY - transform.position.y) * Time.deltaTime * 200);
        transform.RotateAround(new Vector3(targetX, targetY), new Vector3(0, 0, 1), Time.deltaTime * 25);
    }
}
