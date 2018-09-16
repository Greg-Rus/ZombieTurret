using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingleton : MonoBehaviour
{

    public AudioSource a;

    public AudioClip[] list;

    public AudioClip[] dyingSounds;


    private static AudioSingleton _instance;

    public static AudioSingleton Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    public  void playSounds(SoundTypes s) {
        Debug.Log(s);
        switch (s) { 
            case SoundTypes.Arrow:
                a.PlayOneShot(list[0]);
                break;
            case SoundTypes.EnemyDead:
                a.PlayOneShot(dyingSounds[Random.Range(0,dyingSounds.Length)]);
                break;
            case SoundTypes.PlayerDead:
                a.PlayOneShot(list[2]);
                break;
            case SoundTypes.Attack:
                a.PlayOneShot(list[3]);
                break;
            case SoundTypes.Explosion:
                a.PlayOneShot(list[4]);
                break;
            case SoundTypes.PickupGold:
                a.PlayOneShot(list[5]);
                break;
            case SoundTypes.PickupHealth:
                a.PlayOneShot(list[6]);
                break;
            case SoundTypes.ShopMenu:
                a.PlayOneShot(list[7]);
                break;
        }
    }

   
}

public enum SoundTypes {

    EnemyDead,
    PlayerDead,
    Attack,
    Arrow,
    Explosion,
    PickupGold,
    PickupHealth,
    ShopMenu



}
