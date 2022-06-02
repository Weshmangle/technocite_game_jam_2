using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected UnityEngine.UI.Image panel;
    [SerializeField] protected TMPro.TextMeshProUGUI textPlayerA;
    [SerializeField] protected TMPro.TextMeshProUGUI textPlayerB;
    protected TMPro.TextMeshProUGUI currentText;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textPlayerA.gameObject.SetActive(false);
        textPlayerB.gameObject.SetActive(false);
    }

    void Update()
    {
        if(currentText)
        {
            float dilate = currentText.fontMaterial.GetFloat(TMPro.ShaderUtilities.ID_FaceDilate);

            if(dilate < 0)
            {
                currentText.fontMaterial.SetFloat(TMPro.ShaderUtilities.ID_FaceDilate, dilate + Time.deltaTime);
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + Time.deltaTime * .85f);
            }
        }
        else
        {
            panel.gameObject.SetActive(false);
        }
    }

    protected void ShowWinnerPlayer(TMPro.TextMeshProUGUI text)
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
        text.fontMaterial.SetFloat(TMPro.ShaderUtilities.ID_FaceDilate, -1);
        text.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        currentText = text;
    }

    public void ShowWinnerPlayerA()
    {
        ShowWinnerPlayer(textPlayerA);
    }

    public void ShowWinnerPlayerB()
    {
        ShowWinnerPlayer(textPlayerB);
    }
}
