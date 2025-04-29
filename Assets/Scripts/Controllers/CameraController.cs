using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Define.CameraMode mode = Define.CameraMode.QuaterView;
    [SerializeField] private Vector3 delta = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(mode == Define.CameraMode.QuaterView)
        {
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, delta, out hit, delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - player.transform.position).magnitude * 0.8f;
                transform.position = player.transform.position + delta.normalized * dist;
            }
            else
            {
                transform.position = player.transform.position + delta;
                transform.LookAt(player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        mode = Define.CameraMode.QuaterView;
        this.delta = delta;
    }
}
