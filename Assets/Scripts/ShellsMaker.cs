using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellsMaker : MonoBehaviour
{
    [SerializeField] GameObject _arrowPrefab;
    [SerializeField] GameObject _spawnPointTransform;
    [SerializeField] Archer _archer;
    [SerializeField] Transform _archerHand;

    private void FixedUpdate()
    {
        if (InputHandler.instance.PiuPiu)
        {
            SpawnShell();
            InputHandler.instance.PiuPiu = false;
        }
    }

    private void Awake()
    {
        
    }
    private void SpawnShell()
    {
       Rigidbody2D bullet =  Instantiate(_arrowPrefab, _spawnPointTransform.transform.position, _archer.NewArcherHandPosition()).GetComponent<Rigidbody2D>();
        bullet.AddForce(_archer.GetHandRotation()*2,ForceMode2D.Impulse);
    }
}
