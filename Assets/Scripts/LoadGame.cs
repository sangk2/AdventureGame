using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public float delayLoad = 2;

    // Load màn hình 

    public void Load(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    
    public void ReLoadScenePresent()
    {
        if (gameController.instance.isGameOver)
        {
            gameController.instance.isGameOver = false;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Qua scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            gameController.instance.NextLevel();
            //ModeSelect();
        }
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ModeSelect()
    {
        // cho phép dừng
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        // đợi trì hoãn bao nhiêu giây
        yield return new WaitForSeconds(delayLoad);

        // nạp scene tiếp theo (tăng 1 index)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
