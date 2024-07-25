using UnityEngine;
using UnityEngine.UIElements;
public class DamageCounter : MonoBehaviour
{
    void Start()
    {
        // Получаем все объекты с тегом "Unit"
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");

        // Проходимся по всем найденным юнитам
        foreach (GameObject unit in units)
        {
            // Пример получения информации из компонента, допустим у вас есть компонент UnitConfig
            UnitConfig config = unit.GetComponent<UnitConfig>();
            if (config != null)
            {
                // Выводим информацию из конфигурации юнита
                Debug.Log($"Unit Name: {unit.name}, Health: {config.unitDamage}, Speed: {config.unitInitiative}");
            }
            else
            {
                Debug.LogWarning($"Unit {unit.name} does not have a UnitConfig component!");
            }
        }
    }

}