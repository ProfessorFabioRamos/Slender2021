using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teste : MonoBehaviour
{
    public UnityEvent my_Event;
    public Material mat;
    public GameObject originalPrefab;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            my_Event.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.E)){
           CreateBox();
        }
    }

    public void ChangeMaterial(){
        GameObject obj = GameObject.FindGameObjectWithTag("Especial");
        obj.GetComponent<MeshRenderer>().material = mat;
    }

    public void CreateBox(){
        Instantiate(originalPrefab, transform.position, Quaternion.identity);
    }
}
