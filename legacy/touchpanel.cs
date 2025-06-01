using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class raycastselector //카메라 레이캐스트
{
    public static GameObject GetHitObject()
    {
        Transform camera = Camera.main.transform;   
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }
        return null;
    }
}

public class touchpanel : MonoBehaviour
{
    public GameObject currentButton; //현재 선택된 버튼 함수
    public GameObject screen1, screen2, screen3, screen4, screen5;  //스크린 오브젝트


    public float timeToSelect = 1f; //시간
    public float countDown; //선택 카운트다운
    public float screennum = 1f;    //스크린 넘버

    private bool IsValidTag(string tag) // 유효한 태그인지 확인하는 함수
    {
        switch (tag)
        {
            case "previbutton":
            case "travelbutton":
            case "annobutton":
            case "eventbutton":
            case "creditbutton":
            case "eiffelbutton":
            case "fuzibutton":
            case "piramidbutton":
            case "hanriverbutton":
            case "jinhaebutton":
            case "santorinibutton":
            case "chjapanbutton":
            case "mongoliabutton":
            case "sejongbutton":
                return true;
            default:
                return false;
        }
    }
    
    void Start()    //스크린 초기화
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
        screen4.SetActive(false);
        screen5.SetActive(false);
    }
    void Update()
    {


        GameObject hitButton = raycastselector.GetHitObject(); //레이캐스트로 맞는 버튼 찾기
        PointerEventData data = new PointerEventData(EventSystem.current);

        if (hitButton != null)  //버튼 클릭시 하이라이트
        {
            hitButton = hitButton.transform.parent.gameObject;  //부모 오브젝트 초기화
            string tag = hitButton.tag;
            currentButton = hitButton;

            if (IsValidTag(tag))
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);

            }
            else
            {
                currentButton = null;
                return; // 유효하지 않은 태그인 경우, 현재 버튼을 null로 설정하고 종료
            }

        }
        else    //비클릭 상태 하이라이트 끄기
        {
            ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            currentButton = null;   
            countDown = timeToSelect; 
        } 
            

        switch (screennum)
            {
                case 1:  //스크린 활성화 및 비활성화 1:메인 2:공지 3:이벤트 4:여행
                    screen1.SetActive(true);
                    screen2.SetActive(false);
                    screen3.SetActive(false);
                    screen4.SetActive(false);
                    screen5.SetActive(false);
                    break;
                case 2:
                    screen1.SetActive(false);
                    screen2.SetActive(true);
                    screen3.SetActive(false);
                    screen4.SetActive(false);
                    screen5.SetActive(false);
                    break;
                case 3:
                    screen1.SetActive(false);
                    screen2.SetActive(false);
                    screen3.SetActive(true);
                    screen4.SetActive(false);
                    screen5.SetActive(false);
                    break;
                case 4:
                    screen1.SetActive(false);
                    screen2.SetActive(false);
                    screen3.SetActive(false);
                    screen4.SetActive(true);
                    screen5.SetActive(false);
                    break;
                case 5:
                    screen1.SetActive(false);
                    screen2.SetActive(false);
                    screen3.SetActive(false);
                    screen4.SetActive(false);
                    screen5.SetActive(true);
                    break;
            }

        if (currentButton == hitButton)  //버튼 선택
        {
            countDown -= Time.deltaTime;
            if (countDown < 0.0f)
            {
                ExecuteEvents.Execute<IPointerClickHandler>
                    (currentButton, data, ExecuteEvents.pointerClickHandler);
                switch (currentButton.tag)
                {
                    case "previbutton":
                        screennum = 1;
                        break;
                    case "annobutton":
                        screennum = 2;
                        break;
                    case "eventbutton":
                        screennum = 3;
                        break;
                    case "travelbutton":
                        screennum = 4;
                        break;
                    case "creditbutton":
                        screennum = 5;
                        break;
                    case "eiffelbutton":
                        SceneManager.LoadScene("loading_eiffel_scene");
                        break;
                    case "fuzibutton":
                        SceneManager.LoadScene("loading_fuzi_scene");
                        break;
                    case "piramidbutton":
                        SceneManager.LoadScene("loading_piramid_scene");
                        break;
                    case "hanriverbutton":
                        SceneManager.LoadScene("loading_hanriver_scene");
                        break;
                    case "jinhaebutton":
                        SceneManager.LoadScene("loading_jinhae_scene");
                        break;
                    case "santorinibutton":
                        SceneManager.LoadScene("loading_santorini_scene");
                        break;
                    case "chjapanbutton":
                        SceneManager.LoadScene("loading_chjapan_scene");
                        break;
                    case "mongoliabutton":
                        SceneManager.LoadScene("loading_mongolia_scene");
                        break;
                    case "sejongbutton":
                        SceneManager.LoadScene("loading_sejong_scene");
                        break;
                    default:
                        break;

                }
                countDown = timeToSelect;
            }
        }
       
    }

}
