using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class MoveButtonExecute : MonoBehaviour
{

    public float timeToSelect = 2f;
    public float countDown;
    private GameObject currentButton;
   // public Transform button;
    public static float MSActive = 1f;
    public bool toggle = true;
    public GameObject ActText, NonActText;
    //  private Clicker clicker = new Clicker();



    // Use this for initialization
    void Start()
    {
        ActText.SetActive(false);
        NonActText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "MSButton")
            {
                hitButton = hit.transform.parent.gameObject;
            }
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
                toggle = true;


            }
        }
        if (currentButton != null)
        {
            countDown -= Time.deltaTime;

            if (countDown < 0.0f && toggle == true)
            {
                if (MSActive == 0 )
                {

                    MSActive = 1;
                    toggle = false;
                    ActText.SetActive(false);
                    NonActText.SetActive(true);

                }
                else if (MSActive == 1)
                {
                    MSActive = 0;
                    toggle = false;
                    ActText.SetActive(true);
                    NonActText.SetActive(false);

                }
            }
          
        }
    }
}
