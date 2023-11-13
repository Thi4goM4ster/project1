using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI hud, msgVictory;
    public int restantes;
    public AudioClip CoinSFX,VictorySFX;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out source);
        restantes = FindObjectsOfType<Coin>().Length;

        hud.text = $"{restantes} :Coins remaining";
    }

    // Update is called once per frame
    public void SubtractCoins(int valor)
    {
        restantes -= valor;
        hud.text = $"{restantes} :Coins remaining";
        PlayCoin();
        if (restantes <= 0)
        {
         msgVictory.text = "CONGRATS!";
         PlayVictory();
        }
    }
    public void PlayCoin()
    {
        source.PlayOneShot(CoinSFX);
    }
    public void PlayVictory()
    {
        source.PlayOneShot(VictorySFX);
    }

}
