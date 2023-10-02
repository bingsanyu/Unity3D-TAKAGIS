using UnityEngine;
using System.Collections;

public class menuSub : MonoBehaviour
{
    void OnMouseUp()
	{
		transform.parent.gameObject.SetActive(false);
	}

}
