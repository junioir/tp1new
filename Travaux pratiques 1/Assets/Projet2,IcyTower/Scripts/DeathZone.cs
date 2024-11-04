using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathZone : MonoBehaviour {

    private Transform _playerSpwan;

    private Animator _FadeSystem;


    [SerializeField] private AudioClip _Sound;

    [SerializeField] private AudioSource _Audiosource;

    private void Awake() {
    
        _playerSpwan = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;

        _FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           StartCoroutine(replacePlayer(collision));

            AudioSource.PlayClipAtPoint(_Sound, transform.position);
        }
    }

    private IEnumerator replacePlayer(Collider2D collision)
    {
        _FadeSystem.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);

        collision.transform.position = _playerSpwan.position;
    }
}
