using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanDetect
{
    
    void React(Transform reactionPoint);
    void Patrol();
    
}
