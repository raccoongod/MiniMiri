using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    public GameObject m_light1, m_light2;
    public ChangeSkyBox sky;
    public float num = 0.0f;
    
// Use this for initialization
void Start()
    {
           }
    private void Update()
    {

        if(ChangeSkyBox.another < 0.6)
        {
            m_light1.SetActive(false);
            m_light2.SetActive(false);
        }
        else
        {
            m_light1.SetActive(true);
            m_light2.SetActive(true);
        }

        
    }
 }

