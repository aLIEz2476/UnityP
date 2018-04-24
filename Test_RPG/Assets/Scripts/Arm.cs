using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {
    public float m_fAttackSpeed; public float m_fRotSpeed;
    bool m_bAttack = false, m_bRelease = true;
    float m_fCurRot = 0, m_fMaxRot = 45;
    public GameObject m_objArm;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        if (m_bRelease)
            ReleaseArmUpdate();

	}


    protected void MoveArm(float rotspeed)
    {
        float fRotSpeed = rotspeed * Time.deltaTime;
        m_objArm.transform.Rotate(Vector3.right * fRotSpeed);
    }


    protected IEnumerator AttackArm()
    {
        float fMaxRot = 45, fCurRot = 0;
        while (fCurRot < fMaxRot)
        {
            MoveArm(m_fRotSpeed);
            fCurRot += m_fRotSpeed;
            yield return null;
        }
        StartCoroutine("ReleaseArm");

    }

    protected IEnumerator ReleaseArm()
    {
        float fMaxRot = 45, fCurRot = 0;
        while (fCurRot < fMaxRot)
        {
            MoveArm(-m_fRotSpeed);
            fCurRot += m_fRotSpeed;
            yield return null;
        }
        m_bAttack = false;

    }

    // 코루틴을 사용하지 않을 경우, 맴버변수를 만들어 매프레임마다 호출확인을 해야한다.
    protected void AttackArmUpdate()
    {
        if (m_fCurRot < m_fMaxRot)
        {
            MoveArm(m_fRotSpeed);
            m_fCurRot += m_fRotSpeed;

        }
        else
        {
            m_bAttack = false;
            m_fCurRot = 0;
        }
    }

    protected void ReleaseArmUpdate()
    {
        if (m_fCurRot < m_fMaxRot)
        {
            MoveArm(-m_fRotSpeed);
            m_fCurRot += m_fRotSpeed;

        }
        else
        {
            m_bAttack = false;
            m_fCurRot = 0;
            m_bRelease = false;
        }
    }

    public void Init(float Attack)
    {
        m_fAttackSpeed = Attack;
    }
}
