using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform[] _layers; // Les couches de parallax
    [SerializeField] private float[] _parallaxScales; // Les �chelles de parallax pour chaque couche
    [SerializeField] private float _smoothing = 1f; // Lissage du mouvement

    private Transform _cam; // R�f�rence � la cam�ra
    private Vector3 _previousCamPosition; // Position pr�c�dente de la cam�ra

    void Awake()
    {
        _cam = Camera.main.transform; // Obtenir la cam�ra principale
    }

    void Start()
    {
        _previousCamPosition = _cam.position; // Initialiser la position pr�c�dente
        _parallaxScales = new float[_layers.Length];

        // Calculer les �chelles de parallax
        for (int i = 0; i < _layers.Length; i++)
        {
            _parallaxScales[i] = _layers[i].position.y * -1; // Inverser la position pour le parallax
        }
    }

    void Update()
    {
        // Calculer le mouvement de la cam�ra
        Vector3 deltaMovement = _cam.position - _previousCamPosition;

        // Appliquer le parallax � chaque couche
        for (int i = 0; i < _layers.Length; i++)
        {
            float parallax = deltaMovement.y * _parallaxScales[i];
            Vector3 newLayerPosition = _layers[i].position;
            newLayerPosition.y += parallax;
            _layers[i].position = Vector3.Lerp(_layers[i].position, newLayerPosition, _smoothing * Time.deltaTime);
        }

        _previousCamPosition = _cam.position; // Mettre � jour la position pr�c�dente
    }
}