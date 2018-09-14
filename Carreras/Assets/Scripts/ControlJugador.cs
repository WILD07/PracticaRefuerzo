using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ControlJugador : MonoBehaviour {

    public float velocidad = 10;
    float vertical;
    float horizontal;
    Rigidbody miRigidbody;
    Vector3 posicionInicial;    
    public Text textoVictoria;    
    bool saliste;
    public float fuerzaSalto;

    // Use this for initialization
    void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        textoVictoria.enabled = false;
        saliste = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!saliste)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            miRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
            miRigidbody.AddForce(new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * velocidad);

        }
        if (CrossPlatformInputManager.GetButton("Jump") && Mathf.Abs(miRigidbody.velocity.y) < 0.01f)
            miRigidbody.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            saliste = true;
            textoVictoria.enabled = true;
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
        }           
    }
}
