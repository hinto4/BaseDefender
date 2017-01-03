using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class TextBehaviour : MonoBehaviour
{
    private FirstPersonController _player;

    void Start()
    {
        _player = FindObjectOfType<FirstPersonController>();
    }

    void Update()
    {
        transform.rotation = _player.transform.rotation;
    }
}
