using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ITransitionMessageTarget : IEventSystemHandler {

	void ToggleShaderMessage(bool to3D);
}
