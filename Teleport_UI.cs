using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class Teleport_UI : MonoBehaviour
{
    private GameObject currentButton;
    public GameObject BUTTON_SCREEN, UI_SCREEN;
    public GameObject player,teleportpoint;
    //  private Clicker clicker = new Clicker();

    public float timeToSelect = 1f; //시간
    public float countDown;
    public float screennum = 1f;
  //  public float x, y, z = 0f;


    // Use this for initialization
    void Start()
    {
        BUTTON_SCREEN.SetActive(true);
        UI_SCREEN.SetActive(false);
  
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
            if (hit.transform.gameObject.tag == "actbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
            if (hit.transform.gameObject.tag == "affbutton")
            {
                hitButton = hit.transform.parent.gameObject;
            }

        }
        if (screennum == 1) //스크린,버튼 활성 비활성 토글
        {
            BUTTON_SCREEN.SetActive(true);
            UI_SCREEN.SetActive(false);
        }
        if (screennum == 2) 
        {
            BUTTON_SCREEN.SetActive(false);
            UI_SCREEN.SetActive(true);
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
                if (currentButton.tag == "actbutton")
                {
                    screennum = 2;
                }
                if (currentButton.tag == "affbutton")
                {
                    player.transform.position = teleportpoint.transform.position;
                    //player.transform.position = new Vector3(x, y, z);

                    screennum = 1;
                }
              
                countDown = timeToSelect;
            }
        }
    }
}
