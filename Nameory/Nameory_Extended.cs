using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nameory
{
    public partial class Nameory
    {
        // "objects" innehåller alla personer.
        List<NameoryObject> objects = new List<NameoryObject>();

        // Skapa en lista för rätt svar och en för fel svar.
        List<NameoryObject> correctObjects = new List<NameoryObject>();
        List<NameoryObject> incorrectObjects = new List<NameoryObject>();

        // Den här anger -1 om vi ska börja från början på listan. Annars motsvarar "index" index för aktuell personen i objects.
        int index = -1;

        // Anger typ av spel (just nu tre sätt)
        GamePlay typeOfGame;

        // Här lagras Academy-loggan i InitiateGame()
        Bitmap logoType;

        // Enumeration för typ av spel
        enum GamePlay
        {
            OneRound,
            LearnAllNames,
            Continuous
        }

        // Initierar spelet och sätter kör nästa (första) steg i spelet.
        private void RunGame(bool expert, int group, GamePlay typeOfGame)
        {
            InitiateGame(expert, group, typeOfGame);
            PlayGame();
        }

        // Initierar spelet
        private void InitiateGame(bool expert, int group, GamePlay typeOfGame)
        {
            // Sparar bilden som finns i pictureBox1 från början
            logoType = new Bitmap(pictureBox1.Image);

            // Sätt global variabel typeOfGame till det som skickades från NewGame-formen
            this.typeOfGame = typeOfGame;

            // Om spelsättet är Continuous döljer vi progressbaren
            if (typeOfGame == GamePlay.Continuous)
            {
                progressBar1.Visible = false;
            }

            /* Det här är tänkt att komma i framtiden. Just nu är Java- och C#-klassen hårdkodade.
            // Prata med NameoryIO och fyll listan objects.

            if (!expert)
            {
                // Om bara en lista, skapa den.
            }
            else
            {
                // Loopa igenom hela listan och skapa objekt.
            }
            */

            // Om "expert" är valt kommer alla listorna plockas fram (just nu med hjälp av nameoryScraper,
            // i framtiden med hjälp av nameoryIO).
            // Om bara en lista är vald plockas den ut.
            if (group == 1 || expert == true)
            {
                NameoryScraper nameoryScraper = new NameoryScraper(NameoryScraper.CheckUrl("http://academy.se/utbildningen/konsulter-java-ht16"), @"(?<url>http://academy.se/wp-content/uploads\/2016\/0[8-9]\/[A-Za-z0-9_]+.png)(?<crap>[a-z0-9_\<\=\""\>\s\/\.\-\:]+)(?<firstname>[A-Öa-öé]+) (?<lastname>[A-Öa-öé]+)(?<morecrap>[a-z0-9_\<\=\""\>\s\/\.\-\:]+)(?<bio>[^<]+)");

                for (int i = 0; i < nameoryScraper.UrlsToImages.Length; i++)
                {
                    objects.Add(new NameoryObject(nameoryScraper.FirstNames[i], nameoryScraper.LastNames[i], nameoryScraper.UrlsToImages[i], nameoryScraper.Bios[i], nameoryScraper.Genders[i]));
                }
            }

            if (group == 0 || expert == true)
            {
                NameoryScraper nameoryScraper = new NameoryScraper(NameoryScraper.CheckUrl("http://academy.se/utbildningen/konsulter-dotnet-ht16"), @"src=""(?<url>http://academy.se/wp-content/upload[^""]+)[^A-Z]+(?<firstname>[^ ]+) (?<lastname>[^<]+)[^A-Z]+(?<bio>[^\n]+)");

                for (int i = 0; i < nameoryScraper.UrlsToImages.Length; i++)
                {
                    objects.Add(new NameoryObject(nameoryScraper.FirstNames[i], nameoryScraper.LastNames[i], nameoryScraper.UrlsToImages[i], nameoryScraper.Bios[i], nameoryScraper.Genders[i]));
                }
            }

        }

        // Presenterar person
        private void PlayGame()
        {
            // Sätter bakgrundsfärgen till standardgrå, visar namnknapparna och tömmer namn-labeln
            ClearUI();

            // Om index är -1, d.v.s. vi ska presentera det första objektet, slumpa om objects.
            if (index == -1)
            {
                objects = objects.OrderBy(a => Guid.NewGuid()).ToList();
            }

            // Varje gång index finns i listan objects presenterar vi det nästa objektet i listan.
            // Annars har vi gått igenom hela listan och agerar utifrån det.
            if (index < objects.Count - 1)
            {
                index = index + 1;

                PresentObject(objects[index]);
            }
            else
            {
                switch (typeOfGame)
                {
                    // Om spelet ska gå igenom alla personer en gång så är det klart här.
                    // Vi avslutar spelet och presenterar resultatet i en MessageBox.
                    case GamePlay.OneRound:
                        EndGame();
                        MessageBox.Show($"Du klarade {correctObjects.Count} av {objects.Count}!");
                        break;

                    // Om spelet ska fortsätta så länge vi inte fått alla rätt måste vi kolla om listan inCorrectObjects är tom.
                    // Om den är det avslutar vi spelet.
                    // Annars berättar vi hur många som var fel, flyttar över dem till listan objects och tömmer listan inCorrectObjects och kör vidare spelet.
                    case GamePlay.LearnAllNames:
                        if (incorrectObjects.Count == 0)
                        {
                            EndGame();
                            MessageBox.Show("Nu kan du alla namn.");
                        }
                        else
                        {
                            MessageBox.Show($"Du behöver öva på {incorrectObjects.Count} personer."); // Skriv ut namnen på alla med String.Join/Aggregate/Stringbuilder och Environment.NewLine.
                            objects.Clear();
                            objects.AddRange(incorrectObjects);
                            incorrectObjects.Clear();
                            index = -1;
                            PlayGame();
                        }
                        break;

                    // Om spelet ska fortsätta jämt tömmer vi correct- och incorrect-listan och
                    // sätter index till -1 så att den slumpas om nästa gång PlayGame() körs.
                    case GamePlay.Continuous:
                        correctObjects.Clear();
                        incorrectObjects.Clear();
                        index = -1;
                        PlayGame();
                        break;
                    default:
                        break;
                }
            }
        }

        // När spelet är slut tömmer vi på allt trams och sätter tillbaka Academy-loggan
        private void EndGame()
        {
            SetBackGroundColor(DefaultBackColor);

            pictureBox1.Image = logoType;

            nameButton1.Visible = false;
            nameButton2.Visible = false;
            nameButton3.Visible = false;

            nameLabel.Visible = false;
        }

        // Visa en person
        private void PresentObject(NameoryObject nameoryObject)
        {
            // Visa bild på objektet
            pictureBox1.Load(nameoryObject.PicUrl);

            // START PÅ Bedrövligt sätt att hitta tre namn, varav ett är den aktuella personens.
            List<NameoryObject> tempList = new List<NameoryObject>();
            tempList.AddRange(objects);
            tempList.AddRange(correctObjects);
            tempList.AddRange(incorrectObjects);
            tempList = tempList.OrderBy(a => Guid.NewGuid()).ToList();

            List<NameoryObject> threeNames = new List<NameoryObject>();

            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i].Gender == nameoryObject.Gender && tempList[i].FirstName != nameoryObject.FirstName)
                {
                    threeNames.Add(tempList[i]);
                    break;
                }
            }

            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i].Gender == nameoryObject.Gender && tempList[i].FirstName != nameoryObject.FirstName && tempList[i].FirstName != threeNames[0].FirstName)
                {
                    threeNames.Add(tempList[i]);
                    break;
                }
            }

            threeNames.Add(nameoryObject);
            // SLUT PÅ bedrövligheten

            // Slumpa plats på namnen
            threeNames = threeNames.OrderBy(a => Guid.NewGuid()).ToList();
            
            // Skriv ut namnen
            nameButton1.Text = threeNames[0].FirstName;
            nameButton2.Text = threeNames[1].FirstName;
            nameButton3.Text = threeNames[2].FirstName;


            /* Start på tidigare försökt till mindre bedrövlighet
            
            List<NameoryObject> tempList = new List<NameoryObject>();

            tempList.AddRange(objects);
            tempList.AddRange(correctObjects);
            tempList.AddRange(incorrectObjects);

            List<string> threeNames = tempList
                .OrderBy(a => Guid.NewGuid())
                .Where(c => c.Gender == nameoryObject.Gender && c.FirstName != nameoryObject.FirstName)
                //.Where(a => a.FirstName != nameoryObject.FirstName)
                .Select(b => b.FirstName)
                .Take(2) // Vill ta ut två unika namn. Kan inte. Fan.
                .ToList();

            threeNames.AddRange(tempList
                .Where(e => e.Gender == nameoryObject.Gender && e.FirstName != nameoryObject.FirstName && e.FirstName != threeNames[0])
                //.Where(d => d.FirstName != nameoryObject.FirstName && d.FirstName != threeNames[0])
                .Select(f => f.FirstName)
                .Take(1)
                .ToList());

            threeNames.Add(nameoryObject.FirstName);

            threeNames = threeNames.OrderBy(a => Guid.NewGuid()).ToList();

            //nameButton1.Text = threeNames[0];
            //nameButton2.Text = threeNames[1];
            //nameButton3.Text = threeNames[2];

            Slut på tidigare försökt till mindre bedrövlighet */
        }

        // Återställer UI inför att presentera person
        private void ClearUI()
        {
            nameButton1.Visible = true;
            nameButton2.Visible = true;
            nameButton3.Visible = true;

            SetBackGroundColor(DefaultBackColor);

            nameLabel.Text = "";
        }

        // Kolla svaret när användaren klickar på en av de tre namnknapparna
        private void CheckAnswer(Button sender, EventArgs e)
        {
            // Plocka fram aktuell person ur listan objects
            NameoryObject nameoryObject = objects[index];

            nameLabel.Text = nameoryObject.FirstName;

            nameButton1.Visible = false;
            nameButton2.Visible = false;
            nameButton3.Visible = false;

            // Sätt igång en timer för att visa rätt namn i en sekund
            timer1.Enabled = true;
            timer1.Start();

            bool correctAnswer;


            if (sender.Text == nameoryObject.FirstName)
            {
                correctAnswer = true;
                correctObjects.Add(nameoryObject);
            }
            else
            {
                correctAnswer = false;
                incorrectObjects.Add(nameoryObject);
            }

            // Varje gång vi gissat på ett objekt, uppdatera UI.
            RefreshUI(correctAnswer);
        }

        // Uppdatera UI beroende på hur svaret var. Den här metoden bör nog bakas ihop med ClearUI()
        private void RefreshUI(bool correct)
        {
            if (correct)
            {
                SetBackGroundColor(Color.Green);
            }
            else if (!correct)
            {
                SetBackGroundColor(Color.Red);
            }

            if (progressBar1.Maximum != objects.Count)
            {
                progressBar1.Maximum = objects.Count;
            }

            // Öka på progressBar1 med ett.
            if (typeOfGame != GamePlay.Continuous)
            progressBar1.Value = index + 1;
        }

        // En vansinnigt användbar metod. Eller? Hmm.
        private void SetBackGroundColor(Color color)
        {
            BackColor = color;
        }
    }
}
