﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene_hanriver : MonoBehaviour
{


    [SerializeField]


    private void Start()
    {
        StartCoroutine(LoadScene());
    }



    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation oper = SceneManager.LoadSceneAsync("hanriver_scene");
        //LoadSceneAsync ("게임씬이름"); 입니다.
        oper.allowSceneActivation = false;
        //allowSceneActivation 이 true가 되는 순간이 바로 다음 씬으로 넘어가는 시점입니다.

        float timer = 0.0f;
        while (!oper.isDone)
        {
            timer += Time.deltaTime;
            yield return null;



            if (timer > 5)
                oper.allowSceneActivation = true;





            //if (oper.progress >= 0.9f)
            //{
            //    progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
            //    //Image가 아니라 Slider의 경우 progressBar.value로 간단히 구현이 가능합니다만
            //    // 이미지가 찌그러진 것이 펴지는 것처럼 나오기 때문에 비추천하는 방법입니다.

            //    if (progressBar.fillAmount == 1.0f)
            //        oper.allowSceneActivation = true;
            //}
            //else
            //{
            //    progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, oper.progress, timer);
            //    if (progressBar.fillAmount >= oper.progress)
            //    {
            //        timer = 0f;
            //    }
            //}
        }
    }
}
