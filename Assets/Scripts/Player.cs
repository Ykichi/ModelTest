using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator anim;
    public Rigidbody rb;

    private float inputH;
    private float inputV;
    private bool run;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {

        //數字鍵切換動作
        if (Input.GetKeyDown("1"))
        {
            anim.Play("WAIT01", -1);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WAIT02", -1);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WAIT03", -1);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WAIT04", -1);
        }

        //shift奔跑
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }
        else
        {
            run = false;
        }

        //space跳躍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);
        anim.SetBool("run", run);

        float moveX = inputH * 30 * Time.deltaTime;
        float moveZ = inputV * 50 * Time.deltaTime;

        //後退時沒有水平向量
        if (moveZ <= 0)
        {
            moveX = 0;
        }

        if (run)
        {
            moveZ *= 3;
            moveX *= 3;
        }



        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
