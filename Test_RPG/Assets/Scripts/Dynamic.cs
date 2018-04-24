using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    int m_nKeyCount; public float m_fMoveSpeed; public float m_fRotSpeed;
    public GameObject m_objArm; public Arm m_cArm; bool m_bAttack;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Debug.Log("Space hit : " + m_nKeyCount);
        //    m_nKeyCount++;
        //}
        
        InputProcess();
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), string.Format("{0}", m_nKeyCount));
        // Rect(x, y, 넓이, 높이)

    }
    // 테스트용 UI셔틀

   
    // 코루틴을 사용하면, 매 프레임마다 반복문의 한 단계가 실행되므로, 
    // 따로 끝날 때 처리할 필요가 없으며, 해당반복의 단계가 끝나면 실행이 끝난다
    // 실행중 지역변수들은 코루틴이 끝날 때까지 유지된다.
    

    void InputProcess()
    {
        float fMoveDist = m_fMoveSpeed * Time.deltaTime;
        float fRotAngle = m_fRotSpeed * Time.deltaTime;

        
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * fMoveDist);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * fMoveDist);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -fRotAngle);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * fRotAngle);
        }

        if (Input.GetMouseButtonDown(0))
        {
            // 일반적으로 코루틴을 이용할 때에는 코루틴을 부를 때마다
            // 해당 반복문이 실행되므로, 중복해서 계속 동작한다.
            

            if(m_bAttack==false)
            {
                StartCoroutine("AttackArm");
                m_bAttack = true;
            }

            m_cArm.Init(50);

        }
    }
}
