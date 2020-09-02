using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PuppetJump.Objs
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private Timer t;
        public OutfitManager om;
        public ItemManager im;
        public PotionManager pm;
        public LevelManager lm;
        public NPCManager npcm;
        public Map map;

        public int totalGameGold, levelGold, levelGoldGoal, totalGameStars, levelStars, levelDif, level;
        public int firstStarGoal, secondStarGoal, thirdStarGoal;
        public int breathingTime = 5;
        public Text NPCText, goldText, starText;

        public bool inLevel, inMap, levelEnded, goldAdded, starsAdded, isMapActive = true, isTutorial, isPaused;
        public List<bool> itemUnlocks = new List<bool>();

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            lm = FindObjectOfType<LevelManager>();
            t = FindObjectOfType<Timer>();
            map = FindObjectOfType<Map>();
            pm = FindObjectOfType<PotionManager>();
            inLevel = false;
            isMapActive = true;
        }

        void Update()
        {
            if (inLevel)
            {
                StarCount();
                if (npcm.GetWaitingNPC() == null)
                {
                    NPCText.text = "The Knight Wants:";
                }
                else if (npcm.GetWaitingNPC() != null)
                {
                    NPCText.text = "The Knight Wants:" + "\n" + npcm.GetWaitingNPC().GetNPCPotion();
                }
            }

            if (t.timeInRound <= 0)
            {
                StartCoroutine(EndOfLevel());
            }

            if (isMapActive)
            {
                map.gameObject.SetActive(true);
            }
            else if (!isMapActive)
            {
                map.gameObject.SetActive(false);
            }
            Debug.Log(levelGold);
            /*
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SetGoldGoal(1000);
                SceneManager.LoadScene(1);
                Debug.Log(levelGoldGoal);
            }
            */
        }

        public void ResetLevelGoldandStars()
        {
            levelGold = 0;
        }

        void StarCount()
        {
            if (levelGold > firstStarGoal && lm.levels[level].firstStarGot == false)
            {
                //display first star achieved!
                //Set up an animation to play here
                levelStars++;
                lm.levels[level].firstStarGot = true;
            }
            else if (levelGold > secondStarGoal && lm.levels[level].secondStarGot == false)
            {
                //display second star achieved!
                //Set up an animation to play here
                levelStars++;
                lm.levels[level].secondStarGot = true;
            }
            else if (levelGold > thirdStarGoal && lm.levels[level].thirdStarGot == false)
            {
                //display third star achieved!
                //Set up an animation to play here
                levelStars++;
                lm.levels[level].thirdStarGot = true;
            }
        }

        public void AddGold(int i)
        {
            levelGold += i;
        }

        /* public void SetGoldGoal(int i)
         {
             levelGoldGoal = i;
         }
         */
        public void SetStarGoals(int a, int b, int c)
        {
            firstStarGoal = a;
            secondStarGoal = b;
            thirdStarGoal = c;
        }

        public int GetLevelDifficulty()
        {
            return levelDif;
        }

        public void SetLevelDifficulty(int i)
        {
            levelDif = i;
        }

        public void StartLevel(int i, int s)
        {
            StartCoroutine(LevelStart(i, s));
        }

        public void OnLoadData()
        {
            if (ES3.KeyExists("TotalGold"))
            {
                totalGameGold = ES3.Load<int>("TotalGold");
            }
            if (ES3.KeyExists("TotalStars"))
            {
                totalGameStars = ES3.Load<int>("TotalStars");
            }

            for (int i = 0; i < lm.levels.Count; i++)
            {
                if (ES3.KeyExists("Level " + i + " StarsAcquired"))
                {
                    lm.levels[i].starsAcquired = ES3.Load<int>("Level " + i + " StarsAcquired");
                }
                if (ES3.KeyExists("Level " + i + " HighScore"))
                {
                    lm.levels[i].goldHighScore = ES3.Load<int>("Level " + i + " HighScore");
                }
                lm.levels[i].firstStarGot = ES3.Load<bool>("Level " + i + " FirstStarGot");
                lm.levels[i].secondStarGot = ES3.Load<bool>("Level " + i + " SecondStarGot");
                lm.levels[i].thirdStarGot = ES3.Load<bool>("Level " + i + " ThirdStarGot");
            }
            for (int i = 0; i < itemUnlocks.Count; i++)
            {
                if (ES3.KeyExists("Item " + i + "Unlocked"))
                {
                    itemUnlocks[i] = ES3.Load<bool>("Item " + i + "Unlocked");
                    if (i > om.outfits.Count)
                    {
                        im.ActivateItem(i - om.outfits.Count - 1);
                    }
                }
            }
            map.mapType = 1;
        }

        public void StartTutorial()
        {
            //starts game on Tutorial level
            Debug.Log("Start Tutorial Level!");
            isTutorial = true;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void OpenSettings()
        {
            //opens settings menu
            map.mapType = 2;
        }

        public void OpenStore()
        {
            map.mapType = 3;
        }

        public void OpenMap()
        {
            map.mapType = 1;
        }

        public void OpenTitle()
        {
            map.mapType = 0;
        }

        public void Buy(int i)
        {
            if (totalGameGold > i)
            {
                totalGameGold -= i;
                SaveGame();
            }
        }

        public void EnableItem(int i)
        {
            itemUnlocks[i] = true;
            if (i <= om.outfits.Count)
            {
                om.currentOutfit = om.outfits[i];
                ES3.Save("Current Outfit", om.currentOutfit);
            }
            else if (i > om.outfits.Count)
            {
                im.ActivateItem(i - om.outfits.Count - 1);
            }
        }

        public void PauseGame()
        {
            if (!isPaused)
            {
                map.gameObject.SetActive(true);
                map.mapType = 5;
                t.startTime = false;
                isPaused = true;
                npcm.StopNPCs();
            }
        }

        public void UnpauseGame()
        {
            if (isPaused)
            {
                map.gameObject.SetActive(false);
                map.mapType = 5;
                t.startTime = true;
                isPaused = false;
                npcm.StartNPCs();
            }
        }

        public void SaveGame()
        {
            ES3.Save("TotalGold", totalGameGold);
            ES3.Save("TotalStars", totalGameStars);
            for (int i = 0; i < lm.levels.Count; i++)
            {
                if (lm.levels[i].starsAcquired > 0)
                {
                    ES3.Save("Level " + i + " StarsAcquired", lm.levels[i].starsAcquired);
                }
                if (lm.levels[i].goldHighScore > 0)
                {
                    ES3.Save("Level " + i + " HighScore", lm.levels[i].goldHighScore);
                }
                ES3.Save("Level " + i + " FirstStarGot", lm.levels[level].firstStarGot);
                ES3.Save("Level " + i + " SecondStarGot", lm.levels[level].secondStarGot);
                ES3.Save("Level " + i + " ThirdStarGot", lm.levels[level].thirdStarGot);
            }
            for (int i = 0; i < itemUnlocks.Count; i++)
            {
                if (itemUnlocks[i] == true)
                {
                    ES3.Save("Item " + i + "Unlocked", itemUnlocks[i]);
                }
            }
        }

        IEnumerator LevelStart(int i, int s)
        {
            StopCoroutine("EndofLevel");
            isMapActive = false;
            pm.RevertPotion();
            pm.ClearHeat();
            inLevel = true;
            t.timeInRound = s;
            t.startTime = true;
            goldAdded = false;
            starsAdded = false;
            yield return new WaitForSecondsRealtime(i);
        }

        IEnumerator EndOfLevel()
        {
            StopCoroutine("LevelStart");
            isMapActive = true;
            OpenMap();
            map.mapType = 4;
            goldText.text = "Gold Gained:" + "\n" + goldAdded;
            starText.text = "Stars Gained:" + "\n" + starsAdded;
            Debug.Log("Running the End of Level checks!");
            inLevel = false;
            if (goldAdded == false)
            {
                totalGameGold += levelGold;
                goldAdded = true;
            }
            if (starsAdded == false)
            {
                totalGameStars += levelStars;
                lm.levels[level].starsAcquired += levelStars;
                starsAdded = true;
            }
            if (lm.levels[level].goldHighScore < levelGold)
            {
                lm.levels[level].goldHighScore = levelGold;
            }
            ResetLevelGoldandStars();
            SaveGame();
            levelEnded = true;
            yield return null;
        }
    }
}
