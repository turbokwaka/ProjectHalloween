using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickupPumpkin : MonoBehaviour
{
    [SerializeField] private Text counter;
    private int _pumpkinCounter;

    private void Start()
    {
        counter.text = $"Bro u need to pickup pumpkins!!!";
    }
}