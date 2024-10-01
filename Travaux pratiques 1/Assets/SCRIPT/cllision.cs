using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cllision : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _MessageText;
    [SerializeField]  private GameObject _VaisseauFuyantPrefab;
    [SerializeField] private int _VaisseauxRestants = 5; 

    void OnCollisionEnter(Collision collision)
    {
        // V�rifiez si le vaisseau intercepteur entre en collision avec un vaisseau fuyant
        if (collision.gameObject.CompareTag("VaisseauFuyant"))
        {
            // Affiche le message de d�faite
            AfficherMessage("Tu as perdu!");

            // D�truire le vaisseau fuyant
            Destroy(collision.gameObject);

            // Diminuer la valeur du nombre de vaisseaux restants
            _VaisseauxRestants--;
           
            Debug.Log("Vaisseaux restants: " + _VaisseauxRestants);


            void AfficherMessage(string message)
            {
                
                _MessageText.text = message;
            }
        }

    }
}
