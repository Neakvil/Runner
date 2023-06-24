using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Text coin;

    private void Start()
    {
        PlayerPrefs.SetInt("Coin", 0);
        coin.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 1);
            coin.text = PlayerPrefs.GetInt("Coin").ToString();
        }
        if (other.tag == "Platform")
        {
            Destroy(other.gameObject);
        }
    }
}
