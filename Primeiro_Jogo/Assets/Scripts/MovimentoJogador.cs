using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MonoBehaviour
{
    private Rigidbody rb;
    private float velocidade = 10;
    private float pulo = 8;
    private Vector3 impulso = new Vector3(0, 10, 0);
    private bool noChao = false;
    private bool temParede;
    private Quaternion rotacao;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        noChao = Physics.Raycast(transform.position, Vector3.down, 1f);
        temParede = Physics.Raycast(transform.position, transform.forward, 0.60f);

        if (!Input.GetButton("Left") && !Input.GetButton("Right"))
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * velocidade * Time.deltaTime, 0, 0);
        }

        if (Input.GetButton("Left"))
        {
            if (!temParede)
            {
                transform.position += new Vector3(Input.GetAxis("Left") * velocidade * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetButton("Right"))
        {
            if (!temParede)
            {
                transform.position += new Vector3(Input.GetAxis("Right") * velocidade * Time.deltaTime, 0, 0);
            }
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            rotacao.SetLookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
            transform.rotation = rotacao;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (noChao == true)
            {
                rb.velocity = new Vector3(0, Input.GetAxis("Jump") * pulo, 0);
            }
        }
        /*if (noChao == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(impulso, ForceMode.Impulse);
            }
        }*/
    }
}
