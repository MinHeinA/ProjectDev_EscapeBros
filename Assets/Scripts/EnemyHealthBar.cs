using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    // PhotonView view;

    private void Start()
    {
        // view = GetComponent<PhotonView>();
    }

    /*
    public void SetHealth(int health, int maxHealth)
    {
        view.RPC("SetHealthRPC", RpcTarget.All, health, maxHealth);
    }
    */

    // [PunRPC]
    public void SetHealth(int health, int maxHealth)
    {
        slider.gameObject.SetActive(health != 0);
        slider.value = health * 1.0f;
        slider.maxValue = maxHealth * 1.0f;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
