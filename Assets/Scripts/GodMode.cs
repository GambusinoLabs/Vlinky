using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    Muerte muerte;

    void Start()
    {
        this.enabled = false;
    }

    public void God()
    {
        muerte = GetComponent<Muerte>();
        muerte.godMode = true;
        this.enabled = true;
    }

    void Update()
    {
        Debug.DrawRay(GetComponent<Rigidbody2D>().transform.position + 0.15f * Vector3.down, new Vector2(1f, 1f) * 99.0f);
        Debug.DrawRay(GetComponent<Rigidbody2D>().transform.position + 0.15f * Vector3.down, new Vector2(-1f, 1f) * 99.0f);
    }



}
