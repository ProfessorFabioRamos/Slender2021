using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public AudioClip[] sfx;
    private AudioSource aud;
    public float range = 10;
    public Camera fpsCam;
    public LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            aud.clip = sfx[1];
            //aud.PlayOneShot(sfx[1]);
            aud.Play();

            RaycastHit hit;
            Vector3 origin = fpsCam.ViewportToWorldPoint(Vector3.zero);

            if(Physics.Raycast(origin, fpsCam.transform.forward, out hit, range)){
                Debug.Log(hit.transform.name);
                if(hit.transform.gameObject.tag == "Enemy"){
                    Destroy(hit.transform.gameObject);
                }
                //Debug.DrawLine(firePosition.position, )
            }
        }
    }
}
