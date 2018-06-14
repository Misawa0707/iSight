using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : MonoBehaviour {

	public Animator initiallyOpen;

	public int m_OpenParameterId;
    public Animator m_Open;
    public GameObject m_PreviouslySelected;

    const string k_OpenTransitionName = "Open";
    const string k_ClosedStateName = "Closed";
    public void ReStart()
    {
        OnEnable();
    }
	public void OnEnable()
	{
	    m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);

		if (initiallyOpen == null)
			return;

		OpenPanel(initiallyOpen);
	}

	public void OpenPanel (Animator anim)
	{
		if (m_Open == anim)
			return;

		anim.gameObject.SetActive(true);
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

		anim.transform.SetAsLastSibling();

		CloseCurrent();

		m_PreviouslySelected = newPreviouslySelected;

		m_Open = anim;
		m_Open.SetBool(m_OpenParameterId, true);

		GameObject go = FindFirstEnabledSelectable(anim.gameObject);

	}

	static GameObject FindFirstEnabledSelectable (GameObject gameObject)
	{
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}

    public void CloseCurrent()
    {
        if (m_Open == null)
            return;

        m_Open.SetBool(m_OpenParameterId, false);

        StartCoroutine(DisablePanelDeleyed(m_Open));
        m_Open = null;
    }

    IEnumerator DisablePanelDeleyed(Animator anim)
	{
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose)
		{
			if (!anim.IsInTransition(0))
				//closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);

			//wantToClose = !anim.GetBool(m_OpenParameterId);

			yield return new WaitForEndOfFrame();
		}

		if (wantToClose)
			anim.gameObject.SetActive(false);
	}


}
