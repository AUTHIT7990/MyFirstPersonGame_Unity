using UnityEngine;

public class BatteryItem : MonoBehaviour, IInteractable
{
    [SerializeField] public string interactionText = "Press E to collect";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectBattery(); // เรียกฟังก์ชันเก็บ Item
        }
    }

    // ฟังก์ชัน CollectBattery() ที่จะถูกเรียกเมื่อ Item ถูกเก็บ
    private void CollectBattery()
    {
        Debug.Log("Battery Collected!");

        // บอก InventoryManager ว่าเก็บแบตเตอรี่แล้ว
        // InventoryManager.Instance: เข้าถึง Instance เดียวของ InventoryManager (Singleton Pattern)
        // AddBattery(): เรียกฟังก์ชันเพิ่มแบตเตอรี่
        if (InventoryManager.Instance != null) // ตรวจสอบป้องกัน NullReferenceException
        {
            InventoryManager.Instance.AddBattery();
        }

        // Destroy(gameObject): ทำลาย GameObject แบตเตอรี่หลังจากเก็บ
        Destroy(gameObject);
    }

    public void Interact()
    {
        CollectBattery();
    }

    public string GetInteractionText()
    {
        return interactionText;
    }
}