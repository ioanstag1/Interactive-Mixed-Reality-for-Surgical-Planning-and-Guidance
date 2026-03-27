using UnityEngine;
using TMPro;

public class OrganSelector : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public GameObject[] organs;

    void Start()
    {
        dropdown.onValueChanged.AddListener(ShowOnlySelectedOrgan);
    }

    void ShowOnlySelectedOrgan(int index)
    {
        for (int i = 0; i < organs.Length; i++)
        {
            if (organs[i] != null)
                organs[i].SetActive(i == index);
        }
    }
}