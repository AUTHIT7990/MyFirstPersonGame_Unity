using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    // ฟังก์ชัน OnTriggerEnter จะถูกเรียกเมื่อ Collider อื่นๆ เข้ามาชนกับ Trigger Collider ของ GameObject นี้
    // collider: คือ Collider ของ GameObject ที่เข้ามาชน
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่า GameObject ที่เข้ามาชนมี Tag เป็น "Player" หรือไม่
        // เราจะให้ตัวละคร Player ของเรามี Tag "Player" ในขั้นตอนต่อไป
        if (other.CompareTag("Player"))
        {
            // ถ้าชนกับ Player ให้เรียกฟังก์ชันเก็บ Item
            CollectBattery();
        }
    }

    // ฟังก์ชันสำหรับจัดการการเก็บ Item
    private void CollectBattery()
    {
        Debug.Log("Battery Collected!"); // แสดงข้อความใน Console ว่าเก็บแบตแล้ว

        // Destroy(gameObject): สั่งให้ทำลาย GameObject ที่ Script นี้ติดอยู่
        // ในที่นี้คือทำลาย Cube (แบตเตอรี่) ทำให้มันหายไปจาก Scene
        Destroy(gameObject);
    }
}