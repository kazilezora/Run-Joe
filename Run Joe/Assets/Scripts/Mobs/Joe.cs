using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Joe : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    void Start()
    {
        Ayarlar();
    }

    void Update()
    {
        
    }

    void Ayarlar()
    {
        joystick = GameObject.FindObjectOfType<FixedJoystick>();
    }
}
