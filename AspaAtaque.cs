using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspaAtaque : MonoBehaviour
{
    Transform tr;
    bool ataca = false;

    canon canon;
    Transform camaraCanon;

    public Animator anim;

    void Start()
    {
        tr = transform;
        canon = FindObjectOfType<canon>();
        camaraCanon = GameObject.Find("CameraCanon").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ataca)
        {
            anim.SetBool("ataca", true);
            transform.LookAt(camaraCanon.position);
            tr.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
    }
    public void SetAtaca(bool b)
    {
        ataca = b;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<canon>()==canon)
        {
            canon.SetVidaCanon(
                canon.GetVidaCanon() - 1);
            Destroy(gameObject);
        }
    }
}
