using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int objects = 0;
    public Text objectText;
    public GameObject hintText;
    [SerializeField]
    private GameObject playerShotgun;
    public int hp = 2;

    // Start is called before the first frame update
    void Start()
    {
        hp = 2;
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

        if(other.transform.tag == "Shotgun"){
            hintText.SetActive(true);
            hintText.GetComponent<Text>().text = "Pressione E para pegar";
        }
    }

    void OnTriggerStay(Collider other){
        if(other.transform.tag == "Shotgun" && Input.GetKeyDown(KeyCode.E)){
            Destroy(other.gameObject);
            playerShotgun.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.transform.tag == "Shotgun"){
            hintText.SetActive(false);
        }
    }
    public void TakeDamage(int damage){
        hp -=damage;
        if(hp <= 0){
            Debug.LogWarning("MORREU!");
        }
    }
}
