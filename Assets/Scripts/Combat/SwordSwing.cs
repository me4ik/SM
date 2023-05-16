using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwordSwing : MonoBehaviour
{
    public GameObject HitZona;
    private bool IsSwing = false;
    private float SwingTimer = 0f;
    public float SwingCD = 5;

    public Slider CDSlider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && PlayerClasses.ClassID == 2 && !IsSwing)
        {
            Swing();
            IsSwing = true;
            Debug.Log("Just Swinged" + SwingTimer);
            CDSlider.maxValue = SwingCD;
        }

        if (IsSwing)
        {
            SwingTimer -= Time.deltaTime;
            CDSlider.value = SwingTimer;
        }

        if (SwingTimer < 0)
        {
            IsSwing = false;
            SwingTimer = 0;
        }

    }

    public void Swing()
    {
        if (SwingTimer > 0f) return;
        HitZona.SetActive(true);
        SwingTimer = SwingCD;
        Invoke("SetFalse", 0.1f);
    }

    void SetFalse()
    {
        HitZona.SetActive(false);
    }

}
