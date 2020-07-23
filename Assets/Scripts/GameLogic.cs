using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    PartyMember[] Character = new PartyMember[4]; // In the box, put numbers from 0 to 3.

    // Start is called before the first frame update
    void Start()
    {

        Character[0] = new PartyMember(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFile_ExperiencePoints()
    {

    }
}
