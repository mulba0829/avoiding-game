using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obastcleSpawnerComponent : MonoBehaviour
{
    public GameObject prefabObj; // ���� ������Ʈ ��� ����
    public float spawnRate = 0;  // ���� ������Ʈ ���� ����
    public float minRate = 3;    // ���� ������Ʈ ���� ���� �ּڰ�
    public float maxRate = 6;    // ���� ������Ʈ ���� ���� �ִ�

    public float spawnYPos = 0;  //���� ������Ʈ ���� Y�� ��ġ
    public float spawnMinXPos = 0;//���� ������Ʈ ���� x�� ��ġ. ���� ���� ��.
    public float spawnMaxXPos = 0;//���� ������Ʈ ���� x�� ��ġ, ���� ������ ��.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());    //�ݺ��ؼ� Spawn�Լ��� ȣ��� �� �ֵ��� �ڷ�ƾ �Լ��� �ۼ��Ͽ� ȣ��
    }

    void Spawn()
    {
        float x = Random.Range(spawnMinXPos, spawnMaxXPos); //x�� �ִ��ּһ����� ������ �� ��ȯ
        Instantiate(prefabObj, new Vector3(x, spawnYPos, 0), Quaternion.identity); //�ش� ��ġ�� ���ؿ�����Ʈ ����

    }
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            spawnRate = Random.Range(minRate,maxRate); //������ ���� ������ ����
            yield return new WaitForSeconds(spawnRate); //������ �ð���ŭ ���
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
