using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontroller : MonoBehaviour
{   Rigidbody2D rb;       //같은 오브젝트에 있는 rigidbody2D 컴포넌트를 담을 변수
    public float speed = 1; //스피드 제어 변수

    Animator anit;

    bool isDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anit = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath) return; //죽음 상태라면 함수 탈출
        Move();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); // 키 입력 a, d 혹은 <-, -> 의 입력에 따라 -1~1을 반환
                                                  // 입력이 없다면 0 반환.
        rb.velocity = new Vector2(x * speed, 0);// rb.veloicity를 통해 속도 적용, 좌우로만 이동하기에 y축은 0.

        anit.SetBool("isMove", x != 0 ? true : false); // x의 값이 0이 아니라면 true, 맞다면 false 반환
                                                       //이 값에 따라 Animator에 추가한 isMove의 값 결정

        if (x != 0 && x != transform.localScale.x)
            transform.localScale = new Vector3(x*5,5,5); // 이동 방항에 따라 이미지 반전할 수 있도록 x축에 x 변수 값 대입
    }

    public void Death()
    { 
        isDeath = true; // 죽은 상태로 변경
        GameManager.i.GameOver(); //GameManager의 게임 오버 함수 호출

        anit.SetTrigger("Death");  //죽음 애니메이션 플레이
        Destroy(gameObject, 1f);   //1초 뒤 오브젝트 삭제
    }
}

