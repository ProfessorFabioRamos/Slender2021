using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    private Animation anim;
    private bool open = false;
    public GameObject hintText;

    void Start(){
        anim = GetComponentInParent<Animation>();
        hintText.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
        Player p = other.GetComponent<Player>();

        if(p != null && !open){
            int score =  p.objects;
            hintText.SetActive(true);
            hintText.GetComponent<Text>().text = "Você possui "+score+ "/8 caveiras.";
            if(score >= 8){
                anim.Play("Opening");
                hintText.SetActive(false);
                open  = true;
            }
        }
    }
    void OnTriggerExit(Collider other){
        Player p = other.GetComponent<Player>();

        if(p != null){
            hintText.SetActive(false);
        }
    }
}
