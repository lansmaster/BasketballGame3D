using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HoopChecker _hoopChecker;

    private void OnEnable()
    {
        _hoopChecker.BallHitted += TeleportOnRandomPosition;
    }

    private void OnDisable()
    {
        _hoopChecker.BallHitted -= TeleportOnRandomPosition;
    }

    private void TeleportOnRandomPosition()
    {
        var XAxisPoint = Random.Range(-2.5f, 5f);
        var ZAxisPoint = Random.Range(-10f, 10f);

        transform.position = new Vector3(XAxisPoint, transform.position.y, ZAxisPoint);
    }
}
