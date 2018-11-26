using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


namespace Gamestrap
{
    public class MainMenuControl : MonoBehaviour
    {
        private static int visibleVariable = Animator.StringToHash("Visible");
        private static int notifyVariable = Animator.StringToHash("Notify");

        public GameObject settingsPanel, aboutPanel;

        public Toggle soundToggle, musicToggle;

        public string id;
        public DateTime dateTime;
        public Text displayID;

        public GazeButtonInput gazeButtonInput;

        private GameData gameData;

        public Text notificationText;
        private Animator notificationAnimator;
        public void Start()
        {
            //Adds events to the Toggle buttons through code since
            //doing it through the inspector wouldn't will give the value of the button dynamically
            soundToggle.onValueChanged.AddListener(ToggleSound);
            musicToggle.onValueChanged.AddListener(ToggleMusic);

            this.gameData = GameData.Instance;

            notificationAnimator = notificationText.GetComponent<Animator>();

            this.dateTime = DateTime.Now;
            //ID = System.DateTime.Now.ToString("yyMMddHHmm");
            this.id = this.dateTime.ToString("yyMMddHHmm");
            this.displayID.text = this.id;

            //this.gazeButtonInput.Init(this.context);


            this.PlaySceneInspection();
        }

        #region Event Methods Called from the UI

        public RawImage imgInspection;
        public RawImage imgTraining10;
        public RawImage imgTraining20;
        public RawImage imgTraining10minus;
        public RawImage imgTraining20minus;
        public RawImage imgTrainingR10;
        public RawImage imgTrainingR20;
        public RawImage imgTrainingR10minus;
        public RawImage imgTrainingR20minus;

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
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, 0f, 0f);
        }

        public void PlaySceneTraining10()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 255f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, -10f, 10f);
        }

        public void PlaySceneTraining20()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 255f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, -20f, 20f);
        }
        public void PlaySceneTraining10minus()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 255f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, 10f, -10f);
        }
        public void PlaySceneTraining20minus()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 255f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, 20f, -20f);
        }
        public void PlaySceneTrainingR10()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 255f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, -10f, -10f);
        }
        public void PlaySceneTrainingR20()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 255f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, -20f, -20f);
        }
        public void PlaySceneTraininR10minus()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 255f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 0f);
            this.gameData.Init(this.id, this.dateTime, 10f, 10f);
        }
        public void PlaySceneTrainingR20minus()
        {
            this.name = ESceneNames.scene_training;
            this.imgInspection.color = new Color(this.imgInspection.color.r, this.imgInspection.color.g, this.imgInspection.color.b, 0f);
            this.imgTraining10.color = new Color(this.imgTraining10.color.r, this.imgTraining10.color.g, this.imgTraining10.color.b, 0f);
            this.imgTraining20.color = new Color(this.imgTraining20.color.r, this.imgTraining20.color.g, this.imgTraining20.color.b, 0f);
            this.imgTraining10minus.color = new Color(this.imgTraining10minus.color.r, this.imgTraining10minus.color.g, this.imgTraining10minus.color.b, 0f);
            this.imgTraining20minus.color = new Color(this.imgTraining20minus.color.r, this.imgTraining20minus.color.g, this.imgTraining20minus.color.b, 0f);
            this.imgTrainingR10.color = new Color(this.imgTrainingR10.color.r, this.imgTrainingR10.color.g, this.imgTrainingR10.color.b, 0f);
            this.imgTrainingR20.color = new Color(this.imgTrainingR20.color.r, this.imgTrainingR20.color.g, this.imgTrainingR20.color.b, 0f);
            this.imgTrainingR10minus.color = new Color(this.imgTrainingR10minus.color.r, this.imgTrainingR10minus.color.g, this.imgTrainingR10minus.color.b, 0f);
            this.imgTrainingR20minus.color = new Color(this.imgTrainingR20minus.color.r, this.imgTrainingR20minus.color.g, this.imgTrainingR20minus.color.b, 255f);
            this.gameData.Init(this.id, this.dateTime, 20f, 20f);
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