using System;
using System.Collections.Generic;

namespace CardDeck
{
    public class Game
    {
        private Player _player;
        private Croupier _croupier;

        public Game(int cardsCount)
        {
            _player = new Player();
            _croupier = new Croupier(cardsCount);
        }
        
        private enum Command
        {
            TakeCard = 1,
            TakeRandomCards,
            ShowPlayerCards,
            Exit
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите нужное действие");
                Console.WriteLine($"{(int)Command.TakeCard} - Взять карту");
                Console.WriteLine($"{(int)Command.TakeRandomCards} - Взять сразу несколько рандомных карт");
                Console.WriteLine($"{(int)Command.ShowPlayerCards} - Показать карты в руке");
                Console.WriteLine($"{(int)Command.Exit} - Завершить игру");

                int chosenCommand = UserUtils.ReadInt();

                switch (chosenCommand)
                {
                    case (int)Command.TakeCard:
                        PassCards();
                        break;

                    case (int)Command.TakeRandomCards:
                        HandOverCards();
                        break;

                    case (int)Command.ShowPlayerCards:
                        _player.ShowCardsInHand();
                        break;

                    case (int)Command.Exit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой комманды не существует");
                        break;
                }
            }
        }

        private void PassCards()
        {
            if (_croupier.TryGiveCard(out Card card))
            {
                if (_player.TryTakeCard(card))
                {
                    Console.WriteLine("Карта успешно взята");
                }
                else
                {
                    Console.WriteLine("У пользователя максимальное количество карт в руке");
                }
            }
            else
            {
                Console.WriteLine("Карт в колоде нет");
            }
        }

        private void HandOverCards()
        {
            int playerCanTakeCardAmount = _player.MaxCardsInHandAmount - _player.GetCardsInHandAmount();
            int croupierCanHandOverCardAmount = _croupier.CardAmount;

            int minCardAmount = 1;
            int maxCardAmount = Math.Min(playerCanTakeCardAmount, croupierCanHandOverCardAmount);

            int cardAmount = UserUtils.GetRandomInt(minCardAmount, maxCardAmount + 1);

            List<Card> cards = new List<Card>();

            for(int i = 0; i < cardAmount; i++)
            {
                bool hasCroupierCard = _croupier.TryGiveCard(out Card card);

                if (hasCroupierCard)
                {
                    cards.Add(card);
                }
            }

            if (cards.Count > 0)
            {
                foreach (Card card in cards)
                {
                    _player.TryTakeCard(card);
                }

                Console.WriteLine($"Вы забрали {cards.Count}");
            }
        }
    }
}