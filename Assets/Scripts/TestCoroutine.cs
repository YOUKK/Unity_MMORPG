using System.Collections;
using UnityEngine;

// 보통 게임에서는 공용으로 사용하는 타임 시스템이 있다.
// 만약 내가 4초 후에 ~를 하고싶어. 하면 타임 시스템이 4초 후에 알려주는 식으로 사용한다.

// update에서 시간+Time.DeltaTime 식으로 시간이 흐른 정도를 파악하는 방법도 있지만
// 이 방법은 이 기능을 쓰는 오브젝트가 많아진다면 성능 이슈가 있다.
// 이럴 때 코루틴 사용이 유리하다.

public class TestCoroutine : MonoBehaviour
{
    class Test
    {
        public int Id = 0;
    }


    // 1. 함수의 상태를 저장/복원 가능!
        // -> 엄청 오래 걸리는 작업을 잠시 끊거나
        // -> 원하는 타이밍에 함수를 잠시 Stop/복원하는 경우
    // 2. return -> 우리가 원하는 타입으로 가능 (class도 가능)
    class CoroutineTest : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Test { Id = 1 };
            yield return new Test { Id = 2 };
            yield return new Test { Id = 3 };
            yield return new Test { Id = 4 };
            yield return new Test { Id = 5 };


            //yield return 1;
            //yield return 2;
            //yield return 3;
            //yield return 4;
            //yield return 5;

            // yield break; // 코루틴 탈출
        }
    }


    Coroutine co;

    void Start()
    {
        CoroutineTest test = new CoroutineTest();
        foreach(System.Object t in test)
        {
            Test value = (Test)t;
            Debug.Log(value.Id);

            //int value = (int)t;
            //Debug.Log(value);
        }


        co = StartCoroutine("ExplodeAfterSeconds", 4.0f);
        StartCoroutine("CoStopExplode", 2.0f);
    }

    // 코루틴 함수는 앞에 Co를 붙이는 것과 같이, 코루틴 함수만의 네이밍을 짓는 게 좋다.
    IEnumerator CoStopExplode(float seconds)
    {
        Debug.Log("Stop Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Stop Excute!!!");
        if(co != null)
        {
            StopCoroutine(co);
            co = null;
        }
    }

    IEnumerator ExplodeAfterSeconds(float seconds)
    {
        Debug.Log("Explode Enter");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Explode Execute!!!");
        co = null;
    }
}
