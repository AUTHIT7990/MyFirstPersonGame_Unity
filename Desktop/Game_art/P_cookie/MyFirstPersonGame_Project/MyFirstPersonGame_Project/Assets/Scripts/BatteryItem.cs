using UnityEngine; // บรรทัดนี้มีอยู่แล้ว

// BatteryItem : MonoBehaviour, IInteractable: คลาสนี้สืบทอดจาก MonoBehaviour และใช้ Interface IInteractable
public class BatteryItem : MonoBehaviour, IInteractable
{
    // SerializeField: ทำให้ตัวแปร private แสดงใน Inspector เพื่อให้สามารถกำหนดค่าจาก Unity Editor ได้ [cite: 324]
    // public string interactionText: ตัวแปรข้อความที่จะแสดงเมื่อมอง Item นี้
    [SerializeField] public string interactionText = "Press E to collect";

    // OnTriggerEnter: ถูกเรียกเมื่อ Collider อื่นๆ เข้ามาชนกับ Trigger Collider ของ GameObject นี้ [cite: 5]
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่า GameObject ที่เข้ามาชนมี Tag เป็น "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            // ถ้าชนกับ Player ให้เรียกฟังก์ชันเก็บ Item (เหมือนเดิม)
            CollectBattery();
        }
    }

    // ฟังก์ชัน CollectBattery(): จัดการการเก็บ Item (เหมือนเดิม)
    private void CollectBattery()
    {
        Debug.Log("Battery Collected!"); // แสดงข้อความใน Console [cite: 55]
        Destroy(gameObject); // ทำลาย GameObject (Item แบตเตอรี่) [cite: 294]
    }

    // Implement ฟังก์ชัน Interact() จาก Interface IInteractable
    // ฟังก์ชันนี้จะถูกเรียกเมื่อผู้เล่น "กดปุ่ม" เพื่อ Interact
    public void Interact()
    {
        CollectBattery(); // เรียกฟังก์ชันเก็บ Item เหมือนเดิม
    }

    // Implement ฟังก์ชัน GetInteractionText() จาก Interface IInteractable
    // ฟังก์ชันนี้จะส่งคืนข้อความที่จะแสดงบน UI เมื่อผู้เล่นมอง Item
    public string GetInteractionText()
    {
        return interactionText; // ส่งคืนข้อความที่กำหนดไว้ใน Inspector
    }
}