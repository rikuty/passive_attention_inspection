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

        }

        #region Event Methods Called from the UI

        [SerializeField] RawImage[] startXs;
        [SerializeField] RawImage[] startYs;
        [SerializeField] RawImage[] endXs;
        [SerializeField] RawImage[] endYs;
        [SerializeField] RawImage[] trialCounts;

        Vector2 startVector = new Vector2(20f, -20f);
        Vector2 endVector = new Vector2(-20f, 20f);
        int trialCount = 32;

        private ESceneNames name = ESceneNames.scene_inspection;

        public void PlayClick()
        {
            this.gameData.Init(this.id, this.dateTime, startVector, endVector, trialCount);
            GSAppExampleControl.Instance.LoadScene(this.name);
        }


        public void SelectedStartX(int x)
        {
            foreach(RawImage img in startXs)
            {
                img.color = Color.clear;
            }
            startVector = new Vector2((float)x, startVector.y);
        }

        public void SelectedStartY(int y)
        {
            foreach (RawImage img in startYs)
            {
                img.color = Color.clear;
            }
            startVector = new Vector2(startVector.x, (float)y);
        }

        public void SelectedEndX(int x)
        {
            foreach (RawImage img in endXs)
            {
                img.color = Color.clear;
            }
            endVector = new Vector2((float)x, startVector.y);
        }

        public void SelectedEndY(int y)
        {
            foreach (RawImage img in endYs)
            {
                img.color = Color.clear;
            }
            endVector = new Vector2(startVector.x, (float)y);
        }

        public void SelectedTrialCount(int count)
        {
            foreach (RawImage img in trialCounts)
            {
                img.color = Color.clear;
            }
            trialCount = count;
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