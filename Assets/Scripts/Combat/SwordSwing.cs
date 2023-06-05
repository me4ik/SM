using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SwordSwing : NetworkBehaviour
{
    private PlayerClasses clas;

    public GameObject HitZona;
    private bool IsSwing = false;
    private float SwingTimer = 0f;
    public float SwingCD = 5;

    //public Slider CDSlider;

    private void Start()
    {
        clas = GetComponent<PlayerClasses>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && clas.ClassID == 2 && !IsSwing)
        {
            if (SwingTimer > 0f) return;
            SwingTimer = SwingCD;
            CmdSwing();
            Invoke(nameof(CmdSetFalse), 0.1f);
            IsSwing = true;
            //CDSlider.maxValue = SwingCD;
        }

        if (IsSwing)
        {
            SwingTimer -= Time.deltaTime;
            //CDSlider.value = SwingTimer;
        }

        if (SwingTimer < 0)
        {
            IsSwing = false;
            SwingTimer = 0;
        }

    }

    [Command]
    public void CmdSwing()
    {
        Debug.Log("Just Swinged" + SwingTimer);
        HitZona.SetActive(true);       
    }

    [Command]
    void CmdSetFalse()
    {
        HitZona.SetActive(false);
    }

}
