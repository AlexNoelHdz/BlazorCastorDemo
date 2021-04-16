using BlazorCastorDemoTripwire.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCastorDemoTripwire.Pages
{
    public partial class BlazeCastor
    {
        private int score = 0;//UserScore
        private int currentTime = 60;//Time for user to play
        int hitPosition = 0;
        private string message = "";//Messages for user
        bool gameIsRunning = true;//Indicate if game is executing or not

        public List<SquareModel> Squares { get; set; } =
            new List<SquareModel>();

        public BlazeCastor()
        {
            for (int i = 0; i < 9; i++)
            {
                Squares.Add(new SquareModel
                {
                    Id = i
                });
            }
        }

        private void MouseUp(SquareModel s)
        {
            if (s.Id == hitPosition)
            {
                score += 1;
            }
        }
        private void ChooseSquare()
        {
            foreach (var item in Squares)
            {
                item.IsShown = false;
            }
            var randomPosition = new Random().Next(0, 9);
            Squares[randomPosition].IsShown = true;
            Console.WriteLine(randomPosition);
            hitPosition = randomPosition;
            StateHasChanged();
        }

        private async Task GameLoop()
        {
            while (gameIsRunning)
            {

                currentTime--;
                if (currentTime == 0)
                {
                    message = "EL JUEGO FINALIZÓ!";
                    gameIsRunning = false;
                }
                ChooseSquare();
                await Task.Delay(1000);
            }
        }

        protected override async void OnInitialized()
        {
            await GameLoop();
        }

    }
}
