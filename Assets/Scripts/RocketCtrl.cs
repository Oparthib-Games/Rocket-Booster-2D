using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCtrl : MonoBehaviour
{
    Rigidbody2D RB;

    public float boost_speed = 1;
    public float rotate_speed = 1;
    public float H_acelaration = .3f;
    public float V_acelaration = .6f;

    public float H = 0;
    public float V = 0;

    public bool isLaunched;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        userInput();
    }

    void FixedUpdate()
    {
        //RB.AddForce(transform.up * boost_speed * H * Time.deltaTime, ForceMode2D.Force);
        transform.Translate(transform.up * boost_speed * H * Time.deltaTime, Space.World);

        transform.Rotate(transform.forward * V * -rotate_speed * Time.deltaTime);
    }

    void userInput()
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            if (H < 1)
            {
                H += Time.deltaTime * H_acelaration;
            }
            if (H > .2f)
            {
                isLaunched = true;
            }
            return;
        }
        else if (Input.GetKey(KeyCode.D) && isLaunched)
        {
            if (V < 1) V += Time.deltaTime * V_acelaration;
            if (H > 0) H -= Time.deltaTime * H_acelaration;
            return;
        }
        else if (Input.GetKey(KeyCode.S) && isLaunched)
        {
            if (V > -1) V -= Time.deltaTime * V_acelaration;
            if (H > .5f) H -= Time.deltaTime * H_acelaration;
            return;
        }
        else
        {
            if (H > 0) H -= Time.deltaTime;
            V = 0;
        }
    }
}
