using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;//½Àµæ °¡´É °Å¸®

    private bool isPickUpActivated = false;

    private RaycastHit hitInfo;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Text actionText;

    [SerializeField]
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
    }

    void TryAction()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }

    void CanPickUp()
    {
        if(isPickUpActivated)
        {
            if(hitInfo.transform !=null)
            {
                Debug.Log("È¹µæ");
                inventory.GetItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }

    void CheckItem()
    {
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hitInfo,range,layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
        {
            InfoDisappear();
        }
    }

    void ItemInfoAppear()
    {
        isPickUpActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " È¹µæ " + "(E)";
    }

    void InfoDisappear()
    {
        isPickUpActivated = false;
        actionText.gameObject.SetActive(false);
    }
}
