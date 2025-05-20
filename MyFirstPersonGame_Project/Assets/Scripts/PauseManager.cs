using UnityEngine;
using UnityEngine.InputSystem; // สำหรับรับ Input ใหม่
using UnityEngine.SceneManagement; // สำหรับเปลี่ยน Scene

public class PauseManager : MonoBehaviour
{
    // อ้างอิงถึง Panel หยุดเกม (กำหนดใน Inspector)
    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false; // สถานะหยุดเกม

    private void Start()
    {
        // ซ่อน PausePanel เมื่อเริ่มเกม
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        // ตรวจสอบให้แน่ใจว่าเวลาในเกมเดินปกติเมื่อเริ่ม
        Time.timeScale = 1f;
    }

    // ฟังก์ชันสำหรับรับ Input จากปุ่ม Pause (จะผูกกับ Action "Pause" ใน Input System)
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started) // เมื่อปุ่มถูกกดลงไป
        {
            if (isPaused)
            {
                ResumeGame(); // ถ้าหยุดอยู่ ให้เล่นต่อ
            }
            else
            {
                PauseGame(); // ถ้าเล่นอยู่ ให้หยุด
            }
        }
    }

    // ฟังก์ชันหยุดเกม
    public void PauseGame()
    {
        isPaused = true;
        if (pausePanel != null)
        {
            pausePanel.SetActive(true); // แสดง PausePanel
        }
        Time.timeScale = 0f; // หยุดเวลาในเกม (ทำให้ทุกอย่างหยุดนิ่ง)
        // แสดงเมาส์และปลดล็อก (เพื่อให้ผู้เล่นกดปุ่มใน UI)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // ฟังก์ชันเล่นเกมต่อ
    public void ResumeGame()
    {
        isPaused = false;
        if (pausePanel != null)
        {
            pausePanel.SetActive(false); // ซ่อน PausePanel
        }
        Time.timeScale = 1f; // ให้เวลาในเกมเดินปกติ
        // ซ่อนเมาส์และล็อกไว้กลางจอเมื่อกลับมาเล่น
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // ฟังก์ชันสำหรับปุ่ม Restart (ผูกใน On Click ของปุ่ม)
    public void RestartGame()
    {
        ResumeGame(); // ตรวจสอบให้แน่ใจว่าเวลาเดินปกติก่อนเปลี่ยน Scene
        // โหลด Scene Gameplay ปัจจุบันซ้ำ เพื่อเริ่มเกมใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ฟังก์ชันสำหรับปุ่ม Main Menu (ผูกใน On Click ของปุ่ม)
    public void GoToMainMenu()
    {
        ResumeGame(); // ตรวจสอบให้แน่ใจว่าเวลาเดินปกติก่อนเปลี่ยน Scene
        SceneManager.LoadScene("MainMenu"); // โหลด Scene MainMenu
    }
}