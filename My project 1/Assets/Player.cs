using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int jump = 7;
    private Rigidbody rb;

    public bool noChao;

    void Start() {
        TryGetComponent(out rb);
}
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag=="Floor") {
            noChao = true;
        }
    }
    void Update() {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(inputHorizontal,0,inputVertical) * velocidade);
        
        if (Input.GetKeyDown(KeyCode.Space) && noChao){ 

            rb.AddForce(Vector3.up*jump,ForceMode.Impulse);
            noChao = false;
        }
        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
