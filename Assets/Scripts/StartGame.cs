using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        // đợi trì hoãn bao nhiêu giây
        yield return new WaitForSeconds(delay);

        // nạp scene tiếp theo (tăng 1 index)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
