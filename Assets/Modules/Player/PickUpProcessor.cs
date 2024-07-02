using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpProcessor : MonoBehaviour
{
    public LayerMask pickableMask;
    private GameObject user;
    private Stats userStats;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == Mathf.Log(pickableMask.value, 2))
        {
            if (other.CompareTag("XP"))
            {
                userStats.GainXP(other.GetComponent<XPGem>().GetXP());
                Destroy(other.gameObject);
                return;
            }
            else if (other.CompareTag("Item"))
            {
                // Code for taking item
                return;
            }
        }
    }

    private void Awake()
    {
        user = transform.parent.gameObject;
        userStats = user.GetComponent<Stats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
