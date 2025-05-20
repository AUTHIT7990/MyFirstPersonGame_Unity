// public: ทำให้ Interface นี้เข้าถึงได้จากภายนอก
// interface IInteractable: ประกาศ Interface ชื่อ IInteractable
public interface IInteractable
{
    // void Interact();: ฟังก์ชันที่คลาสใดๆ ที่นำ Interface นี้ไปใช้ จะต้องเขียนขึ้นมา
    // public string GetInteractionText();: ฟังก์ชันที่คลาสใดๆ ที่นำ Interface นี้ไปใช้ จะต้องเขียนขึ้นมา เพื่อส่งคืนข้อความสำหรับ UI
    void Interact();
    string GetInteractionText();
}