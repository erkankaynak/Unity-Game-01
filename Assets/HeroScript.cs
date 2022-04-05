using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public float speed = 10f;
    
    private float[] heroPaths = { -.2f, 0, .2f };
    private int heroPathPosition=1;

    private float firstPos;
    private float lastPos;

    private float minDiff = 50f;

    void Start()
    {
        transform.position = new Vector3(heroPaths[heroPathPosition], transform.position.y, transform.position.z);
    }


    void Update()
    {
        // Mouse
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            lastPos = Input.mousePosition.x;

            var diff = lastPos - firstPos;
            if (diff > minDiff)
                MoveRight();

            if (diff <  minDiff * -1)
                MoveLeft();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Reset");
            firstPos = 0f;
            lastPos = 0f;
        }
            

        // Keyboard
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveLeft();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveRight();
        
    }

    private void MoveLeft()
    {
        if (heroPathPosition > 0)
        {
            heroPathPosition--;
            StartCoroutine(Move());
            firstPos = lastPos;
        }

    }

    private void MoveRight()
    {
        if (heroPathPosition < 2)
        {
            heroPathPosition++;
            StartCoroutine(Move());
            firstPos = lastPos;
        }
    }

    IEnumerator Move()
    {
        
        while(true)
        {
            var targetPosition = new Vector3(heroPaths[heroPathPosition], transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1f * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < .005f) break;

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "duvar")
        {
            GameManager.isGameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puan")
        {
            GameManager.AddScore(1);
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
