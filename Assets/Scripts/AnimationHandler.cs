using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    #region Custom Methods
    public void Complete()
    {
        Destroy(gameObject);
    }
    #endregion
}
