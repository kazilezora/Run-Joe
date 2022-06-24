using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Joe : MonoBehaviour
{
    [SerializeField] private float yurumeHizi, kosmaHizi,enerjiYenileme,enerjiHarcama;
    private float enerji;
    private bool hareketEdebilirmi = true,kosuyormu,yatayHareket,dikeyHareket;
    Rigidbody2D fizik;
    Animator animator;
    private FixedJoystick joystick;
    [SerializeField] private EtkilesimTusu etkilesimTusu;
    [SerializeField] private Text enerjiGostergesi;
    void Start()
    {
        Ayarlar();
    }

    void Update()
    {
        Hareket();
        Kos();
    }

    void Ayarlar()
    {
        joystick = GameObject.FindObjectOfType<FixedJoystick>();
        etkilesimTusu = GameObject.FindObjectOfType<EtkilesimTusu>();
        enerjiGostergesi = GameObject.Find("Enerji Gostergesi").GetComponent<Text>();
        fizik = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Hareket()
    {
        //Yatay eksende hareket:
        if(joystick.Horizontal >= 0.2f)
        {
            yatayHareket = true;
            if (kosuyormu)
            {
                fizik.position += new Vector2(kosmaHizi * Time.deltaTime, 0);
            }
            else
            {
                fizik.position += new Vector2(yurumeHizi * Time.deltaTime, 0);
            }
        }
        else if(joystick.Horizontal <= -0.2f)
        {
            yatayHareket = true;
            if (kosuyormu)
            {
                fizik.position += new Vector2(kosmaHizi * Time.deltaTime*-1, 0);
            }
            else
            {
                fizik.position += new Vector2(yurumeHizi * Time.deltaTime*-1, 0);
            }
        }
        else
        {
            fizik.position += new Vector2(0, 0);
            yatayHareket = false;
        }

        //dikey eksende hareket:
        if (joystick.Vertical >= 0.2f)
        {
            dikeyHareket = true;
            if (kosuyormu)
            {
                fizik.position += new Vector2(0, kosmaHizi*Time.deltaTime);
            }
            else
            {
                fizik.position += new Vector2(0, yurumeHizi*Time.deltaTime);
            }
        }
        else if (joystick.Vertical <= -0.2f)
        {
            dikeyHareket = true;
            if (kosuyormu)
            {
                fizik.position += new Vector2(0, kosmaHizi*Time.deltaTime*-1);
            }
            else
            {
                fizik.position += new Vector2(0, yurumeHizi * Time.deltaTime * -1);
            }
        }
        else
        {
            fizik.position += new Vector2(0, 0);
            dikeyHareket = false;
        }

        if(joystick.Horizontal >= 0.2f && !(joystick.Vertical >= 0.2f || joystick.Vertical <= -0.2f))
        {
            //sað
            animator.SetFloat("yon", 0);
        }
        else if(joystick.Horizontal >= 0.2f && joystick.Vertical <= -0.2f)
        {
            //sað alt çapraz
            //animator.SetFloat("yon", 1);
        }
        else if(joystick.Vertical <= -0.2f && !(joystick.Horizontal>= 0.2f || joystick.Horizontal <= -0.2f))
        {
            //aþaðý
            animator.SetFloat("yon", 1);
        }
        else if(joystick.Horizontal <= -0.2f && joystick.Vertical <= -0.2f)
        {
            //sol alt çapraz
            //animator.SetFloat("yon", 3);
        }
        else if(joystick.Horizontal <= -0.2f && !(joystick.Vertical >= 0.2f || joystick.Vertical <= -0.2f))
        {
            //sol
            animator.SetFloat("yon", 2);
        }
        else if (joystick.Horizontal <= -0.2f && joystick.Vertical >= 0.2f)
        {
            //sol üst çapraz
            //animator.SetFloat("yon", 5);
        }
        else if (joystick.Vertical >= 0.2f && !(joystick.Horizontal >= 0.2f || joystick.Horizontal <= -0.2f))
        {
            //üst
            print("üst");
            animator.SetFloat("yon", 3);
        }
        else if (joystick.Horizontal >= 0.2f && joystick.Vertical >= 0.2f)
        {
            //sað üst çapraz
            //animator.SetFloat("yon", 7);
        }

        if (yatayHareket || dikeyHareket)
        {
            animator.SetBool("yuru", true);
        }
        else
        {
            animator.SetBool("yuru", false);
        }
    }

    void Kos()
    {
        enerjiGostergesi.text = System.Convert.ToInt32(enerji).ToString();
        if ((etkilesimTusu.basilimi || Input.GetAxis("Jump") > 0) && enerji > 0)
        {
            kosuyormu = true;
            enerji += Time.deltaTime * enerjiHarcama*-1;
        }
        else
        {
            kosuyormu = false;
            if(enerji < 100)
            {
                enerji += Time.deltaTime * enerjiYenileme;
            }
            else
            {
                enerji = 100;
            }
        }
    }

}
