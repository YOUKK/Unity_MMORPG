using UnityEngine;
using UnityEngine.Rendering;

public class TestCollision : MonoBehaviour
{
    /* Collision
     * 1) 나 혹은 상대한테 RigidBody가 있어야 한다 (IsKinematic : Off)
     * 2) 나한테 Collider가 있어야 한다 (IsTrigger : Off)
     * 3) 상대한테 Collider가 있어야 한다 (IsTrigger : Off)
     */


    /* Trigger
     * 1) 둘 다 Collider가 있어야 한다
     * 2) 둘 중 하나는 IsTrigger : On
     * 3) 둘 중 하나는 RigidBody가 있어야 한다
     */


    /* 좌표계
     * Local <-> World <-> Viewport <-> Screen (화면)
     */

    // 아래와 update문과 똑같은 기능
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            int sameMask = (1<<8) | (1<<9);

            // 마우스 클릭 Raycasting
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, sameMask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // Screen 좌표 (범위 : 해상도 크기)
    //        Vector3 input = Input.mousePosition;

    //        // Viewport 좌표 (범위 : 0~1)
    //        Vector3 viewport = Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //        // World 좌표
    //        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
    //        Vector3 dir = mousePosition - Camera.main.transform.position;
    //        dir = dir.normalized;

    //        Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

    //        // 마우스 클릭 Raycasting
    //        RaycastHit hit;
    //        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
    //        {
    //            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
    //        }
    //    }
    //}
}
