using UnityEngine;
using UnityEngine.Rendering;

public class TestCollision : MonoBehaviour
{
    /* Collision
     * 1) �� Ȥ�� ������� RigidBody�� �־�� �Ѵ� (IsKinematic : Off)
     * 2) ������ Collider�� �־�� �Ѵ� (IsTrigger : Off)
     * 3) ������� Collider�� �־�� �Ѵ� (IsTrigger : Off)
     */


    /* Trigger
     * 1) �� �� Collider�� �־�� �Ѵ�
     * 2) �� �� �ϳ��� IsTrigger : On
     * 3) �� �� �ϳ��� RigidBody�� �־�� �Ѵ�
     */


    /* ��ǥ��
     * Local <-> World <-> Viewport <-> Screen (ȭ��)
     */

    // �Ʒ��� update���� �Ȱ��� ���
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
            int sameMask = (1<<8) | (1<<9);

            // ���콺 Ŭ�� Raycasting
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
    //        // Screen ��ǥ (���� : �ػ� ũ��)
    //        Vector3 input = Input.mousePosition;

    //        // Viewport ��ǥ (���� : 0~1)
    //        Vector3 viewport = Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //        // World ��ǥ
    //        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
    //        Vector3 dir = mousePosition - Camera.main.transform.position;
    //        dir = dir.normalized;

    //        Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

    //        // ���콺 Ŭ�� Raycasting
    //        RaycastHit hit;
    //        if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
    //        {
    //            Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
    //        }
    //    }
    //}
}
