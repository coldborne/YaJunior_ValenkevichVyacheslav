using System;

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
        private Deck _deck;

        public Game()
        {
            _player = new Player();
            _deck = new Deck();
        }

        public void Work()
        {
            bool doesGameWork = true;

            while (doesGameWork)
            {
                Console.WriteLine("Выберите нужное действие");
                Console.WriteLine("1 - Взять карту");
                Console.WriteLine("2 - Взять сразу несколько рандомных карт");
                Console.WriteLine("3 - Показать карты в руке");
                Console.WriteLine("4 - Завершить игру");

                int chosenCommand = UserUtils.ReadInt();

                switch (chosenCommand)
                {
                    case (int)Commands.TakeCard:
                        GiveCardToPlayer();
                        break;

                    case (int)Commands.TakeRandomCards:
                        GiveCardsToPlayer();
                        break;

                    case (int)Commands.ShowPlayerCards:
                        _player.ShowCardInHand();
                        break;

                    case (int)Commands.Exit:
                        doesGameWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой комманды не существует");
                        break;
                }
            }
        }

        private void GiveCardToPlayer()
        {
            int cardNumber = UserUtils.GetRandomInt(0, _deck.Cards.Count);

            Card card = _deck.Cards[cardNumber];

            _player.TakeCard(card);

            _deck.DeleteCard(card);
        }

        private void GiveCardsToPlayer()
        {
            int cardsAmount = UserUtils.GetRandomInt(1, _player.MaxCardsInHandAmount - _player.CardsInHand.Count + 1);

            for (int i = 0; i < cardsAmount; i++)
            {
                int cardNumber = UserUtils.GetRandomInt(0, _deck.Cards.Count);

                Card card = _deck.Cards[cardNumber];

                _player.TakeCard(card);

                _deck.DeleteCard(card);
            }
        }
    }
}