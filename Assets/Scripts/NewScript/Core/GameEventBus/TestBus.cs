using UnityEngine;

public class TestBus : MonoBehaviour
{
    private void Start()
    {
        GameEventBus bus = new GameEventBus();
        bus.Subcribe<int>(OnNumberReceived);
        bus.Publish(42);
    }
    void OnNumberReceived(int value)
    {
        Debug.Log("Got The Number: " + value);
    }
}
