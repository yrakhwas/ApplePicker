using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject> ();
        for (int i = 0; i < numBasket; i++)
        {
            GameObject tBasketGo = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY +(basketSpacingY *i);
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }
    public void AppleDestroyed()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject go in list)
        {
            Destroy(go);
        }
        int basketIndex = basketList.Count - 1;
        GameObject gameObject = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(gameObject);
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void Update()
    {
        if (Input.GetKey("escape")) 
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
