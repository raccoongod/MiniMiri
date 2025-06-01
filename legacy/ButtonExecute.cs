using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonExecute : MonoBehaviour {

    public float timeToSelect = 1f;
    public float countDown;
    private GameObject currentButton;
    public GameObject button1;
    //  private Clicker clicker = new Clicker();



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        GameObject hitButton = null;
        PointerEventData data = new PointerEventData(EventSystem.current);
        if(Physics.Raycast(ray,out hit))
        {
            if(hit.transform.gameObject.tag == "Button")
            {
                hitButton = hit.transform.parent.gameObject;
            }
        }
        if(currentButton != hitButton)
        {
            if(currentButton != null)  //하이라이트끄기
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton; 

            if(currentButton != null) //하이라이트
            {
                ExecuteEvents.Execute<IPointerEnterHandler>
                    (currentButton, data, ExecuteEvents.pointerEnterHandler);
                countDown = timeToSelect;
                
            }
        }
        if(currentButton!=null)
        {
            countDown -= Time.deltaTime;
            if(countDown<0.0f)
            {
                ExecuteEvents.Execute<IPointerClickHandler>
                    (currentButton, data, ExecuteEvents.pointerClickHandler);
                button1.SetActive(false);
                countDown = timeToSelect;
            }
        }
	}
}
