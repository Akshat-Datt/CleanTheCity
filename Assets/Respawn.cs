using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Bin;
    [SerializeField] private Transform RespawnPoint;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other){
        Bin.transform.position = RespawnPoint.transform.position;
        
        Physics.SyncTransforms();
    }
}
