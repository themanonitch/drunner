using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int muns = 0;

    [SerializeField] private Text Muns_Hud_value;
    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private AudioSource treasureSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            muns++;
            Muns_Hud_value.text = "" + muns;
        }
        else if (collision.gameObject.CompareTag("Big_Coin"))
        {
            collectionSoundEffect.Play();
            treasureSoundEffect.Play();
            Destroy(collision.gameObject);
            muns += 10;
            Muns_Hud_value.text = "" + muns;
        }
    }
}
