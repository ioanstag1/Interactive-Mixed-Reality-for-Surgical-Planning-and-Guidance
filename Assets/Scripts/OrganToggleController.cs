
using UnityEngine;

public class OrganToggleController : MonoBehaviour
{
    public GameObject organObject;

    public void ToggleOrgan(bool isVisible)
    {
        if (organObject != null)
            organObject.SetActive(isVisible);
    }
}