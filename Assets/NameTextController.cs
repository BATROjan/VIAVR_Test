using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NameTextController
    {
        public void ChangeText(Text currentText, string nextName)
        {
            currentText.text = nextName;
        }
    }
}