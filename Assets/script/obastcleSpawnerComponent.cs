using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obastcleSpawnerComponent : MonoBehaviour
{
    public GameObject prefabObj; // 방해 오브젝트 담는 변수
    public float spawnRate = 0;  // 방해 오브젝트 생성 간격
    public float minRate = 3;    // 방해 오브잭트 생성 간격 최솟값
    public float maxRate = 6;    // 방해 오브젝트 생성 간격 최댓값

    public float spawnYPos = 0;  //방해 오브젝트 생성 Y축 위치
    public float spawnMinXPos = 0;//방해 오브젝트 생성 x축 위치. 제일 왼쪽 값.
    public float spawnMaxXPos = 0;//방해 오브젝트 생성 x축 위치, 가장 오른쪽 값.

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());    //반복해서 Spawn함수가 호출될 수 있도록 코룬틴 함수로 작성하여 호출
    }

    void Spawn()
    {
        float x = Random.Range(spawnMinXPos, spawnMaxXPos); //x축 최대최소사이의 임의의 값 반환
        Instantiate(prefabObj, new Vector3(x, spawnYPos, 0), Quaternion.identity); //해당 위치로 방해오브젝트 생성

    }
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            spawnRate = Random.Range(minRate,maxRate); //임의의 생성 딜레이 설정
            yield return new WaitForSeconds(spawnRate); //딜레이 시간만큼 대기
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
