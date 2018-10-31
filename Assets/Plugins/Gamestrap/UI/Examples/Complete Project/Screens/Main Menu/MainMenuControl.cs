using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Gamestrap
{
    public class MainMenuControl : MonoBehaviour
    {
        private static int visibleVariable = Animator.StringToHash("Visible");
        private static int notifyVariable = Animator.StringToHash("Notify");

        public GameObject settingsPanel, aboutPanel;

        public Toggle soundToggle, musicToggle;

        public static string ID;

        public Text displayID;


        public Text notificationText;
        private Animator notificationAnimator;
        public void Start()
        {
            //Adds events to the Toggle buttons through code since
            //doing it through the inspector wouldn't will give the value of the button dynamically
            soundToggle.onValueChanged.AddListener(ToggleSound);
            musicToggle.onValueChanged.AddListener(ToggleMusic);

            notificationAnimator = notificationText.GetComponent<Animator>();

            ID = System.DateTime.Now.ToString("yyMMddHHmm");
            this.displayID.text = ID;

            this.PlaySceneInspection();
        }

        #region Event Methods Called from the UI

        public RawImage imgInspection;
        public RawImage imgTraining10;
        public RawImage imgTraining20;
        public RawImage imgTraining10minus;
        public RawImage imgTraining20minus;

        private ESceneNames name = ESceneNames.scene_inspection;

        public void PlayClick()
        {
            GSAppExampleControl.Instance.LoadScene(this.name);
        }


        public void PlaySceneInspection()
        {
            this.name = ESceneNames.scene_inspection;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 255f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
        }

        public void PlaySceneTraining10()
        {
            this.name = ESceneNames.scene_training10;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 255f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
        }

        public void PlaySceneTraining20()
        {
            this.name = ESceneNames.scene_training20;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 255f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
        }
        public void PlaySceneTraining10minus()
        {
            this.name = ESceneNames.scene_training10minus;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 255f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
        }
        public void PlaySceneTraining20minus()
        {
            this.name = ESceneNames.scene_training20minus;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 255f);
        }

        public void AchievementsClick()
        {
            notificationText.text = "Achievements Clicked...";
            notificationAnimator.SetTrigger(notifyVariable);
        }

        public void LeaderboardClick()
        {
            notificationText.text = "Leaderboard Clicked...";
            notificationAnimator.SetTrigger(notifyVariable);
        }

        public void RateClick()
        {
            notificationText.text = "Rate Clicked...";
            notificationAnimator.SetTrigger(notifyVariable);
        }

        #region Settings Events
        public void ToggleSettingsPanel()
        {
            TogglePanel(settingsPanel.GetComponent<Animator>());
        }

        public void ToggleSound(bool on)
        {
            // Change the sound
        }

        public void ToggleMusic(bool on)
        {
            // Change the music
        }

        #endregion

        #region About Events

        public void FacebookClick()
        {
            Application.OpenURL("https://www.facebook.com/gamestrapui/");
        }

        public void TwitterClick()
        {
            Application.OpenURL("https://twitter.com/EmeralDigEnt");

        }

        public void YoutubeClick()
        {
            Application.OpenURL("https://www.youtube.com/channel/UC8b_9eMveC6W0hl5RJkCvyQ");
        }

        public void WebsiteClick()
        {
            Application.OpenURL("http://www.gamestrap.info");
        }
        #endregion

        public void ToggleAboutPanel()
        {
            TogglePanel(aboutPanel.GetComponent<Animator>());
        }

        private void TogglePanel(Animator panelAnimator)
        {
            panelAnimator.SetBool(visibleVariable, !panelAnimator.GetBool(visibleVariable));
        }
        #endregion
    }
}