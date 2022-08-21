using System;

namespace BossFight
{
    internal class Program
    {
        public const string FireballSpell = "Огненный шар";
        public const string AvoidDamageSpell = "Избежать урона";
        public const string StandartAttack = "Стандартная атака";
        public const string DrinkingDamageBoostPotion = "Выпить зелье, повышающее урон";

        private static int _enemyHealth = 1000;
        private static int _mageHealth = 500;

        private static int _standartMageDamage = 50;
        private static int _standartFireballSpellDamage = 300;
        private static int _damageFromCover = 20;
        private static int _herbsRestoresHealth = 50;
        private static int damageBoostAfterUseBoostPotion = 30;

        private static int _fireballChargesCount = 3;
        private static int _OpportunityTogoInToCover = 5;
        private static int _medicinalHerbsCount = 5;
        private static int _damageBoostPotionCount = 1;

        private static int _standartEnemyDamage = 100;

        private static bool _isMageAlive = true;
        private static bool _isEnemyAlive = true;
        private static bool _isSelectedAvoidSpell = false;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Добро пожаловать на ринг");
            Console.WriteLine($"Ваше первоначальное здоровье - {_mageHealth}, первоначальное здоровье врага - {_enemyHealth}");
            Console.WriteLine($"Количество огненных шаров - {_fireballChargesCount}");
            Console.WriteLine($"Количество возможностей избежать урона - {_OpportunityTogoInToCover}");
            Console.WriteLine($"Количество лечебных трав - {_medicinalHerbsCount}");
            Console.WriteLine($"Количество зелей, увеличивающих урон - {_damageBoostPotionCount}");
            Console.ResetColor();

            while (_isMageAlive && _isEnemyAlive)
            {
                Console.WriteLine("Каким заклинанием Вы желаете шандарахнуть врага?");
                Console.WriteLine($"1 - {FireballSpell}, 2 - {AvoidDamageSpell}, 3 - {StandartAttack}, 4 - {DrinkingDamageBoostPotion}");

                PerformsSpell();

                if (_enemyHealth <= 0)
                {
                    _enemyHealth = 0;
                    _isEnemyAlive = false;
                }
                else
                {
                    EnemyStandartAttack();

                    if (_mageHealth <= 0)
                    {
                        _mageHealth = 0;
                        _isMageAlive = false;
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Ваше здоровье - {_mageHealth} ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Здоровье врага - {_enemyHealth}");
                Console.ResetColor();
            }

            if (_isMageAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Вы победили!");
            }
            else if (_isEnemyAlive)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Вы проиграли!");
            }
            else
            {
                Console.WriteLine("Победила игра, Вы оба умерли");
            }

            Console.ResetColor();
        }

        private static void PerformsSpell()
        {
            bool isSelectedSpell = false;

            while (isSelectedSpell == false)
            {
                int userInput = ReadIntValueFromKeyboard();

                switch (userInput)
                {
                    case 1:
                        FireballHit();
                        isSelectedSpell = true;
                        break;
                    case 2:
                        AvoidDamage();
                        isSelectedSpell = true;
                        break;
                    case 3:
                        MageStandartAttack();
                        isSelectedSpell = true;
                        break;
                    case 4:
                        DrinkDamageBoostPotion();
                        isSelectedSpell = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("С таким заклинением - это Вам в TES, а наш маг такого не умеет");
                        Console.ResetColor();
                        break;
                }

                Console.ResetColor();
            }
        }

        private static void FireballHit()
        {
            if (_fireballChargesCount > 0)
            {
                _enemyHealth -= _standartFireballSpellDamage;
                _fireballChargesCount--;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Огненный шар нанёс {_standartFireballSpellDamage} урона");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"У Вас осталось {_fireballChargesCount} заряда");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Вы об этом забыли, но зарядов у Вас не осталось, в следующий раз не забывайте");
            }
        }

        private static void AvoidDamage()
        {
            if (_OpportunityTogoInToCover > 0)
            {
                Console.WriteLine("1 - Избежать урона и нанести урон в ответ, 2 - Избежать урона и восстановить себе немного здоровья");

                bool isSelectedOption = false;

                while (isSelectedOption == false)
                {
                    int userInput = ReadIntValueFromKeyboard();

                    switch (userInput)
                    {
                        case 1:
                            DealDamageFromCover();
                            isSelectedOption = true;
                            break;
                        case 2:
                            Heal();
                            isSelectedOption = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Пожалуйста, сделайте уже хоть что-нибудь, Вас вообще-то враг ждёт!");
                            break;
                    }
                }

                _OpportunityTogoInToCover--;
                _isSelectedAvoidSpell = true;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"У вас осталось {_OpportunityTogoInToCover} возможности избежать урона");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Вы больше не можете уходить в укрытие, а пока Вы об этом вспоминали, Вас уже ударили");
            }
        }

        private static void DealDamageFromCover()
        {
            _enemyHealth -= _damageFromCover;

            Console.WriteLine($"Вы уклонились, из-за этого Ваш удар был более неуклюжий.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Вы нанесли врагу {_damageFromCover} урона");
        }

        private static void Heal()
        {
            if (_medicinalHerbsCount > 0)
            {
                _mageHealth += _herbsRestoresHealth;
                _medicinalHerbsCount--;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Ваше здоровье повышено на {_herbsRestoresHealth}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Упс, кажется, все аптечки потрачены, скоро будете потрачены и Вы...");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"У Вас осталось {_medicinalHerbsCount} лечебных трав");
        }

        private static void MageStandartAttack()
        {
            Random random = new Random();
            int maximumForChance = 1;
            int chanceDealDoubleDamage = random.Next(maximumForChance + 1);

            if (chanceDealDoubleDamage == 0)
            {
                _enemyHealth -= _standartMageDamage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Вы нанесли {_standartMageDamage} урона");
            }
            else
            {
                int doubleMageDamage = _standartMageDamage * 2;

                _enemyHealth -= doubleMageDamage;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Вы успели жахнуть аж два раза своей палкой, Вы нанесли {doubleMageDamage} урона");
            }
        }

        private static void DrinkDamageBoostPotion()
        {
            if (_damageBoostPotionCount > 0)
            {
                _standartMageDamage += damageBoostAfterUseBoostPotion;
                _damageBoostPotionCount--;

                Console.WriteLine($"Вы выпили зелье, теперь Ваш стандартный урон составляет - {_standartMageDamage}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Вы долго искали зелье в кармане, но так и не нашли...");
            }
        }

        private static void EnemyStandartAttack()
        {
            if (_isSelectedAvoidSpell == false)
            {
                _mageHealth -= _standartEnemyDamage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Противник нанёс Вам - {_standartEnemyDamage} урона");
            }

            _isSelectedAvoidSpell = false;
        }

        private static int ReadIntValueFromKeyboard()
        {
            bool isIntValue = int.TryParse(Console.ReadLine(), out int value);

            if (isIntValue == true)
            {
                if (value <= 0)
                {
                    Console.WriteLine("Можно вводить только положительные числа");
                    return ReadIntValueFromKeyboard();
                }
                else
                {
                    return value;
                }
            }
            else
            {
                Console.WriteLine("Можно вводить только числа");
                return ReadIntValueFromKeyboard();
            }
        }
    }
}