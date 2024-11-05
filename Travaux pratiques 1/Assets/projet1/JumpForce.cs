using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpForce : MonoBehaviour
{
    [SerializeField] private float _jumpBoostMultiplier = 2f; 

    [SerializeField] private float _boostDuration = 3f;


    [SerializeField] private AudioClip _Sound;

    [SerializeField] private AudioSource _Audiosource;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            // Accéder au script du joueur pour augmenter la force de saut
            Player players = other.GetComponent<Player>();
            if (players != null)
            {
                // Appliquer l'augmentation temporaire de la force de saut
                StartCoroutine(ApplyJumpBoost(players));

                AudioSource.PlayClipAtPoint(_Sound, transform.position);

                ;
            }
        }
    }

    private IEnumerator ApplyJumpBoost(Player player)
    {
        // Augmenter la force de saut du joueur
        float originalJumpForce = player.jumpForce;
        player.jumpForce *= _jumpBoostMultiplier;

        // Attendre la durée du boost
        yield return new WaitForSeconds(_boostDuration);

        // Rétablir la force de saut d'origine
        player.jumpForce = originalJumpForce;
    }

}
   

   
