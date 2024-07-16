using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // ���� ��� ���������� (��������, �����)
    public float smooth = 5.0f; // ����������� �������� ������
    public Vector3 offset = new Vector3(0, 2, -5); // �������� ������ ������������ ����
    public Vector2 minLimits = new Vector2(-10, -5); // ����������� ����������
    public Vector2 maxLimits = new Vector2(10, 5); // ������������ ����������

    private void LateUpdate()
    {
        Vector3 newPosition = target.position + offset;
        newPosition.x = Mathf.Clamp(newPosition.x, minLimits.x, maxLimits.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minLimits.y, maxLimits.y);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smooth);
    }

    private void OnDrawGizmos()
    {
        // ��������� ������ ����������� ������
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(minLimits.x, minLimits.y, transform.position.z), new Vector3(maxLimits.x, minLimits.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(minLimits.x, minLimits.y, transform.position.z), new Vector3(minLimits.x, maxLimits.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(minLimits.x, maxLimits.y, transform.position.z), new Vector3(maxLimits.x, maxLimits.y, transform.position.z));
        Gizmos.DrawLine(new Vector3(maxLimits.x, minLimits.y, transform.position.z), new Vector3(maxLimits.x, maxLimits.y, transform.position.z));
    }
}
