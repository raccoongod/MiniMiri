using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class touchpanel : MonoBehaviour
{
    private GameObject currentButton;
    public GameObject screen1, screen2,screen3,screen4,screen5;
    //  private Clicker clicker = new Clicker();

    public float timeToSelect = 1f; //시간
    public float countDown;
    public float screennum = 1f;


    // Use this for initialization
    void Start()
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;   //카메라 레이캐스트
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);

        if (Physics.Raycast(ray, out hit))  //버튼 태그 맞는거 찾기
        {
            if (hit.transform.gameObject.tag == "previbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if(hit.transform.gameObject.tag == "travelbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "annobutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if(hit.transform.gameObject.tag == "eventbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "creditbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "eiffelbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "fuzibutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "piramidbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "hanriverbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "jinhaebutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "santorinibutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "chjapanbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "mongoliabutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            else if (hit.transform.gameObject.tag == "sejongbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
        }
        if (screennum == 1) //스크린 활성화 및 비활성화 1:메인 2:공지 3:이벤트 4:여행
        {
            screen1.SetActive(true);
            screen2.SetActive(false);
            screen3.SetActive(false);
            screen4.SetActive(false);
            screen5.SetActive(false);
        }
        if (screennum == 2)
        {
            screen1.SetActive(false);
            screen2.SetActive(true);
            screen3.SetActive(false);
            screen4.SetActive(false);
            screen5.SetActive(false);
        }
        if (screennum == 3)
        {
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(true);
            screen4.SetActive(false);
            screen5.SetActive(false);
        }
        if (screennum == 4)
        {
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(false);
            screen4.SetActive(true);
            screen5.SetActive(false);
        }
        if (screennum == 5)
        {
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(false);
            screen4.SetActive(false);
            screen5.SetActive(true);
        }
        if (currentButton != hitButton)
        {
            if (currentButton != null)  //하이라이트끄기
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;

            if (currentButton != null) //하이라이트
            {
                ExecuteEvents.Execute<IPointerEnterHandler>
                    (currentButton, data, ExecuteEvents.pointerEnterHandler);
                countDown = timeToSelect;

            }
        }

        if (currentButton != null)  //버튼 선택
        {
            countDown -= Time.deltaTime;
            if (countDown < 0.0f)
            {
                ExecuteEvents.Execute<IPointerClickHandler>
                    (currentButton, data, ExecuteEvents.pointerClickHandler);
                if(currentButton.tag == "previbutton")
                {
                    screennum = 1;
                }
                if (currentButton.tag == "annobutton")
                {
                    screennum = 2;
                }
                if (currentButton.tag == "eventbutton")
                {
                    screennum = 3;
                }
                if (currentButton.tag == "travelbutton")
                {
                    screennum = 4;
                }
                if (currentButton.tag == "creditbutton")
                {
                    screennum = 5;
                }
                if (currentButton.tag == "eiffelbutton")
                {
                    SceneManager.LoadScene("loading_eiffel_scene");
                }
                if (currentButton.tag == "fuzibutton")
                {
                    SceneManager.LoadScene("loading_fuzi_scene");
                }
                if (currentButton.tag == "piramidbutton")
                {
                    SceneManager.LoadScene("loading_piramid_scene");
                }
                if (currentButton.tag == "hanriverbutton")
                {
                    SceneManager.LoadScene("loading_hanriver_scene");
                }
                if (currentButton.tag == "jinhaebutton")
                {
                    SceneManager.LoadScene("loading_jinhae_scene");
                }
                if (currentButton.tag == "santorinibutton")
                {
                    SceneManager.LoadScene("loading_santorini_scene");
                }
                if (currentButton.tag == "chjapanbutton")
                {
                    SceneManager.LoadScene("loading_chjapan_scene");
                }
                if (currentButton.tag == "mongoliabutton")
                {
                    SceneManager.LoadScene("loading_mongolia_scene");
                }
                if (currentButton.tag == "sejongbutton")
                {
                    SceneManager.LoadScene("loading_sejong_scene");
                }
                countDown = timeToSelect;
            }
        }
    }
}
