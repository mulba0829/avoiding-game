using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontroller : MonoBehaviour
{   Rigidbody2D rb;       //���� ������Ʈ�� �ִ� rigidbody2D ������Ʈ�� ���� ����
    public float speed = 1; //���ǵ� ���� ����

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
        if (isDeath) return; //���� ���¶�� �Լ� Ż��
        Move();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); // Ű �Է� a, d Ȥ�� <-, -> �� �Է¿� ���� -1~1�� ��ȯ
                                                  // �Է��� ���ٸ� 0 ��ȯ.
        rb.velocity = new Vector2(x * speed, 0);// rb.veloicity�� ���� �ӵ� ����, �¿�θ� �̵��ϱ⿡ y���� 0.

        anit.SetBool("isMove", x != 0 ? true : false); // x�� ���� 0�� �ƴ϶�� true, �´ٸ� false ��ȯ
                                                       //�� ���� ���� Animator�� �߰��� isMove�� �� ����

        if (x != 0 && x != transform.localScale.x)
            transform.localScale = new Vector3(x*5,5,5); // �̵� ���׿� ���� �̹��� ������ �� �ֵ��� x�࿡ x ���� �� ����
    }

    public void Death()
    { 
        isDeath = true; // ���� ���·� ����
        GameManager.i.GameOver(); //GameManager�� ���� ���� �Լ� ȣ��

        anit.SetTrigger("Death");  //���� �ִϸ��̼� �÷���
        Destroy(gameObject, 1f);   //1�� �� ������Ʈ ����
    }
}

