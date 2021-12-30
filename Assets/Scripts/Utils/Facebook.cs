using UnityEngine;

namespace Assets.Scripts.Utils
{
    class Facebook
    {
        public static void GetInfo(int sitemid)
        {
            if (sitemid == 0)
            {
                return;
            }
            Debug.Log("sitemid: " + sitemid);
            FC.Hello();
        }

        public void Hello()
        {
            Debug.Log("Facebook Hello() call");
        }
    }
}
