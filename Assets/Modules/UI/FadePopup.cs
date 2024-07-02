using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadePopup : MonoBehaviour
{
    private TextMeshPro popUpText;
    public float floatSpeed = 1;
    public float textAlpha = 1;

    private void Awake()
    {
        popUpText = GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textAlpha -= Time.deltaTime;
        transform.position += (Vector3.up * Time.deltaTime * floatSpeed);
        popUpText.color = new Color(popUpText.color.r, popUpText.color.g, popUpText.color.b, textAlpha);
        if (textAlpha <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeText(float damageNumber) 
    {
        popUpText.text = ((int)damageNumber).ToString();
    }

}
