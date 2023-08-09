using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage_Popup : MonoBehaviour
{
    private TextMeshPro damageText;
    private float disappearTime;
    private Color textColor;

    private void Awake()
    {
        damageText = transform.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            float disappearingSpeed = 2f;
            textColor.a -= disappearingSpeed * Time.deltaTime;
            damageText.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public static Damage_Popup Spawn(Vector3 position, float damageAmount)
    {
        Transform damagePopupTransform = Instantiate(Game_Manager.instance.damagePopUp_Transform, position, Quaternion.identity);

        Damage_Popup damagePopup = damagePopupTransform.GetComponent<Damage_Popup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    private void Setup(float damage)
    {
        damageText.SetText(damage.ToString());
        textColor = damageText.color;
        disappearTime = 1f;
    }
}
