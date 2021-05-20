using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using WebsocketServer.Classes;
using ChatProgram.UserControls.Friends;
using ChatProgram;

namespace ChatProgram.UserControls.Form1
{
    public partial class Friends : MetroUserControl
    {
        // Referencer
        private ChatProgram.Form1 main;
        private User signedInUser;
        public Friends()
        {
            InitializeComponent();
        }

        // Setup metoden bruges til at assigne vores referencer
        public void Setup(ChatProgram.Form1 _main, User _signedInUser)
        {
            main = _main;
            signedInUser = _signedInUser;

            CheckForFriendRequests(); // Vi tjekker også om der er nye venneanmodninger
        } 

        // Denne knap er til at sende en venneanmodning
        private async void btnFindUser_Click(object sender, EventArgs e)
        {
            // Først tjekker vi om brugeren ikke har skrevet noget i tekstfeltet, hvis dette er tilfældet viser vi en fejlbesked
            if (txtFindUser.Text == "") UpdateStatusLabel("Username cannot be empty", Color.Red); 

            // Vi bruger databasen til at finde en bruger
            User user = await Database.GetInstance().FindUser(txtFindUser.Text);
            
            // Hvis det vi får tilbage er null, så fandt vi ikke noget. Det vil sige at brugeren ikke eksisterer
            if (user == null)
            {
                // Vis fejlbesked
                UpdateStatusLabel("That user doesn't exist", Color.Red);
                return;
            }
            
            // Hvis den bruger vi fandt er det samme som den bruger der er logget ind
            if (signedInUser.name == user.name)
            {
                UpdateStatusLabel("You cannot send yourself a friend request", Color.Red);
                return;
            }

            // Hvis den bruger der er logged ind allerede er venner med brugeren
            if (signedInUser.friendsList.Contains(user.name))
            {
                UpdateStatusLabel($"You are already friends with {user.name}", Color.Red);
                return;
            }

            // Hvis vores panel af afventende venneanmodninger indeholder brugeren man forsøger at tilføje
            if (pnlPending.Controls.ContainsKey(txtFindUser.Text) == true)
            {
                UpdateStatusLabel("You have already sent a friend request to this user", Color.Red);
                return;
            }

            // Send venneanmodning
            await signedInUser.SendFriendRequest(user);

            // Lav en ny instans af vores PendingCard user control hvor vi passerer den bruger der er logget ind samt den bruger vi lige har tilføjet
            PendingCard card = new PendingCard(signedInUser, user);
            card.Removed += OnCardRemoved; // Opsæt et event der kører hvis man trykker på fjern knappen

            // Vi docker vores card til top, sådan at vi programmisk kan tilføje flere anmodninger 
            // uden at skal tænke på om kortet ender så brugeren ikke kan se det
            card.Dock = DockStyle.Top; 
            pnlPending.Controls.Add(card); // Tilføj kortet til panelet

            // Vis success besked
            UpdateStatusLabel($"Successfully sent a friend request to {user.name}", Color.Green);
        }

        // Denne metode finder ud af om den bruger der er logget ind har modtaget venneanmodninger
        private async void CheckForFriendRequests()
        {
            // Hvis brugeren har indkommende venneanmodninger
            if (signedInUser.pendingFriendsList.Count > 0)
            {
                // Loop igennem alle anmodninger
                foreach (string otherUsername in signedInUser.pendingFriendsList)
                {
                    // Find brugeren
                    User otherUser = await Database.GetInstance().FindUser(otherUsername);

                    // Tilføj brugeren til panelet
                    IncomingCard card = new IncomingCard(signedInUser, otherUser);
                    card.Finished += OnFinished;

                    card.Dock = DockStyle.Top;
                    pnlIncoming.Controls.Add(card);
                }
            }

            // Vi indlæser også de anmodninger den bruger der er logget ind har sendt
            if (signedInUser.sentPendingFriendsList.Count > 0)
            {
                foreach (string otherUsername in signedInUser.sentPendingFriendsList)
                {
                    User otherUser = await Database.GetInstance().FindUser(otherUsername);

                    PendingCard card = new PendingCard(signedInUser, otherUser);
                    card.Removed += OnCardRemoved;

                    card.Dock = DockStyle.Top;
                    pnlPending.Controls.Add(card);
                }
            }
        }

        // Når en knap fjernes kører der et eksternt event i PendingCard.cs og derudover fjerner vi også kortet visuelt fra panelet
        private void OnCardRemoved(PendingCard _card) => pnlPending.Controls.RemoveByKey(_card.Name);

        // Når et indkommende kort enten accepteres eller afvises
        private void OnFinished(IncomingCard _card)
        {
            // Fjern anmodningen fra panelet
            pnlIncoming.Controls.RemoveByKey(_card.Name);
            main.LoadFriends(); // Genindlæs venner i "Direct Messages" for at tilføje eventuelle venner hvis brugeren valgte accepter
        }

        // Denne metoder opdaterer en label, som vi kan bruge til fejl, success eller andre beskeder. Vi kan passere en farve til teksten også
        private void UpdateStatusLabel(string _text, Color _color)
        {
            lblStatus.ForeColor = _color;
            lblStatus.Text = _text;
            lblStatus.Visible = true;
        }
    }
}
