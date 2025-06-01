 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class option : MonoBehaviour {

    public int optioncheck = 0;
    public int saveoption = 0; // 0이면 고사양 1이면 저사양 기본값 : 0;
	// Use this for initialization
	void Start () {

        saveoption = PlayerPrefs.GetInt("spechigh");    //값받아서저장
    }
	
	// Update is called once per frame
	void Update () {
        
        PlayerPrefs.SetInt("spechigh", optioncheck);    //저장시키기
        PlayerPrefs.Save(); //세이브



    }
}
