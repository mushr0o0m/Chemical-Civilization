using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [SerializeField] private Text QuestWindowText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WitchsHouseController>() != null)
        {
            QuestWindowText.text = "������ ������ ����";
        }
    }

    public void FininshReactionQuest()
    {
        QuestWindowText.text = "�������� �������������� �����";
    }

    public void FininshCoalQuest()
    {
        QuestWindowText.text = "������!";
    }
}
