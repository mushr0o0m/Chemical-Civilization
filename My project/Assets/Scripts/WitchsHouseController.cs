using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchsHouseController : MonoBehaviour
{
    [SerializeField] private GameObject Blur;
    [SerializeField] private GameObject WitchHouseOutside;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>() != null)
        {
            Blur.SetActive(true);
            WitchHouseOutside.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<CharacterController>() != null)
        {
            Blur.SetActive(false);
            WitchHouseOutside.SetActive(true);
        }
    }
}
