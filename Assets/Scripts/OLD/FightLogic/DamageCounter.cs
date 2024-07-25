using UnityEngine;
using UnityEngine.UIElements;
public class DamageCounter : MonoBehaviour
{
    void Start()
    {
        // �������� ��� ������� � ����� "Unit"
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");

        // ���������� �� ���� ��������� ������
        foreach (GameObject unit in units)
        {
            // ������ ��������� ���������� �� ����������, �������� � ��� ���� ��������� UnitConfig
            UnitConfig config = unit.GetComponent<UnitConfig>();
            if (config != null)
            {
                // ������� ���������� �� ������������ �����
                Debug.Log($"Unit Name: {unit.name}, Health: {config.unitDamage}, Speed: {config.unitInitiative}");
            }
            else
            {
                Debug.LogWarning($"Unit {unit.name} does not have a UnitConfig component!");
            }
        }
    }

}