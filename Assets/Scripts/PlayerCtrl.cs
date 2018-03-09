using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//클래스에 System.Serializable이라는 어트리뷰트(Attribute)를 명시해야
//Inspector뷰에 노출이 된다.
[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
}

public class PlayerCtrl : MonoBehaviour {
    float h = 0.0f;
    float v = 0.0f;

    //자주 사용하는 컴포넌트는 반드시 변수에 할당한 후 사용
    Transform tr;
    
    //이동 속도 변수 (public으로 선언되어 Inspector에 노출됨)
    public float moveSpeed = 10.0f;

    //회전 속도 변수
    public float rotSpeed = 100.0f;

    // Use this for initialization
    void Start () {
        //스크립트 처음에 Transform 컴포넌트 할당
        tr = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("H = " + h.ToString());
        Debug.Log("V = " + v.ToString());

        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        //Translate(이동 방향 * Time.deltaTime * 변위값 * 속도, 기준좌표)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        //Vector3.up축을 기준으로 rotSpeed만큼의 속도로 회전
        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));

    }
}
