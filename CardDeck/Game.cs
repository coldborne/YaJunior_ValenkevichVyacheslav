using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Game
    {
        private enum Commands
        {
            TakeCard = 1,
            TakeRandomCards,
            ShowPlayerCards,
            Exit
        }

        private Player _player;
        private Croupier _croupier;

        public Game()
        {
            _player = new Player();
            _croupier = new Croupier();
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите нужное действие");
                Console.WriteLine($"{(int)Commands.TakeCard} - Взять карту");
                Console.WriteLine($"{(int)Commands.TakeRandomCards} - Взять сразу несколько рандомных карт");
                Console.WriteLine($"{(int)Commands.ShowPlayerCards} - Показать карты в руке");
                Console.WriteLine($"{(int)Commands.Exit} - Завершить игру");

                int chosenCommand = UserUtils.ReadInt();

                switch (chosenCommand)
                {
                    case (int)Commands.TakeCard:
                        _player.TryTakeCard(_croupier.TryGiveCard());
                        break;

                    case (int)Commands.TakeRandomCards:
                        HandOverCards();
                        break;

                    case (int)Commands.ShowPlayerCards:
                        _player.ShowCardsInHand();
                        break;

                    case (int)Commands.Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой комманды не существует");
                        break;
                }
            }
        }

        private void HandOverCards()
        {
            int cardsAmount = UserUtils.GetRandomInt(1, _player.MaxCardsInHandAmount - _player.GetCardsInHandAmount() + 1);
            
            List<(bool,Card)> cardsInfo = new List<(bool,Card)>();

            for (int i = 0; i < cardsAmount; i++)
            {
                (bool IsExist, Card Card) cardInfo = _croupier.TryGiveCard();

                if (cardInfo.IsExist)
                {
                    cardsInfo.Add(cardInfo);
                }
            }

            if (cardsInfo.Count > 0)
            {
                foreach ((bool,Card) cardInfo in cardsInfo)
                {
                    _player.TryTakeCard(cardInfo);
                }
            }
        }
    }
}