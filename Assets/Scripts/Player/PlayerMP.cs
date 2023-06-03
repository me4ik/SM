using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMP : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);
    }

}
