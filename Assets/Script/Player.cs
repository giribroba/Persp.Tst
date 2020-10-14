using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public float vel;
    private Rigidbody rbPlayer;

    void Awake()
    {
        rbPlayer = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        print(Input.GetAxis("Horizontal"));
        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, rbPlayer.velocity.y, Input.GetAxis("Vertical") * vel);
    }
}
