using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // บรรทัดนี้สำคัญ: ทำให้เราสามารถใช้คำสั่งเกี่ยวกับการจัดการ Scene ได้ [cite: 432]

// Public class: หมายความว่าคลาสนี้สามารถเข้าถึงได้จากภายนอก [cite: 428]
// MainMenuManager : MonoBehaviour: คลาสนี้สืบทอดมาจาก MonoBehaviour, ทำให้สามารถแนบกับ GameObject และใช้ฟังก์ชันพิเศษของ Unity ได้ [cite: 284, 430]
public class MainMenuManager : MonoBehaviour
{
    // ฟังก์ชัน Start() จะถูกเรียกหนึ่งครั้งเมื่อ Script เริ่มทำงาน (ในเฟรมแรกที่เปิดใช้งาน) [cite: 286, 289]
    void Start()
    {
        // Cursor.visible = true;: ทำให้ตัวชี้เมาส์ (cursor) มองเห็นได้บนหน้าจอ [cite: 467]
        Cursor.visible = true;
        // CursorLockMode.None: ปรับการเคลื่อนที่ของเมาส์ให้ขยับได้อย่างอิสระ ไม่ถูกล็อกไว้กลางจอ [cite: 467, 468]
        Cursor.lockState = CursorLockMode.None;
    }

    // ฟังก์ชัน Update() จะถูกเรียกทุกๆ เฟรมของเกม [cite: 289]
    void Update()
    {
        // ใน Scene เมนูหลักที่ค่อนข้างง่าย เราอาจจะยังไม่จำเป็นต้องมีโค้ดที่ทำงานทุกเฟรมในฟังก์ชัน Update() ครับ [cite: 289]
    }

    // public void StartGame():
    // public: ทำให้ฟังก์ชันนี้สามารถถูกเรียกใช้จากภายนอกคลาสได้ (จำเป็นสำหรับปุ่ม UI) [cite: 428]
    // void: หมายความว่าฟังก์ชันนี้จะไม่มีการส่งค่าอะไรกลับไป [cite: 412]
    // StartGame(): คือชื่อของฟังก์ชันนี้ [cite: 412]
    public void StartGame()
    {
        // SceneManager.LoadScene("Gameplay"):
        // SceneManager: เป็นคลาสของ Unity ที่ใช้ในการจัดการ Scene [cite: 432]
        // LoadScene("Gameplay"): เป็นเมธอดที่ใช้สำหรับโหลด Scene ใหม่ โดยรับชื่อ Scene ที่ต้องการโหลดเป็นสตริง [cite: 432]
        // เมื่อฟังก์ชันนี้ถูกเรียก Scene ปัจจุบัน (MainMenu) จะถูกเปลี่ยนเป็น Scene "Gameplay" ครับ
        SceneManager.LoadScene("Gameplay");
    }
}