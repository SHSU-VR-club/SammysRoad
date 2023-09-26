//Script by Yannis Lagrosa.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Unseen Variables
    enum MonsterType { monsterOne, monsterTwo, monsterThree };
    
    // Select 16 transforms where this creature can teleport between.
    // This is separated into 4 phases, divided equally. After phase 4, the player is killed.
    [Header("Phase 1 Teleportation Points")]
    [SerializeField] Transform[] Phase1 = new Transform[4];
    [Header("Phase 2 Teleportation Points")]
    [SerializeField] Transform[] Phase2 = new Transform[4];
    [Header("Phase 3 Teleportation Points")]
    [SerializeField] Transform[] Phase3 = new Transform[4];
    [Header("Phase 4 Teleportation Points")]
    [SerializeField] Transform[] Phase4 = new Transform[4];

    [Header("Variables")]
    [SerializeField] int phase; // Keeps track of the phase.
    [SerializeField] MonsterType whoAmI; // Which monster is this?
    //make changes

    //TO-DO [For newbies]
    /*
        - Increment the phase after x seconds. [ Adjustable ]
            > When the phase is incremented, reposition the monster to a new point in the next phase.
        
        - Allow for each monster to have adjustable incrementTime values.


    */
    public void RepositionMonster()
        //I deleted this change
    {
        Debug.Log("REPOSITIONING");
        switch (phase)
        {
            case 1:
                transform.position = Phase1[Random.Range(0, 4)].position;
                break;
            case 2:
                transform.position = Phase2[Random.Range(0, 4)].position;
                phase = phase - 1;
                break;
            case 3:
                transform.position = Phase3[Random.Range(0, 4)].position;
                phase = phase - 1;
                break;
            case 4:
                transform.position = Phase4[Random.Range(0, 4)].position;
                phase = phase - 1;
                break;
            default:
                transform.position = Phase1[Random.Range(0, 4)].position;
                break;

        }                
    }
}
