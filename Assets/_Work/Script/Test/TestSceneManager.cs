using UnityEngine;

namespace __Misc.Test
{
    public class TestSceneManager : MonoBehaviour
    {
        public void OnClickLogin()
        {
            AuthManager.instance.ProcessLogin();
        }
    }
}