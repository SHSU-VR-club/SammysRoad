//Script by Yannis Lagrosa.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    enum State { on, off };
    [SerializeField] State flashlightState;
    [SerializeField] float lightDist;
    [SerializeField] GameObject raySpawn;
    [SerializeField] GameObject tallman;
    [SerializeField] GameObject tricycle;
    [SerializeField] GameObject witchbitch;

    void FixedUpdate()
    {
        if (flashlightState == State.on)
        {
            Debug.Log($"Preparing Ray Shoot");
            LayerMask monsterLayer = LayerMask.GetMask("Monster");
            Ray ray = new Ray(raySpawn.transform.position, raySpawn.transform.position + raySpawn.transform.up);
            if (Physics.Raycast(raySpawn.transform.position, raySpawn.transform.up, out RaycastHit hitInfo, lightDist, monsterLayer))
            {
                Debug.Log($"Ray Shot");
                Debug.Log($"Object hit {hitInfo.collider.gameObject}");
                if (hitInfo.collider.tag == "Tallman")
                {
                    tallman.GetComponent<Monster>().RepositionMonster();
                    Debug.Log($"Repositioning Tallman.");              
                }
            }           
        }    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = flashlightState == State.on ? Color.yellow : Color.red;
        Gizmos.DrawLine(raySpawn.transform.position, raySpawn.transform.position + raySpawn.transform.up * lightDist);    
    }
}
