using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public void TargetHit()
    {
        GameManager.Instance.TargetHit(1);
    }
}
