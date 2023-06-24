using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    Animator Anim;
    public Text coin;

    private void Awake()
    {
        Anim = GetComponent<Animator> ();
    }

    public void eventChest()
    {
        SceneManager.LoadScene(3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (coin.text == "3")
            {
                Anim.SetInteger("Stan", 3);
                Debug.Log("Hello");
            }
        }
    }

}
