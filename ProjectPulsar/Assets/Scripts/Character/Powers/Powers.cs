using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 posAttractPos;

    float pushReload = 0.3f, attractReload = 3f, screenX = 17.6f, screenY = 10f, maxSpeed = 2.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        posAttractPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        posAttractPos = Camera.main.ScreenToWorldPoint(posAttractPos);

        if (gameObject.tag == "Push")
        {
            pushReload -= Time.deltaTime;
            //rb.AddForce(new Vector2(posAttractPos.x - transform.position.x, posAttractPos.y - transform.position.y));
        }



        if (gameObject.tag == "Attract" && Time.timeScale == 1)
        {
            attractReload -= Time.deltaTime;
            rb.AddForce(new Vector2(posAttractPos.x - transform.position.x, posAttractPos.y - transform.position.y) * 1.5f);

            if (rb.velocity.magnitude >= maxSpeed)
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

            transform.Rotate(new Vector3(0, 0, 1) * 6);
            if (attractReload <= 1f)
                transform.localScale -= new Vector3(0.006f, 0.006f, 1);
        }

        if (pushReload <= 0 || attractReload <= 0)
            Destroy(gameObject);

        if (transform.position.x <= -8.8f)
            transform.position = new Vector2(transform.position.x + screenX, transform.position.y);
        if (transform.position.x >= 8.8f)
            transform.position = new Vector2(transform.position.x - screenX, transform.position.y);
        if (transform.position.y <= -5f)
            transform.position = new Vector2(transform.position.x, transform.position.y + screenY);
        if (transform.position.y >= 5f)
            transform.position = new Vector2(transform.position.x, transform.position.y - screenY);
    }
}
