using UnityEngine;
using System.Collections;

public class ChangeSkyBox : MonoBehaviour
{
    
    // 스카이박스의 혼합을 결정하는 변수. 1이면 밤, 0이면 낮
  public float blendFactor = 0f;
    public static float another = 0f;
    void Update()
    {
        another = blendFactor;
        // blendFactor 값을 참고로 렌더 설정에 지정한 스카이박스 재질의 속성을 변경
        // _Blend라는 이름의 속성을 지정. ( 속성 이름은 셰이더 코드에서 확인이 가능함. )
        RenderSettings.skybox.SetFloat("_Blend", blendFactor);
      
    }
}