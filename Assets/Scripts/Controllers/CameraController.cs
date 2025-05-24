using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Define.CameraMode mode = Define.CameraMode.QuaterView;
    [SerializeField] private Vector3 delta = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField] private GameObject _player;

    public void SetPlayer(GameObject player) { _player = player; }

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(mode == Define.CameraMode.QuaterView)
        {
            if (_player.IsValid() == false)
                return;

            RaycastHit hit;
            if (Physics.Raycast(_player.transform.position, delta, out hit, delta.magnitude, LayerMask.GetMask("Block")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + delta;
                transform.LookAt(_player.transform);
            }
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        mode = Define.CameraMode.QuaterView;
        this.delta = delta;
    }
}
