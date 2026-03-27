using UnityEngine;
using UnityEngine.UI;

public class OrganToggleSimple : MonoBehaviour
{
    public Toggle toggle;
    public GameObject organ;

    void Start()
    {
        // Ξεκινάει χωρίς tick
        toggle.isOn = false;

        // Το όργανο ξεκινάει κρυφό
        organ.SetActive(false);

        // Συνδέουμε τη λειτουργία
        toggle.onValueChanged.AddListener(delegate {
            organ.SetActive(toggle.isOn);
        });
    }
}
