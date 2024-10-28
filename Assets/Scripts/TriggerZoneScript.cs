using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private HashSet<GameObject> objectsInZone = new HashSet<GameObject>(); // Зберігаємо унікальні об'єкти

    // Спрацьовує, коли об'єкт входить у тригерну зону
    private void OnTriggerEnter(Collider other)
    {
        // Перевіряємо тег об'єкта
        if (other.TryGetComponent(out PumpkinScript _))
        {
            objectsInZone.Add(other.gameObject);

            // Перевіряємо, чи є в зоні 4 об'єкти
            if (objectsInZone.Count >= 4)
            {
                Debug.Log("У тригері є 4 або більше гарбузів ");
            }
        }
    }

    // Спрацьовує, коли об'єкт виходить із тригерної зони
    private void OnTriggerExit(Collider other)
    {
        // Якщо об'єкт має потрібний тег і виходить із зони, видаляємо його зі списку
        if (other.TryGetComponent(out PumpkinScript _))
        {
            objectsInZone.Remove(other.gameObject);
        }
    }
}