using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int objects = 0;
    public Text objectText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectText.text = objects+"/8";
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag == "Collectible"){
            objects++;
            Destroy(other.gameObject);
        }
    }
}
